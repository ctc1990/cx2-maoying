using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Drawing;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CLEANXCEL2._2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        public static string language = "mandarin";//"english";//
        public static MainWindow AppWindow;
        public MainWindow()
        {
            InitializeComponent();
            AppWindow = this;
            //this.Topmost = true;
            //System.Diagnostics.Process.GetCurrentProcess().PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
        }

        private void FrameContainerLoaded(object sender, RoutedEventArgs e)
        {
            //Globals.PAGE_URL = "Pages/Menu/Index.xaml";
            Globals.PAGE_URL = "Intro.xaml";
            Globals.PAGE_REQUEST();
        }

        private void TrayIcon_TrayLeftMouseDown(object sender, RoutedEventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Topmost = true;
            this.WindowState = WindowState.Maximized;
            notifyIcon.Visibility = Visibility.Hidden;
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon.Visibility = Visibility.Visible;
                notifyIcon.ShowBalloonTip("CLEANXCEL2", "App is minimized", notifyIcon.Icon);
            }
        }

        private void MyPopDown_Completed(object sender, EventArgs e)
        {
            (new Pages.Window.WindowsMessageBox(null, null, Pages.Window.WindowsMessageBox.State.Ok)).PopDown_Completed();
        }
    }
}
