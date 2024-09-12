using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;


namespace Logging.Shared
{
    public static class Logging
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureLogging => (hostBuilderContext, loggerConfiguration) =>
        {
            var environment = hostBuilderContext.HostingEnvironment;

            loggerConfiguration.ReadFrom.Configuration(hostBuilderContext.Configuration)
                               .Enrich.FromLogContext()
                               .Enrich.WithExceptionDetails()
                               .Enrich.WithProperty("Env", environment.EnvironmentName)
                               .Enrich.WithProperty("AppName", environment.ApplicationName);

            var elasticsearchBaseUrl = hostBuilderContext.Configuration.GetSection("Elasticsearch")["BaseUrl"];
            var userName = hostBuilderContext.Configuration.GetSection("Elasticsearch")["UserName"];
            var password = hostBuilderContext.Configuration.GetSection("Elasticsearch")["Password"];
            var indexName = hostBuilderContext.Configuration.GetSection("Elasticsearch")["IndexName"];


            loggerConfiguration.WriteTo.Elasticsearch(new(new Uri(elasticsearchBaseUrl!))
            {
                AutoRegisterTemplate = true,
                AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv8,
                IndexFormat = $"{indexName}-{environment.EnvironmentName}-logs-{DateTime.UtcNow:yyyy.MM.dd}",
                CustomFormatter = new ElasticsearchJsonFormatter()
            });

        };
    }
}
