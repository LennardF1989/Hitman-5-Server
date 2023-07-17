using System.Text.Encodings.Web;
using System.Text.Json.Serialization;
using HM5.Server.Controllers.Hitman;
using HM5.Server.Controllers.Sniper;
using HM5.Server.Interfaces;
using HM5.Server.Json;
using HM5.Server.Mvc;
using HM5.Server.Services;

namespace HM5.Server
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder
                    .AddFilter("Microsoft", LogLevel.Warning)
                    .AddConsole();
            });

            services
                .AddMvc(options =>
                {
                    options.Filters.Add<ModelStateFilter>();

                    options.EnableEndpointRouting = false;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = null;

                    //NOTE: The in-game JSON Deserializer expects the actual quote-character, not the escaped unicode!
                    options.JsonSerializerOptions.Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping;

                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                    options.JsonSerializerOptions.Converters.Add(new BooleanToStringConverter());
                    options.JsonSerializerOptions.Converters.Add(new FloatToStringConverter());
                    options.JsonSerializerOptions.Converters.Add(new IntegerToStringConverter());
                });

            var options = _configuration
                .GetSection("Options")
                .Get<Options>();

            services.AddSingleton(options);

            services.AddSingleton<ISimpleLogger>(_ => new SimpleLogger(string.Empty));

            services.AddSingleton<IMetadataServiceForHitman>(_ => new MetadataService(
                HitmanController.SchemaNamespace,
                HitmanController.GetEdmEntityTypes(),
                HitmanController.GetEdmFunctionImports()
            ));

            services.AddSingleton<IMetadataServiceForSniper>(_ => new MetadataService(
                SniperController.SchemaNamespace,
                SniperController.GetEdmEntityTypes(),
                SniperController.GetEdmFunctionImports()
            ));

            services.AddTransient<FixAddMetricsContentTypeMiddleware>();
            services.AddTransient<RequestResponseLoggerMiddleware>();

            services.AddSingleton<IContractsService, ContractsService>();
        }

        public void Configure(IApplicationBuilder app, Options options, IContractsService contractsService)
        {
            if (options.UseCustomContracts)
            {
                Directory.CreateDirectory("Contracts");

                contractsService.RebuildCache();
            }

            if (options.FixAddMetricsContentType)
            {
                app.UseMiddleware<FixAddMetricsContentTypeMiddleware>();
            }

            if (options.EnableRequestLogging)
            {
                app.UseMiddleware<RequestResponseLoggerMiddleware>();
            }

            app.UseMvc();
        }
    }
}