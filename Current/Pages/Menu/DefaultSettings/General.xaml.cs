using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Interaction logic for General.xaml
    /// </summary>
    public partial class General : Page
    {
        TcAdsClient adsClient = new TcAdsClient();
        Hashtable hashtableValue = new Hashtable();

        public General()
        {
            InitializeComponent();
        }

        protected void TempDial_AmountChanged(object sender, EventArgs e)
        {
            double TotalAmount = (double)((UserControls.Dial)sender).Amount;
            ((TextBlock)hashtableValue[(UserControls.Dial)sender]).Text = (TotalAmount + 273).ToString();
        }

        protected void PressureDial_AmountChanged(object sender, EventArgs e)
        {
            double TotalAmount = (double)((UserControls.Dial)sender).Amount;
            TotalAmount = Math.Round(TotalAmount * 10);
            ((TextBlock)hashtableValue[(UserControls.Dial)sender]).Text = TotalAmount.ToString();
        }

        private void DialEventHandler()
        {
            //H1Dial.AmountChanged += new EventHandler(TempDial_AmountChanged);
            //H2Dial.AmountChanged += new EventHandler(TempDial_AmountChanged);
            //H3Dial.AmountChanged += new EventHandler(TempDial_AmountChanged);
            //H4Dial.AmountChanged += new EventHandler(TempDial_AmountChanged);
            //CH1Dial.AmountChanged += new EventHandler(TempDial_AmountChanged);
            //PV1Dial.AmountChanged += new EventHandler(PressureDial_AmountChanged);
        }

        private void DialMappingValue()
        {
            //hashtableValue.Add(H1Dial, CurrentH1Power);
            //hashtableValue.Add(H2Dial, CurrentH2Power);
            //hashtableValue.Add(H3Dial, CurrentH3Power);
            //hashtableValue.Add(H4Dial, CurrentH4Power);
            //hashtableValue.Add(CH1Dial, CurrentCH1Power);
            //hashtableValue.Add(PV1Dial, CurrentPV1Power);
        }

        private void SaveSettings_Click(object sender, RoutedEventArgs e)
        {
            Globals.currentPage = "General";
            Globals.POPUP_URL = "../Pages/Window/WindowsMessageBox.xaml";
            Globals.POPUP_REQUEST("51", "52", Window.WindowsMessageBox.State.Confirmation);
        }

        public void TriggerProcess()
        {
            Globals.currentPage = null;
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";

            if (Globals.CONNECTION)
            {
                Encode(adsClient);
                Decode(adsClient);
            }
        }

        private void Encode(TcAdsClient adsClient)
        {
            Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Heater
                (adsClient, 2, H1Dial.Amount.ToString(), H1FirstAlarm.Text, H1SecondAlarm.Text, H1HysterAlarm.Text, H1PreTempAlarm.Text, H1PreTimeAlarm.Text);

            Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Heater
                (adsClient, 3, H2Dial.Amount.ToString(), H2FirstAlarm.Text, H2SecondAlarm.Text, H2HysterAlarm.Text, H2PreTempAlarm.Text, H2PreTimeAlarm.Text);

            Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Heater
                (adsClient, 4, H3Dial.Amount.ToString(), H3FirstAlarm.Text, H3SecondAlarm.Text, H3HysterAlarm.Text, H3PreTempAlarm.Text, H3PreTimeAlarm.Text);

            Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Heater
                (adsClient, 5, H3Dial.Amount.ToString(), H3FirstAlarm.Text, H3SecondAlarm.Text, H3HysterAlarm.Text, H3PreTempAlarm.Text, H3PreTimeAlarm.Text);

            //Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Heater
            //    (adsClient, 5, H4Dial.Amount.ToString(), H4FirstAlarm.Text, H4SecondAlarm.Text, H4HysterAlarm.Text, H4PreTempAlarm.Text, H4PreTimeAlarm.Text);

            //Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Heater
            //    (adsClient, 6, CH1Dial.Amount.ToString(), CH1FirstAlarm.Text, CH1SecondAlarm.Text, CH1HysterAlarm.Text, CH1PreTempAlarm.Text, CH1PreTimeAlarm.Text);

            Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Heater
                (adsClient, 6, "0", CH1Dial.Amount.ToString(), CH1Dial.Amount.ToString(), "0", "0", "0");

            Controllers.RecipeManagement.API.Equipment_Settings.UploadSettings_Pressure(adsClient, 1, TBPV1SetpointLow.Text, TBPV1SetpointHigh.Text);
        }

        private void Decode(TcAdsClient adsClient)
        {
            List<string> list = new List<string>();

            list = Controllers.RecipeManagement.API.Equipment_Settings.DownloadSettings_Heater(adsClient, 2);
            H1Dial.ChangeAmount(Convert.ToInt32(list[0]));
            H1FirstAlarm.Text = list[1];
            H1SecondAlarm.Text = list[2];
            H1HysterAlarm.Text = list[3];
            H1PreTempAlarm.Text = list[4];
            H1PreTimeAlarm.Text = list[5];

            list = Controllers.RecipeManagement.API.Equipment_Settings.DownloadSettings_Heater(adsClient, 3);
            H2Dial.ChangeAmount(Convert.ToInt32(list[0]));
            H2FirstAlarm.Text = list[1];
            H2SecondAlarm.Text = list[2];
            H2HysterAlarm.Text = list[3];
            H2PreTempAlarm.Text = list[4];
            H2PreTimeAlarm.Text = list[5];

            list = Controllers.RecipeManagement.API.Equipment_Settings.DownloadSettings_Heater(adsClient, 4);
            H3Dial.ChangeAmount(Convert.ToInt32(list[0]));
            H3FirstAlarm.Text = list[1];
            H3SecondAlarm.Text = list[2];
            H3HysterAlarm.Text = list[3];
            H3PreTempAlarm.Text = list[4];
            H3PreTimeAlarm.Text = list[5];

            list = Controllers.RecipeManagement.API.Equipment_Settings.DownloadSettings_Heater(adsClient, 5);
            H4Dial.ChangeAmount(Convert.ToInt32(list[0]));
            H4FirstAlarm.Text = list[1];
            H4SecondAlarm.Text = list[2];
            H4HysterAlarm.Text = list[3];
            H4PreTempAlarm.Text = list[4];
            H4PreTimeAlarm.Text = list[5];

            list = Controllers.RecipeManagement.API.Equipment_Settings.DownloadSettings_Heater(adsClient, 6);
            CH1Dial.ChangeAmount(Convert.ToInt32(list[2]));
            //CH1FirstAlarm.Text = list[1];
            //CH1SecondAlarm.Text = list[2];
            //CH1HysterAlarm.Text = list[3];
            //CH1PreTempAlarm.Text = list[4];
            //CH1PreTimeAlarm.Text = list[5];
            
            list = Controllers.RecipeManagement.API.Equipment_Settings.DownloadSettings_Pressure(adsClient, 1);
            TBPV1SetpointLow.Text = list[0];
            TBPV1SetpointHigh.Text = list[1];
        }

        private void EquipmentTrigger_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = sender as ToggleButton;

            SetButtonStatus(false);
            toggleButton.IsChecked = true;
            SetDockVisibility(Visibility.Hidden);
            ((DockPanel)FindName(toggleButton.Name + "Dock")).Visibility = Visibility.Visible;
        }

        private void SetButtonStatus(bool status)
        {
            H1.IsChecked = status;
            H2.IsChecked = status;
            H3.IsChecked = status;
            CH1.IsChecked = status;
            PV1.IsChecked = status;
        }

        private void SetDockVisibility(Visibility visibility)
        {
            H1Dock.Visibility = visibility;
            H2Dock.Visibility = visibility;
            H3Dock.Visibility = visibility;
            H4Dock.Visibility = visibility;
            CH1Dock.Visibility = visibility;
            PV1Dock.Visibility = visibility;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();

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
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("105,108,109,110,111,112,113,114,116,,120,121,122,123,124,145,196,197,198,199,200,201,202,203,919,923,926");

                Save.Content = hashtable[105].ToString();

                H1DialTitle.Text = hashtable[108].ToString() + " 1 " + hashtable[919].ToString();
                H2DialTitle.Text = hashtable[108].ToString() + " 2 " + hashtable[919].ToString();
                H3DialTitle.Text = hashtable[109].ToString() + " " + hashtable[919].ToString() + " (" + hashtable[110].ToString() + ")";
                H4DialTitle.Text = hashtable[109].ToString() + " " + hashtable[919].ToString() + " (" + hashtable[111].ToString() + ")";
                CH1DialTitle.Text = hashtable[926].ToString();
                PV1DialTitle.Text = hashtable[923].ToString();


                H1Dial.Title = hashtable[112].ToString();
                H2Dial.Title = hashtable[112].ToString();
                H3Dial.Title = hashtable[112].ToString();
                H4Dial.Title = hashtable[112].ToString();
                CH1Dial.Title = hashtable[121].ToString();
                PV1Dial.Title = hashtable[113].ToString();

                //CurrentH1PowerText.Text = hashtable[112].ToString() + " (K)";
                //CurrentH2PowerText.Text = hashtable[112].ToString() + " (K)";
                //CurrentH3PowerText.Text = hashtable[112].ToString() + " (K)";
                //CurrentH4PowerText.Text = hashtable[112].ToString() + " (K)";
                //CurrentCH1PowerText.Text = hashtable[112].ToString() + " (K)";

                H1FirstAlarmTitle.Text = hashtable[120].ToString();
                H2FirstAlarmTitle.Text = hashtable[120].ToString();
                H3FirstAlarmTitle.Text = hashtable[120].ToString();
                H4FirstAlarmTitle.Text = hashtable[120].ToString();
                //CH1FirstAlarmTitle.Text = hashtable[120].ToString();

                H1SecondAlarmTitle.Text =  hashtable[121].ToString();
                H2SecondAlarmTitle.Text =  hashtable[121].ToString();
                H3SecondAlarmTitle.Text =  hashtable[121].ToString();
                H4SecondAlarmTitle.Text =  hashtable[121].ToString();
                //CH1SecondAlarmTitle.Text = hashtable[121].ToString();
                CH1Dial.Title = hashtable[121].ToString();

                H1HysterAlarmTitle.Text = hashtable[122].ToString();
                H2HysterAlarmTitle.Text = hashtable[122].ToString();
                H3HysterAlarmTitle.Text = hashtable[122].ToString();
                H4HysterAlarmTitle.Text = hashtable[122].ToString();
                //CH1HysterAlarmTitle.Text = hashtable[122].ToString();

                H1PreTempAlarmTitle.Text = hashtable[123].ToString();
                H2PreTempAlarmTitle.Text = hashtable[123].ToString();
                H3PreTempAlarmTitle.Text = hashtable[123].ToString();
                H4PreTempAlarmTitle.Text = hashtable[123].ToString();
                //CH1PreTempAlarmTitle.Text = hashtable[123].ToString();

                H1PreTimeAlarmTitle.Text = hashtable[124].ToString();
                H2PreTimeAlarmTitle.Text = hashtable[124].ToString();
                H3PreTimeAlarmTitle.Text = hashtable[124].ToString();
                H4PreTimeAlarmTitle.Text = hashtable[124].ToString();
                //CH1PreTimeAlarmTitle.Text = hashtable[124].ToString();

                DistillationTank.Text = hashtable[109].ToString();
                ProcessChamber.Text = hashtable[116].ToString();
                SourceCDASupply.Text = hashtable[145].ToString();
                VacuumPump.Text = hashtable[923].ToString();
                ReservoirTank.Text = hashtable[196].ToString();
                WaterSeparator.Text = hashtable[197].ToString();
                StorageTank1.Text = hashtable[198].ToString();
                StorageTank2.Text = hashtable[199].ToString();
                Refrigerator.Text = hashtable[200].ToString();
                CentrifugalPump.Text = hashtable[201].ToString();
                AirPump.Text = hashtable[202].ToString();
                SourceSolventSupply.Text = hashtable[203].ToString();
            }
            catch { }
        }
    }
}
