namespace HM5.Server
{
    public class Options
    {
        public enum ESteamService
        {
            None = 0,
            GameServer,
            WebApi
        }

        public bool FixAddMetricsContentType { get; set; } = false;
        public bool EnableRequestLogging { get; set; } = false;
        public bool EnableRequestBodyLogging { get; set; } = false;
        public bool EnableResponseBodyLogging { get; set; } = false;
        public string MockedContractSteamId { get; set; } = "76561198161220058";
        public int WalletAmount { get; set; } = 1337;
        public bool UseCustomContracts { get; set; } = false;
        public int JwtTokenExpirationInSeconds { get; set; } = 60 * 60 * 8; //NOTE: 8 hours
        public string JwtSignKey { get; set; } = Guid.NewGuid().ToString();
        public ESteamService SteamService { get; set; } = ESteamService.None;
        public string SteamWebApiKey { get; set; } = string.Empty;
    }
}
