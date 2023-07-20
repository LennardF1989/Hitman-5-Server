using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using HM5.Server.Interfaces;
using HM5.Server.Json;

namespace HM5.Server.Services
{
    public class SteamWebApiService : ISteamService
    {
        private sealed class AuthenticateUserTicketResponse
        {
            [JsonPropertyName("result")]
            public string Result { get; set; }

            [JsonPropertyName("steamid")]
            [JsonConverter(typeof(AnyToJsonStringConverter<ulong>))]
            public ulong SteamId { get; set; }

            [JsonPropertyName("ownersteamid")]
            [JsonConverter(typeof(AnyToJsonStringConverter<ulong>))]
            public ulong OwnerSteamId { get; set; }

            [JsonPropertyName("vacbanned")]
            public bool VACBanned { get; set; }

            [JsonPropertyName("publisherbanned")]
            public bool PublisherBanned { get; set; }
        }

        private const string API_URL = "https://api.steampowered.com/ISteamUserAuth/AuthenticateUserTicket/v1";

        private readonly HttpClient _httpClient;
        private readonly string _steamWebApiKey;

        public SteamWebApiService(Options options)
        {
            _httpClient = new HttpClient();
            _steamWebApiKey = options.SteamWebApiKey;
        }

        public async Task<bool> AuthenticateUser(byte[] authTicketDataBytes, ulong steamId)
        {
            var result = await AuthenticateUserTicket(
                _steamWebApiKey,
                203140,
                Convert.ToHexString(authTicketDataBytes)
            );

            return
                result != null &&
                result.Result == "OK" &&
                result.SteamId == steamId;
        }

        private async Task<AuthenticateUserTicketResponse> AuthenticateUserTicket(string key, int appId, string ticket)
        {
            try
            {
                var response = await _httpClient.GetStringAsync(
                    $"{API_URL}?key={key}&appId={appId}&ticket={ticket}"
                );

                var jsonResponse = JsonSerializer.Deserialize<JsonObject>(response);

                return jsonResponse?["response"]?["params"]?.Deserialize<AuthenticateUserTicketResponse>();
            }
            catch
            {
                //Do nothing
            }

            return null;
        }
    }
}