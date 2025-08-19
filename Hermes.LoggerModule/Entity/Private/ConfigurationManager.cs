using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System;
using System.IO;

namespace Hermes.LoggerModule.Entity.Private
{
    public static class ConfigurationManager
    {
        private static readonly IConfigurationRoot _config;

            static ConfigurationManager()
            {
                // Ruta de la DLL
                var dllPath = typeof(ConfigurationManager).Assembly.Location;
                var dllDir = Path.GetDirectoryName(dllPath)!;
                var configFile = Path.Combine(dllDir, "Hermes.LoggerModule.config.json");

                _config = new ConfigurationBuilder()
                    .AddJsonFile(configFile, optional: false, reloadOnChange: true)
                    .Build();
            }

        public static T Option<T>(string key) => (T)Convert.ChangeType(_config[key], typeof(T));
    }
}
