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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Pages.Menu.Maintenance
{
    /// <summary>
    /// Interaction logic for Schematics.xaml
    /// </summary>
    public partial class Schematics : Page
    {
        private bool leftClamp = false, rightClamp = false, leftUnclamp = false, rightUnclamp = false;
        List<Mapping> mapping = new List<Mapping>();
        private static AdsStream adsDataStream;
        private static BinaryReader binRead;
        private TcAdsClient adsClient = new TcAdsClient();
        private static int[] hconnect;

        public Schematics()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitiateMapping();
            LoadLanguage();
        }

        private void Viewbox_Loaded(object sender, RoutedEventArgs e)
        {
            FrameSensor.Source = new Uri("../Maintenance/Sensor.xaml", UriKind.RelativeOrAbsolute);
            if (Globals.CONNECTION)
            {
                try
                {
                    adsDataStream = new AdsStream(mapping.Count());
                    hconnect = new int[mapping.Count()];

                    binRead = new BinaryReader(adsDataStream, Encoding.ASCII);

                    adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);

                    for (int i = 0; i < mapping.Count() - 2; i++)
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
                                    mapping[i].button.IsChecked = false;
                                break;
                            case ".X101_04":
                                if (binRead.ReadBoolean())
                                    mapping[i].button.IsChecked = true;
                                break;
                            default:
                                mapping[i].button.IsChecked = binRead.ReadBoolean();
                                break;
                        }
                    }
                    catch (Exception ex) { Debug.WriteLine( "Pages/Maintenance/Schematics : " + ex.Message); }
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
            mapping.Add(new Mapping { button = P1, input = ".Y100_10", output = ".WY10010_15" });
            mapping.Add(new Mapping { button = US, input = ".Y100_08", output = ".WY10008_15" });
            mapping.Add(new Mapping { button = H1, input = ".Y100_11", output = ".WY10011_15" });
            mapping.Add(new Mapping { button = H2, input = ".Y100_12", output = ".WY10012_15" });
            mapping.Add(new Mapping { button = H3, input = ".Y100_13", output = ".WY10013_15" });
            mapping.Add(new Mapping { button = SV1_1, input = ".Y102_01", output = ".WY10201_15" });
            //mapping.Add(new Mapping { button = SV1_2, input = ".", output = "." });
            //mapping.Add(new Mapping { button = SV1_3, input = ".", output = "." });
            mapping.Add(new Mapping { button = PV1, input = ".Y100_09", output = ".WY10009_15" });
            mapping.Add(new Mapping { button = Clamp, input = ".X102_08", output = ".WY10206_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Clamp, input = ".X102_10", output = ".WY10206_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Clamp, input = ".X102_09", output = ".WY10207_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Clamp, input = ".X102_11", output = ".WY10207_15" }); //Clamp = .WY10206_15 (.X102_08, .X102_10), Unclamp = .WY10207_15 (.X102_09, .X102_11)
            mapping.Add(new Mapping { button = Door, input = ".X101_04", output = ".WY10014_15" }); //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)
            mapping.Add(new Mapping { button = Door, input = ".X101_03", output = ".WY10015_15" }); //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)
            mapping.Add(new Mapping { button = Circulation, input = ".wPumpCircFunction", output = ".wPumpCircFunction" });
            mapping.Add(new Mapping { button = SolventTopUp, input = ".wSolventTopupFunction.15", output = ".wSolventTopupFunction.15" });
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
                        break;
                    case "Circulation":
                    case "SolventTopUp":
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

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("117,118,119");

                Clamp.Content = hashtable[117].ToString();
                Circulation.Content = hashtable[118].ToString();
                SolventTopUp.Content = hashtable[119].ToString();
            }
            catch (NullReferenceException) { }
        }
    }
}
