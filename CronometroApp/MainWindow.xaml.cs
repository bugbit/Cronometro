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
using System.Windows.Navigation;
using System.Windows.Shapes;
using CronometroApp.Services;

namespace CronometroApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ICronometroService cronometro;

        public MainWindow()
        {
            cronometro = CronometroService.Create();
            cronometro.DoUpdate += Cronometro_DoUpdate;

            InitializeComponent();
            CronometroUpdate();
        }

        private void Cronometro_DoUpdate(object? sender, EventArgs e)
        {
            CronometroUpdate();
        }

        private void CronometroUpdate()
        {
            lbInfo.Content = cronometro.Value.ToString(@"hh\:\:mm\:\:ss");
        }

        private void btnStart_Click(object sender, RoutedEventArgs e) => cronometro.Start();

        private void btnPause_Click(object sender, RoutedEventArgs e) => cronometro.Pause();

        private void btnStop_Click(object sender, RoutedEventArgs e) => cronometro.Stop();

        private void Window_Closed(object sender, EventArgs e)
        {
            cronometro.Dispose();
        }
    }
}
