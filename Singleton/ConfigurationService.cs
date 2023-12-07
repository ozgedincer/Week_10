using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class ConfigurationService
    {

        private static ConfigurationService instance;

        public static ConfigurationService GetInstance()
        {
            if (instance is null)
                instance = new();

            return instance;
        }

        public string GetValue(string key)
        {
            ConfigurationManager configurationManager = new();

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;

            configurationManager.SetBasePath(path);

            configurationManager.AddJsonFile("Configuration.json");

            return configurationManager.GetSection(key).Value;
        }
    }
}