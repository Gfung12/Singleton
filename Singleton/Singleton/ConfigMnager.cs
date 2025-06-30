using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Singleton
{
    public sealed class ConfigManager
    {
        private static readonly Lazy<ConfigManager> instance = new Lazy<ConfigManager>(() => new ConfigManager());
        private const string ConfigFilePath = "config.json";

        public Configuration Config { get; private set; }

        public static ConfigManager Instance => instance.Value;

        private ConfigManager()
        {
            LoadConfig();
        }

        private void LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigFilePath))
                {
                    string json = File.ReadAllText(ConfigFilePath);
                    Config = JsonConvert.DeserializeObject<Configuration>(json);
                }
                else
                {
                    Config = new Configuration();
                    SaveConfig();
                }
            }
            catch
            {
                Config = new Configuration();
            }
        }

        public void SaveConfig()
        {
            string json = JsonConvert.SerializeObject(Config, Formatting.Indented);
            File.WriteAllText(ConfigFilePath, json);
        }

        public void UpdateConfig(Action<Configuration> updateAction)
        {
            updateAction(Config);
            SaveConfig();
        }
    }
}
