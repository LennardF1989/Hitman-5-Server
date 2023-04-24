using Microsoft.AspNetCore;

namespace HM5.Server
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args)
        {
            return WebHost
                .CreateDefaultBuilder(args)
                .UseKestrel(options =>
                {
                    //NOTE: Since the game doesn't actually POST data...
                    options.Limits.MaxRequestLineSize = int.MaxValue;
                    options.Limits.MaxRequestBufferSize = int.MaxValue;
                })
                .UseStartup<Startup>()
                .Build();
        }
    }
}