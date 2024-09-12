using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Sinks.Elasticsearch;

namespace MicroServiceShop.Logging
{
    public static class Logging
    {
        public static Action<HostBuilderContext, LoggerConfiguration> ConfigureSerilog()
        {
            return (context, configuration) =>
            {
                var elasticsearchUrl = context.Configuration["ElasticConfiguration:Uri"];
                var appName = context.Configuration["ApplicationName"];
                var envName = context.Configuration["EnvironmentName"];
                var indexName = context.Configuration["IndexName"];


                configuration
                    .Enrich.FromLogContext()
                    .Enrich.WithProperty("ApplicationName", appName) 
                    .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticsearchUrl))
                    {
                        AutoRegisterTemplate = true,
                        IndexFormat = $"{indexName}-{envName}-logs-{DateTime.UtcNow:yyyy.MM.dd}"
                    })
                    .ReadFrom.Configuration(context.Configuration); 
            };
        }
    }
}
