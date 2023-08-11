using Microsoft.Extensions.Configuration;

namespace LoginAutomation
{
    public class AppConfig
    {
        private readonly IConfiguration _configuration;

        public AppConfig()
        {
            _configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public string GetSetting(string key)
        {
            return _configuration[key];
        }
    }
}
