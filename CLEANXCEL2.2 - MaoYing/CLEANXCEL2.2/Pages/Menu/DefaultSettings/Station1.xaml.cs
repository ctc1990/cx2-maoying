using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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

namespace CLEANXCEL2._2.Pages.Menu.DefaultSettings
{
    /// <summary>
    /// Interaction logic for Station1.xaml
    /// </summary>

    public partial class Station1 : Page
    {
        TcAdsClient adsClient = new TcAdsClient();
        Hashtable hashtableValue = new Hashtable();
        Hashtable hashtableMax = new Hashtable();
        Hashtable hashtablePLCValue = new Hashtable();

        public Station1()
        {
            InitializeComponent();
        }

        protected void USDial_AmountChanged(object sender, EventArgs e)
        {
            double TotalAmount = (double)((UserControls.Dial)sender).Amount;
            TotalAmount = Math.Round((TotalAmount / 100) * (Convert.ToInt16(hashtableMax[(UserControls.Dial)sender])));
            ((TextBlock)hashtableValue[(UserControls.Dial)sender]).Text = TotalAmount.ToString();
        }

        protected void PressureDial_AmountChanged(object sender, EventArgs e)
        {
            double TotalAmount = (double)((UserControls.Dial)sender).Amount;
            TotalAmount = Math.Round((TotalAmount / 100) * (Convert.ToInt16(hashtableMax[(UserControls.Dial)sender])));
            ((TextBlock)hashtableValue[(UserControls.Dial)sender]).Text = TotalAmount.ToString();
        }

        private void DialEventHandler()
        {
            //US1Dial.AmountChanged += new EventHandler(USDial_AmountChanged);
            PV1Dial.AmountChanged += new EventHandler(PressureDial_AmountChanged);
        }

        private void DialMappingValue()
        {
            //hashtableValue.Add(US1Dial, CurrentUS1Power);
            hashtableValue.Add(PV1Dial, CurrentPV1Power);
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            Globals.currentPage = "Station1";
            Globals.POPUP_URL = "../Pages/Window/WindowsMessageBox.xaml";
            Globals.POPUP_REQUEST("51", "52", Window.WindowsMessageBox.State.Confirmation);
        }

        public void TriggerProcess()
        {
            if (Globals.CONNECTION)
            {
                Globals.currentPage = null;
                Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";
                Encode(adsClient);
                Decode(adsClient);
            }
        }

        private void Encode(TcAdsClient adsClient)
        {
            //Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".ARrStnTempSV[2]", PV1Dial.Amount.ToString(), "real");
            Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Pressure(adsClient, 1, TBPV1SetpointLow.Text, TBPV1SetpointHigh.Text);
        }

        private void Decode(TcAdsClient adsClient)
        {
            //PV1Dial.ChangeAmount(Convert.ToInt32(Controllers.ADS.ADS_ReadWrite.ADS_ReadValue(adsClient, ".ARrStnTempSV[2]")));
            //PressureDial_AmountChanged(PV1Dial, null);
            List<string> list = Controllers.RecipeManagement.API.Equipment_Settings.DownloadSettings_Pressure(adsClient, 1);
            TBPV1SetpointLow.Text = list[0];
            TBPV1SetpointHigh.Text = list[1];
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Globals.CONNECTION)
            {
                try
                {
                    adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);
                    DialMappingValue();
                    Decode(adsClient);
                    DialEventHandler();
                }
                catch { }
            }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (Globals.CONNECTION)
            {
                adsClient.Disconnect();
                adsClient.Dispose();
            }
        }
        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("105,113,923");

                Save.Content = hashtable[105].ToString();

                PV1DialTitle.Text = hashtable[923].ToString();

                PV1Dial.Title = hashtable[113].ToString();

                //CurrentPV1PowerText.Text = hashtable[112].ToString() + " (K)";

                //TBPV1SetpointLowText.Text = hashtable[112].ToString() + " (kPa)";
                //TBPV1SetpointHighText.Text = hashtable[112].ToString() + " (kPa)";
            }
            catch { }
        }
    }
}
