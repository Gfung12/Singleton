using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Singleton
{

    public partial class ConnectionSimulator : Window
    {
        private bool _isRunning;
        private int _currentConnections = 0;
        private Random _random = new Random();

        public ConnectionSimulator()
        {
            InitializeComponent();
            txtSummary.Text = $"Moneda: {ConfigManager.Instance.Config.DefaultCurrency}";
        }

        private void StartSimulation_Click(object sender, RoutedEventArgs e)
        {
            if (_isRunning) return;

            _isRunning = true;
            _currentConnections = 0;
            lstLogs.Items.Clear();

            var thread = new Thread(SimulateConnections);
            thread.Start();
        }

        private void StopSimulation_Click(object sender, RoutedEventArgs e)
        {
            _isRunning = false;
        }

        private void SimulateConnections()
        {
            int maxConnections = ConfigManager.Instance.Config.MaxConnections;
            bool enableLogs = ConfigManager.Instance.Config.EnableLogs;

            while (_isRunning && _currentConnections < maxConnections)
            {
                _currentConnections++;

                bool success = _random.Next(0, 100) > 20; // 80% de éxito

                Dispatcher.Invoke(() =>
                {
                    if (enableLogs)
                    {
                        string log = success
                            ? $"Conexión #{_currentConnections}: Establecida con éxito"
                            : $"Conexión #{_currentConnections}: Falló";
                        lstLogs.Items.Add(log);
                    }

                    if (_currentConnections >= maxConnections)
                    {
                        lstLogs.Items.Add("¡Límite de conexiones alcanzado!");
                        _isRunning = false;
                    }
                });

                Thread.Sleep(1000); // Espera 1 segundo entre conexiones
            }
        }
    }
}
