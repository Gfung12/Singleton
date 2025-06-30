using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Singleton
{
    public class Configuration
    {
        public string DefaultCurrency { get; set; } = "CRC";
        public string TimeFormat { get; set; } = "24H";
        public int MaxConnections { get; set; } = 10;
        public string Language { get; set; } = "ES";
        public int AutoSaveInterval { get; set; } = 5;
        public bool EnableLogs { get; set; } = true;
        public string Theme { get; set; } = "light";
        public string Region { get; set; } = "LATAM";
        public bool BackupEnabled { get; set; } = false;
        public string BackupDirectory { get; set; } = "./backups";
    }
}
