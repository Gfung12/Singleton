using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Singleton
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ViewConfig_Click(object sender, RoutedEventArgs e)
        {
            string configInfo = $"Moneda: {ConfigManager.Instance.Config.DefaultCurrency}\n" +
                               $"Formato Hora: {ConfigManager.Instance.Config.TimeFormat}\n" +
                               $"Conexiones Máx: {ConfigManager.Instance.Config.MaxConnections}\n" +
                               $"Idioma: {ConfigManager.Instance.Config.Language}\n" +
                               $"AutoGuardado: {ConfigManager.Instance.Config.AutoSaveInterval} min\n" +
                               $"Logs: {ConfigManager.Instance.Config.EnableLogs}\n" +
                               $"Tema: {ConfigManager.Instance.Config.Theme}\n" +
                               $"Región: {ConfigManager.Instance.Config.Region}\n" +
                               $"Backup: {ConfigManager.Instance.Config.BackupEnabled}\n" +
                               $"Directorio Backup: {ConfigManager.Instance.Config.BackupDirectory}";

            MessageBox.Show(configInfo, "Configuración Actual");
        }

        private void ChangeConfig_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new ConfigDialog();
            if (dialog.ShowDialog() == true)
            {
                MessageBox.Show("Configuración actualizada correctamente", "Éxito");
            }
        }

        private void WelcomeScreen_Click(object sender, RoutedEventArgs e)
        {
            var welcomeScreen = new WelcomeScreen();
            welcomeScreen.Show();
        }

        private void ConnectionSimulator_Click(object sender, RoutedEventArgs e)
        {
            var simulator = new ConnectionSimulator();
            simulator.Show();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}