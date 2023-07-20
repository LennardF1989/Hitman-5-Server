using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using HM5.Server.Interfaces;

namespace HM5.Server.Mvc
{
    public class SteamAuthMiddleware : IMiddleware
    {
        private class JwtToken
        {
            public class JwtTokenPayload
            {
                public ulong Uid { get; set; }
                public long Timestamp { get; set; }
            }

            public JwtTokenPayload Payload { get; set; }
            public string Hash { get; set; }
        }

        private const string REQUEST_HEADER_OSAUTHPROVIDER = "OS-AuthProvider";
        private const string REQUEST_HEADER_OSAUTHTICKETDATA = "OS-AuthTicketData";
        private const string REQUEST_HEADER_OSUID = "OS-UID";
        private const string RESPONSE_HEADER_OSAUTHRESPONSE = "OS-AuthResponse";
        private const string RESPONSE_HEADER_OSERROR = "OS-Error";

        private const string OSAUTHPROVIDER_SERVER = "6";

        //private const int OSERROR_OK = 0;
        private const int OSERROR_FAILED = 1;
        private const int OSERROR_EXPIRED = 2;

        private readonly ISteamService _steamService;
        private readonly int _jwtTokenExpirationInSeconds;
        private readonly byte[] _jwtSignKey;

        public SteamAuthMiddleware(ISteamService steamService, Options options)
        {
            _steamService = steamService;
            _jwtTokenExpirationInSeconds = options.JwtTokenExpirationInSeconds;
            _jwtSignKey = Encoding.UTF8.GetBytes(options.JwtSignKey);
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            //TODO: Move this middleware to a filter instead?
            if (
                context.Request.Path is { HasValue: true, Value: not null } &&
                !context.Request.Path.Value.StartsWith("/hm5")  && 
                !context.Request.Path.Value.StartsWith("/sniper")
            )
            {
                await next(context);

                return;
            }

            var authProvider = context.Request.Headers[REQUEST_HEADER_OSAUTHPROVIDER];
            var authTicketData = context.Request.Headers[REQUEST_HEADER_OSAUTHTICKETDATA];
            var uid = context.Request.Headers[REQUEST_HEADER_OSUID];

            //NOTE: Check for our own AuthProvider first
            if (authProvider == OSAUTHPROVIDER_SERVER)
            {
                var jwtToken = DecodeSimpleJwtToken(authTicketData);

                if (
                    jwtToken != null && 
                    jwtToken.Uid == ulong.Parse(uid) && 
                    DateTimeOffset.Now.ToUnixTimeSeconds() - jwtToken.Timestamp < _jwtTokenExpirationInSeconds
                )
                {
                    await next(context);

                    return;
                }

                RejectRequest(context, OSERROR_EXPIRED);

                return;
            }

            //NOTE: If we didn't pass the previous check, enforce valid AuthTicketData.
            try
            {
                var authTicketDataBytes = Convert.FromBase64String(authTicketData);
                var steamId = ulong.Parse(uid);

                var result = await _steamService.AuthenticateUser(authTicketDataBytes, steamId);

                if (result)
                {
                    var jwtToken = EncodeSimpleJwtToken(new JwtToken.JwtTokenPayload
                    {
                        Uid = steamId,
                        Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds()
                    });

                    context.Response.Headers[RESPONSE_HEADER_OSAUTHRESPONSE] = jwtToken;

                    await next(context);

                    return;
                }
            }
            catch
            {
                //Do nothing
            }

            //NOTE: Always reject a request at this point
            RejectRequest(context, OSERROR_FAILED);
        }

        private static void RejectRequest(HttpContext context, int osError)
        {
            context.Response.StatusCode = 403;
            context.Response.Headers[RESPONSE_HEADER_OSERROR] = osError.ToString();
        }

        private string EncodeSimpleJwtToken(JwtToken.JwtTokenPayload payload)
        {
            var hasher = new HMACSHA256(_jwtSignKey);

            var hash = Convert.ToHexString(hasher.ComputeHash(
                    Encoding.UTF8.GetBytes(
                        JsonSerializer.Serialize(payload)
                    )
                )
            );

            var jwtToken = new JwtToken
            {
                Payload = payload,
                Hash = hash
            };

            return Convert.ToBase64String(
                Encoding.UTF8.GetBytes(
                    JsonSerializer.Serialize(jwtToken)
                )
            );
        }

        private JwtToken.JwtTokenPayload DecodeSimpleJwtToken(string simpleJwtToken)
        {
            var jwtToken = JsonSerializer.Deserialize<JwtToken>(
                Encoding.UTF8.GetString(
                    Convert.FromBase64String(simpleJwtToken)
                )
            );

            var hasher = new HMACSHA256(_jwtSignKey);

            var hash = Convert.ToHexString(hasher.ComputeHash(
                    Encoding.UTF8.GetBytes(
                        JsonSerializer.Serialize(jwtToken.Payload)
                    )
                )
            );

            return jwtToken.Hash == hash ? jwtToken.Payload : null;
        }
    }
}
