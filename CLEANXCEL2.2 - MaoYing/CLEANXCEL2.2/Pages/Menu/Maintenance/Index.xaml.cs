using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Pages.Menu.Maintenance
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public static Index AppWindow;
        public Index()
        {
            InitializeComponent();
            AppWindow = this;
        }

        public static String MENUPAGE_URL = null; // Modifiable

        public static void MENUPAGE_REQUEST()
        {
            if (MENUPAGE_URL != null)
            {
                AppWindow.FrameLocalContainer.Source = new Uri(MENUPAGE_URL, UriKind.RelativeOrAbsolute);
                Storyboard SB = (Storyboard)AppWindow.FindResource("ShowFrame");
                SB.Begin();
                Debug.WriteLine("MENUPAGE_REQUEST : Completed.");
            }
            else
            {
                Debug.WriteLine("MENUPAGE_REQUEST : MENUPAGE_URL is not defined.");
            }
        }

        private void FrameLocalContainer_Loaded(object sender, RoutedEventArgs e)
        {
            //MENUPAGE_URL = "Schematics.xaml";
            MENUPAGE_URL = "MachineControl.xaml";
            RBSchematics.IsChecked = true;
            MENUPAGE_REQUEST();
        }

        public void HidePage()
        {
            Storyboard SB = (Storyboard)FindResource("HideFrame");
            SB.Begin();
        }

        private void RBSchematics_Checked(object sender, RoutedEventArgs e)
        {
            //if (MENUPAGE_URL != "Schematics.xaml")
            if (MENUPAGE_URL != "MachineControl.xaml")
            {
                //MENUPAGE_URL = "Schematics.xaml";
                MENUPAGE_URL = "MachineControl.xaml";
                HidePage();
            }
        }

        //private void RBSensor_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (MENUPAGE_URL != "Sensor.xaml")
        //    {
        //        MENUPAGE_URL = "Sensor.xaml";
        //        HidePage();
        //    }
        //}

        private void RBRestore_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "Restore.xaml")
            {
                MENUPAGE_URL = "Restore.xaml";
                HidePage();
            }
        }

        private void LoadPage(object sender, EventArgs e)
        {
            MENUPAGE_REQUEST();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();

            if (Globals.CONNECTION)
            {
                // Enter Manual Mode
                TcAdsClient adsClient = new TcAdsClient();
                adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bBasketCfmEn", "false", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bAutoStartPB", "false", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bMainOnOff", "false", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bAutoModeOnPB", "false", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bManualModeOnPB", "true", "bool");
                adsClient.Disconnect();
                adsClient.Dispose();
            }
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("19,94,103,104,185");

                PageTitle.Text = hashtable[19].ToString();
                PageDescription.Text = hashtable[94].ToString();
                RBSchematics.Content = hashtable[103].ToString();
                RBRestore.Content = hashtable[185].ToString();
            }
            catch { }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (Globals.CONNECTION)
            {
                // Exit Manual Mode
                TcAdsClient adsClient = new TcAdsClient();
                adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bManualModeOn", "false", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bManualModeOnPB", "false", "bool");
                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bManualModeOnLatch", "false", "bool");
                adsClient.Disconnect();
                adsClient.Dispose();
            }
        }
    }
}
