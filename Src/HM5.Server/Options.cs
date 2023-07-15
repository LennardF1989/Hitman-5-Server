namespace HM5.Server
{
    public class Options
    {
        public bool FixAddMetricsContentType { get; set; } = false;
        public bool EnableRequestLogging { get; set; } = false;
        public bool EnableRequestBodyLogging { get; set; } = false;
        public bool EnableResponseBodyLogging { get; set; } = false;
        public string MockedContractSteamId { get; set; } = "76561198161220058";
    }
}
