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

    public partial class WelcomeScreen : Window
    {
        public WelcomeScreen()
        {
            InitializeComponent();
            Loaded += WelcomeScreen_Loaded;
        }

        private void WelcomeScreen_Loaded(object sender, RoutedEventArgs e)
        {
            var config = ConfigManager.Instance.Config;

            // Configurar mensaje de bienvenida según el idioma
            txtWelcome.Text = config.Language == "ES" ? "¡Bienvenido!" : "Welcome!";

            // Configurar hora según el formato
            if (config.TimeFormat == "24H")
            {
                txtTime.Text = DateTime.Now.ToString("HH:mm:ss");
            }
            else
            {
                txtTime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            }

            // Configurar tema
            if (config.Theme == "dark")
            {
                Background = System.Windows.Media.Brushes.DimGray;
                Foreground = System.Windows.Media.Brushes.White;
            }
            else
            {
                Background = System.Windows.Media.Brushes.White;
                Foreground = System.Windows.Media.Brushes.Black;
            }
        }
    }
}
