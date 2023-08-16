using System;
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

namespace CLEANXCEL2._2.Pages.Menu.CurrentStatus
{
    /// <summary>
    /// Interaction logic for Schematics.xaml
    /// </summary>
    public partial class Schematics : Page
    {
        List<Mapping> mapping = new List<Mapping>();
        private static AdsStream adsDataStream;
        private static BinaryReader binRead;
        private static bool[] bitMap;
        private TcAdsClient adsClient = new TcAdsClient();
        private static int[] hconnect;

        public Schematics()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            InitiateMapping();
        }

        private void Frame_Loaded(object sender, RoutedEventArgs e)
        {

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
                    bitMap = new bool[mapping.Count()];

                    binRead = new BinaryReader(adsDataStream, Encoding.ASCII);

                    adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);
                    for (int i = 0; i < mapping.Count(); i++)
                        hconnect[i] = adsClient.AddDeviceNotification(mapping[i].input, adsDataStream, i, 1, AdsTransMode.OnChange, 50, 0, null);

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
                    switch (mapping[i].input)
                    {
                        case ".X101_03":
                            if (binRead.ReadBoolean())
                                ((ToggleButton)mapping[i].button).IsChecked = false;
                            break;
                        case ".X101_04":
                            if (binRead.ReadBoolean())
                                ((ToggleButton)mapping[i].button).IsChecked = true;
                            break;
                        default:
                            ((ToggleButton)mapping[i].button).IsChecked = binRead.ReadBoolean();
                            break;
                    }
                }
            }
        }

        struct Mapping
        {
            public UIElement button;
            public string output;
            public string input;
        }

        private void InitiateMapping()
        {
            //mapping = new List<Mapping>()
            //{
            //    new Mapping { button = CH1, input = ".Y100_06", output = ".WY10006_15" },
            //    new Mapping { button = AV1_1, input = ".Y101_00", output = ".WY10100_15" },
            //    new Mapping { button = AV1_2, input = ".Y101_01", output = ".WY10101_15" },
            //    new Mapping { button = AV1_3, input = ".Y101_02", output = ".WY10102_15" },
            //    new Mapping { button = AV1_4, input = ".Y101_03", output = ".WY10103_15" },
            //    new Mapping { button = AV1_5, input = ".Y101_04", output = ".WY10104_15" },
            //    new Mapping { button = AV1_6, input = ".Y101_05", output = ".WY10105_15" },
            //    new Mapping { button = AV1_7, input = ".Y101_06", output = ".WY10106_15" },
            //    new Mapping { button = AV1_8, input = ".Y101_07", output = ".WY10107_15" },
            //    new Mapping { button = AV1_9, input = ".Y101_08", output = ".WY10108_15" },
            //    new Mapping { button = AV1_10, input = ".Y101_09", output = ".WY10109_15" },
            //    new Mapping { button = AV1_11, input = ".Y101_10", output = ".WY10110_15" },
            //    new Mapping { button = AV1_12, input = ".Y101_11", output = ".WY10111_15" },
            //    new Mapping { button = AV1_13, input = ".Y101_12", output = ".WY10112_15" },
            //    new Mapping { button = AV1_14, input = ".Y101_13", output = ".WY10113_15" },
            //    new Mapping { button = AV1_15, input = ".Y101_14", output = ".WY10114_15" },
            //    new Mapping { button = AV1_16, input = ".Y101_15", output = ".WY10115_15" },
            //    new Mapping { button = AV1_17, input = ".Y102_00", output = ".WY10200_15" },
            //    new Mapping { button = P1, input = ".Y100_10", output = ".WY10010_15" },
            //    new Mapping { button = US, input = ".Y100_08", output = ".WY10008_15" },
            //    new Mapping { button = H1, input = ".Y100_11", output = ".WY10011_15" },
            //    new Mapping { button = H2, input = ".Y100_12", output = ".WY10012_15" },
            //    new Mapping { button = H3, input = ".Y100_13", output = ".WY10013_15" },
            //    new Mapping { button = SV1_1, input = ".Y102_01", output = ".WY10201_15" },
            //    //new Mapping { button = SV1_2, input = ".", output = "." },
            //    //new Mapping { button = SV1_3, input = ".", output = "." },
            //    new Mapping { button = PV1, input = ".Y100_09", output = ".WY10009_15" },
            //    new Mapping { button = Door, input = ".X101_03", output = ".WY10015_15" }, //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)
            //    new Mapping { button = Door, input = ".X101_04", output = ".WY10014_15" } //Open = .WY10015_15 (.X101_03), Close = .WY10014_15 (.X101_04)
            //    //new Mapping { button = DigitalDisplay1, input = ".ARrStnTempPV[1]", output = ".ARrStnTempSV[1]" },
            //    //new Mapping { button = DigitalDisplay2, input = ".ARrStnTempPV[2]", output = ".ARrStnTempSV[2]" },
            //    //new Mapping { button = DigitalDisplay3, input = ".ARrStnTempPV[3]", output = ".ARrStnTempSV[3]" },
            //    //new Mapping { button = DigitalDisplay4, input = ".ARrStnTempPV[4]", output = ".ARrStnTempSV[4]" },
            //    //new Mapping { button = DigitalDisplay5, input = ".ARrStnTempPV[5]", output = ".ARrStnTempSV[5]" },
            //    //new Mapping { button = DigitalDisplay6, input = ".ARrStnTempPV[6]", output = ".ARrStnTempSV[6]" },
            //    //new Mapping { button = DigitalDisplay6, input = ".ARrStnVacuumPV[1]", output = ".ARrStnVacuumPV[1]" },
            //    //new Mapping { button = DigitalDisplay7, input = ".ARiStnUSSideAPv[1]", output = ".ARiStnManualUSBtmAsv[1]" },
            //    //new Mapping { button = DigitalDisplay7, input = ".DSWeberEnclosure[1].DSWeberGenerator[1].IN_iFreqSetPoint", output = ".DSWeberEnclosure[1].DSWeberGenerator[1].DSWeberMulFreqSwitching.iFreqOutput_TS" }
            //};
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            if (Globals.CONNECTION)
            {
                adsClient.Disconnect();
                adsClient.Dispose();
            }
        }
    }
}
