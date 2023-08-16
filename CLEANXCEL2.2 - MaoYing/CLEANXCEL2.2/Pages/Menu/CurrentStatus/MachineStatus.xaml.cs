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

namespace CLEANXCEL2._2.Pages.Menu.CurrentStatus
{
    /// <summary>
    /// Interaction logic for MachineStatus.xaml
    /// </summary>
    public partial class MachineStatus : Page
    {
        public MachineStatus()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void FrameSchematic_Loaded(object sender, RoutedEventArgs e)
        {
            FrameSchematic.Source = new Uri("../Blueprints/Schematic.xaml", UriKind.RelativeOrAbsolute);
        }

        private void FrameSensor_Loaded(object sender, RoutedEventArgs e)
        {
            FrameSensor.Source = new Uri("../Blueprints/Sensor.xaml", UriKind.RelativeOrAbsolute);
        }
    }
}
