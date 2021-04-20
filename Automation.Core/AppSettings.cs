using Microsoft.Extensions.Configuration;
using System.IO;

namespace Automation.Core
{
    public class AppSettings
    {
        public string this[string key]
        {
            get { return GetAppConfig(key); }
        }

       private string GetAppConfig(string key)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();
            return root[key];
        }

    }
}
