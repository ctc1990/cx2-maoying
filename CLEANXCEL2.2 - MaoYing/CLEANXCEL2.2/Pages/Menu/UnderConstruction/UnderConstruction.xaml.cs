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
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Pages.Menu.UnderConstruction
{
    /// <summary>
    /// Interaction logic for UnderConstruction.xaml
    /// </summary>
    public partial class UnderConstruction : Page
    {
        private TcAdsClient adsClient = new TcAdsClient();
        public UnderConstruction()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
