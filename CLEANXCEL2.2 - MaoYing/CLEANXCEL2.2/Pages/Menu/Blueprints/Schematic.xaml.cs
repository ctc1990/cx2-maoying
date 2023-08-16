using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Pages.Menu.Blueprints
{
    /// <summary>
    /// Interaction logic for Schematics.xaml
    /// </summary>
    public partial class Schematic : Page
    {
        private bool leftClamp = false, rightClamp = false, leftUnclamp = false, rightUnclamp = false;
        List<Mapping> mapping = new List<Mapping>();
        private static AdsStream adsDataStream;
        private static BinaryReader binRead;
        private TcAdsClient adsClient = new TcAdsClient();
        private static int[] hconnect;

        public Schematic()
        {
            InitializeComponent();
        }

        private void Viewbox_Loaded(object sender, RoutedEventArgs e)
        {
            if (Globals.CONNECTION)
            {
                try
                {
                    adsDataStream = new AdsStream(mapping.Count());
                    hconnect = new int[mapping.Count()];

                    binRead = new BinaryReader(adsDataStream, Encoding.ASCII);

                    adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);

                    for (int i = 0; i < mapping.Count(); i++)
                    {
                        hconnect[i] = adsClient.AddDeviceNotification(mapping[i].input, adsDataStream, i, 1, AdsTransMode.OnChange, 50, 0, null);
                    }

                    adsClient.AdsNotification += new AdsNotificationEventHandler(StatusOnChange);
                }
                catch
                {

                }
            }
        }

        private void StatusOnChange(object sender, AdsNotificationEventArgs e)
        {
            for (int i = 0; i < mapping.Count(); i++)
            {
                if (e.NotificationHandle == hconnect[i])
                {
                    try
                    {
                        switch (mapping[i].input)
                        {
                            case ".X102_08":
                                leftClamp = binRead.ReadBoolean();
                                mapping[i].button.IsChecked = QuadState2Conditions(leftClamp, rightClamp, leftUnclamp, rightUnclamp);
                                break;
                            case ".X102_10":
                                rightClamp = binRead.ReadBoolean();
                                mapping[i].button.IsChecked = QuadState2Conditions(leftClamp, rightClamp, leftUnclamp, rightUnclamp);
                                break;
                            case ".X102_09":
                                leftUnclamp = binRead.ReadBoolean();
                                mapping[i].button.IsChecked = QuadState2Conditions(leftClamp, rightClamp, leftUnclamp, rightUnclamp);
                                break;
                            case ".X102_11":
                                rightUnclamp = binRead.ReadBoolean();
                                mapping[i].button.IsChecked = QuadState2Conditions(leftClamp, rightClamp, leftUnclamp, rightUnclamp);
                                break;
                            case ".X101_03":
                                if (binRead.ReadBoolean())
                                    mapping[i].button.IsChecked = true;
                                break;
                            case ".X101_04":
                                if (binRead.ReadBoolean())
                                    mapping[i].button.IsChecked = false;
                                break;
                            case ".X101_05":
                            case ".X101_11":
                            case ".X101_15":
                            case ".Y103_02":
                                mapping[i].button.IsChecked = !binRead.ReadBoolean();
                                break;
                            default:
                                mapping[i].button.IsChecked = binRead.ReadBoolean();
                                break;
                        }
                    }
                    catch (Exception ex) { Debug.WriteLine("Pages/Maintenance/Schematics : " + ex.Message); }
                }
            }
        }

        private static bool? QuadState2Conditions(bool condition1, bool condition2, bool condition3, bool condition4)
        {
            if (condition1 && condition2)
                return true;
            else if (condition3 && condition4)
                return false;
            else
                return null;
        }

        struct Mapping
        {
            public ToggleButton button;
            public string output;
            public string input;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
            InitiateMapping();
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("109,116,117,145,196,197,198,199,200,201,202,203,204,265,266,267,923");

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
                Clamp.Content = hashtable[117].ToString();
                Lamp.Content = hashtable[204].ToString();
                JogModeTitle.Text = hashtable[265].ToString();
                JogDoorOpen.Content = hashtable[266].ToString();
                JogDoorClose.Content = hashtable[267].ToString();
            }
            catch { }
        }

        private void JogMode_PreviewTouchUp(object sender, TouchEventArgs e)
        {
            Button button = sender as Button;

            switch(button.Name)
            {
                case "JogDoorOpen":
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".WY10015_07", "false", "bool");
                    break;
                case "JogDoorClose":
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".WY10014_07", "false", "bool");
                    break;
            }
        }

        private void JogMode_PreviewTouchDown(object sender, TouchEventArgs e)
        {
            Button button = sender as Button;

            switch (button.Name)
            {
                case "JogDoorOpen":
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".WY10015_07", "true", "bool");
                    break;
                case "JogDoorClose":
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".WY10014_07", "true", "bool");
                    break;
            }
        }

        private void InitiateMapping()
        {
            mapping.Add(new Mapping { button = CH1, input = ".Y100_06", output = ".WY10006_15" });
            mapping.Add(new Mapping { button = AV1_1, input = ".Y101_00", output = ".WY10100_15" });
            mapping.Add(new Mapping { button = AV1_2, input = ".Y101_01", output = ".WY10101_15" });
            mapping.Add(new Mapping { button = AV1_3, input = ".Y101_02", output = ".WY10102_15" });
            mapping.Add(new Mapping { button = AV1_4, input = ".Y101_03", output = ".WY10103_15" });
            mapping.Add(new Mapping { button = AV1_5, input = ".Y101_04", output = ".WY10104_15" });
            mapping.Add(new Mapping { button = AV1_6, input = ".Y101_05", output = ".WY10105_15" });
            mapping.Add(new Mapping { button = AV1_7, input = ".Y101_06", output = ".WY10106_15" });
            mapping.Add(new Mapping { button = AV1_8, input = ".Y101_07", output = ".WY10107_15" });
            mapping.Add(new Mapping { button = AV1_9, input = ".Y101_08", output = ".WY10108_15" });
            mapping.Add(new Mapping { button = AV1_10, input = ".Y101_09", output = ".WY10109_15" });
            mapping.Add(new Mapping { button = AV1_11, input = ".Y101_10", output = ".WY10110_15" });
            mapping.Add(new Mapping { button = AV1_12, input = ".Y101_11", output = ".WY10111_15" });
            mapping.Add(new Mapping { button = AV1_13, input = ".Y101_12", output = ".WY10112_15" });
            mapping.Add(new Mapping { button = AV1_14, input = ".Y101_13", output = ".WY10113_15" });
            mapping.Add(new Mapping { button = AV1_15, input = ".Y101_14", output = ".WY10114_15" });
            mapping.Add(new Mapping { button = AV1_16, input = ".Y101_15", output = ".WY10115_15" });
            mapping.Add(new Mapping { button = AV1_17, input = ".Y102_00", output = ".WY10200_15" });
            mapping.Add(new Mapping { button = Lamp, input = ".Y102_12", output = ".WY10212_15" });
            mapping.Add(new Mapping { button = AV1_18, input = ".Y103_00", output = ".WY10300_15" });
            mapping.Add(new Mapping { button = AV1_19, input = ".Y103_01", output = ".WY10301_15" });
            mapping.Add(new Mapping { button = AV1_20, input = ".Y103_02", output = ".WY10302_15" });
            mapping.Add(new Mapping { button = AV1_21, input = ".Y103_03", output = ".WY10303_15" });
            mapping.Add(new Mapping { button = AV1_22, input = ".Y103_04", output = ".WY10304_15" });
            mapping.Add(new Mapping { button = AV1_23, input = ".Y103_05", output = ".WY10305_15" });
            mapping.Add(new Mapping { button = AV1_24, input = ".Y103_06", output = ".WY10306_15" });
            mapping.Add(new Mapping { button = AV1_25, input = ".Y103_07", output = ".WY10307_15" });
            mapping.Add(new Mapping { button = AV1_26, input = ".Y103_08", output = ".WY10308_15" });
            mapping.Add(new Mapping { button = P1, input = ".Y100_10", output = ".WY10010_15" });
            mapping.Add(new Mapping { button = US, input = "ManualButtonControl.Y100_08_Y102_11", output = ".WY10008_15" });               // original input signal = .Y100_08
            mapping.Add(new Mapping { button = H1, input = ".Y100_11", output = ".WY10011_15" });
            mapping.Add(new Mapping { button = H2, input = ".Y100_12", output = ".WY10012_15" });
            mapping.Add(new Mapping { button = H3, input = ".Y100_13", output = ".WY10013_15" });
            mapping.Add(new Mapping { button = SV1_1, input = ".Y102_01", output = ".WY10201_15" });
            mapping.Add(new Mapping { button = PV1, input = ".Y100_09", output = ".WY10009_15" });
            mapping.Add(new Mapping { button = Clamp, input = ".X102_08", output = ".WY10206_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Clamp, input = ".X102_10", output = ".WY10206_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Clamp, input = ".X102_09", output = ".WY10207_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Clamp, input = ".X102_11", output = ".WY10207_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Door, input = ".X101_03", output = ".WY10014_15" }); //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)
            mapping.Add(new Mapping { button = Door, input = ".X101_04", output = ".WY10015_15" }); //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)
            //mapping.Add(new Mapping { button = Circulation, input = ".wPumpCircFunction", output = ".wPumpCircFunction" });
            //mapping.Add(new Mapping { button = SolventTopUp, input = ".wSolventTopupFunction.15", output = ".wSolventTopupFunction.15" });

            // Level Sensor
            mapping.Add(new Mapping { button = ProcessChamber_Reg, input = ".X101_00", output = ".X101_00" });
            mapping.Add(new Mapping { button = ProcessChamber_Min, input = ".X101_01", output = ".X101_01" });
            mapping.Add(new Mapping { button = ProcessChamber_Empty, input = ".X101_02", output = ".X101_02" });
            mapping.Add(new Mapping { button = StorageTank1_Min, input = ".X101_08", output = ".X101_08" });
            mapping.Add(new Mapping { button = StorageTank1_TopUp, input = ".X101_07", output = ".X101_07" });
            mapping.Add(new Mapping { button = StorageTank1_Reg, input = ".X101_06", output = ".X101_06" });
            mapping.Add(new Mapping { button = StorageTank1_Max, input = ".X101_05", output = ".X101_05" });
            mapping.Add(new Mapping { button = StorageTank2_Min, input = ".X101_09", output = ".X101_09" });
            mapping.Add(new Mapping { button = WaterSeparator_Min, input = ".X101_10", output = ".X101_10" });
            mapping.Add(new Mapping { button = DistillationTank_Min, input = ".X101_14", output = ".X101_14" });
            mapping.Add(new Mapping { button = DistillationTank_TopUp, input = ".X101_13", output = ".X101_13" });
            mapping.Add(new Mapping { button = DistillationTank_Reg, input = ".X101_12", output = ".X101_12" });
            mapping.Add(new Mapping { button = DistillationTank_Max, input = ".X101_11", output = ".X101_11" });
            mapping.Add(new Mapping { button = SolventRecoveryUnit_Max, input = ".X101_15", output = ".X101_15" });
        }

        private void EquipmentTrigger_Click(object sender, RoutedEventArgs e)
        {
            ToggleButton toggleButton = (ToggleButton)sender;
            bool? state = toggleButton.IsChecked;

            if (Globals.CONNECTION)
            {
                switch (toggleButton.Name)
                {
                    case "Door":
                        if (toggleButton.IsChecked == true)
                        {
                            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).First().output, "true", "bool");
                        }
                        else
                        {
                            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).ElementAt(1).output, "true", "bool");
                        }
                        toggleButton.IsChecked = null;
                        break;
                    case "Clamp":
                        if (toggleButton.IsChecked == true)
                        {
                            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).ElementAt(2).output, "false", "bool");
                            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).First().output, "true", "bool");
                        }
                        else
                        {
                            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).First().output, "false", "bool");
                            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).ElementAt(2).output, "true", "bool");
                        }
                        toggleButton.IsChecked = null;
                        break;
                    case "Circulation":
                    case "SolventTopUp":
                        break;
                    case "AV1_20":
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).First().output, (!toggleButton.IsChecked).ToString(), "bool");

                        if (toggleButton.IsChecked != false)
                            toggleButton.IsChecked = null;
                        break;
                    default:
                        Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, mapping.Where(x => x.button == toggleButton).First().output, toggleButton.IsChecked.ToString(), "bool");

                        if (toggleButton.IsChecked != false)
                            toggleButton.IsChecked = null;
                        break;
                }
            }

        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            //Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bManualModeOn", "false", "bool");
            //Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bManualModeOnPB", "false", "bool");
            //Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bManualModeOnLatch", "false", "bool");
            if (Globals.CONNECTION)
            {
                adsClient.Disconnect();
                adsClient.Dispose();
            }
        }
    }
}
