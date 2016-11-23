using Hardcodet.Wpf.TaskbarNotification;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Thein
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        TaskbarIcon tbIc;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainWindow = new Window();
            MainWindow.Visibility = Visibility.Hidden;

            StandbySettings.DisableStandby();
            tbIc = (TaskbarIcon)FindResource("TaskbarIcon");
        }

        private void Deactivate_Click(object sender, RoutedEventArgs e)
        {
            StandbySettings.EnableStandby();
            tbIc.ToolTipText = "Inactive";
            tbIc.IconSource = new BitmapImage(new Uri(@"pack://application:,,,/Icons/cup-empty.ico"));
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            StandbySettings.EnableStandby();
            Application.Current.Shutdown();
        }

        private void Activate_Click(object sender, RoutedEventArgs e)
        {
            StandbySettings.DisableStandby();
            tbIc.ToolTipText = "Active";
            tbIc.IconSource = new BitmapImage(new Uri(@"pack://application:,,,/Icons/cup.ico")); 
        }
    }
}
