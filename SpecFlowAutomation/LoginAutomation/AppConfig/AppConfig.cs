﻿using Microsoft.Extensions.Configuration;

namespace LoginAutomation
{
    public class AppConfig
    {
        private readonly IConfiguration _configuration;


        // I can also use a path and provide it as a param to access the configuration file from custom places
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
