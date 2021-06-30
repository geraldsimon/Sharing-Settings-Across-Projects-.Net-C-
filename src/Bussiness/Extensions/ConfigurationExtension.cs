using Bussiness.Intefaces;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Bussiness.Extensions
{
    public class ConfigurationExtension : IConfigurationExtension
    {
        private readonly IConfiguration _config;
        private string Environment = string.Empty;

        public ConfigurationExtension()
        {
#if DEBUG
            Environment = "Dev";
#else
        _Environment ="Prod";
#endif

            _config = new ConfigurationBuilder()
                .SetBasePath(@$"{Directory.GetCurrentDirectory()}\")
                .AddJsonFile("SharedAppsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"SharedAppsettings.{Environment}.json")
                .AddJsonFile(@$"appsettings.json")
                .Build();
        }

        public string GetAppSettings(string section)
        {
            string resultSection;
            try
            {
                resultSection = _config.GetSection(section).Value;
            }
            catch (System.Exception)
            {

                throw;
            }
            return resultSection;
        }
    }
}
