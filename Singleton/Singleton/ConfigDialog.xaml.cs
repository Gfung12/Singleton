using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Singleton
{
    public partial class ConfigDialog : Window
    {
        public ConfigDialog()
        {
            InitializeComponent();
            LoadCurrentConfig();
        }

        private void LoadCurrentConfig()
        {
            var config = ConfigManager.Instance.Config;

            txtCurrency.Text = config.DefaultCurrency;
            txtTimeFormat.Text = config.TimeFormat;
            txtMaxConnections.Text = config.MaxConnections.ToString();
            txtLanguage.Text = config.Language;
            txtAutoSave.Text = config.AutoSaveInterval.ToString();
            chkLogs.IsChecked = config.EnableLogs;
            txtTheme.Text = config.Theme;
            txtRegion.Text = config.Region;
            chkBackup.IsChecked = config.BackupEnabled;
            txtBackupDir.Text = config.BackupDirectory;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            ConfigManager.Instance.UpdateConfig(config =>
            {
                config.DefaultCurrency = txtCurrency.Text;
                config.TimeFormat = txtTimeFormat.Text;

                if (int.TryParse(txtMaxConnections.Text, out int maxConn))
                    config.MaxConnections = maxConn;

                config.Language = txtLanguage.Text;

                if (int.TryParse(txtAutoSave.Text, out int autoSave))
                    config.AutoSaveInterval = autoSave;

                config.EnableLogs = chkLogs.IsChecked ?? false;
                config.Theme = txtTheme.Text;
                config.Region = txtRegion.Text;
                config.BackupEnabled = chkBackup.IsChecked ?? false;
                config.BackupDirectory = txtBackupDir.Text;
            });

            DialogResult = true;
            Close();
        }
    }
}
