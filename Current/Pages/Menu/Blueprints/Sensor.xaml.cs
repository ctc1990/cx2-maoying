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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Pages.Menu.Blueprints
{
    /// <summary>
    /// Interaction logic for Sensor.xaml
    /// </summary>
    public partial class Sensor : Page
    {
        private static AdsStream adsDataStream;
        private static BinaryReader binRead;
        private TcAdsClient adsClient = new TcAdsClient();
        private static int[] hconnect;
        Hashtable hashtable = new Hashtable();

        private bool[] VacuumTankLevel = new bool[] { false };
        private bool[] ProcessChamberLevel = new bool[] { false, false, false };
        private bool[] StorageTank1Level = new bool[] { false, false, false, false };
        private bool[] StorageTank2Level = new bool[] { false };
        private bool[] DistillationTankLevel = new bool[] { false, false, false, false };

        private static int[] separator = new int[] { 13, 17 };

        public Sensor()
        {
            InitializeComponent();
        }

        private void StackPanel_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Globals.CONNECTION)
            {
                try
                {
                    adsDataStream = new AdsStream(InputVariable.Count() * 4);
                    binRead = new BinaryReader(adsDataStream, Encoding.ASCII);
                    hconnect = new int[InputVariable.Count()];

                    adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);

                    for (int i = 0; i < InputVariable.Length; i++)
                    {
                        if (i < separator[0])
                            hconnect[i] = adsClient.AddDeviceNotification(InputVariable[i], adsDataStream, i * 4, 4, AdsTransMode.OnChange, 50, 0, null);
                        else if (i<separator[1])
                            hconnect[i] = adsClient.AddDeviceNotification(InputVariable[i], adsDataStream, i * 2, 2, AdsTransMode.OnChange, 50, 0, null);
                        else
                            hconnect[i] = adsClient.AddDeviceNotification(InputVariable[i], adsDataStream, i * 2, 1, AdsTransMode.OnChange, 50, 0, null);
                    }

                    adsClient.AdsNotification += new AdsNotificationEventHandler(StatusOnChange);
                }
                catch
                {

                }
            }
        }

        private void Load()
        {
            ProcessChamberTemperatureDD.EqName = "Process Chamber";
            ProcessChamberTemperatureDD.MeasurementName = "Temperature";
            ProcessChamberTemperatureDD.Unit = "Celcius";
            ProcessChamberTemperatureDD.LogicName = "Level";
            ProcessChamberTemperatureDD.Logic = "";
            ProcessChamberTemperatureDD.ValueSet = "50.00";
            ProcessChamberTemperatureDD.ActualValue = 49.67;

            ChillerOutletTemperatureDD.EqName = "Chiller";
            ChillerOutletTemperatureDD.MeasurementName = "Temperature";
            ChillerOutletTemperatureDD.Unit = "Celcius";
            ChillerOutletTemperatureDD.ValueSet = "0.00";
            ChillerOutletTemperatureDD.ActualValue = 0.00;

            StorageTank1TemperatureDD.EqName = "Storage Tank 1";
            StorageTank1TemperatureDD.MeasurementName = "Temperature";
            StorageTank1TemperatureDD.Unit = "Celcius";
            StorageTank1TemperatureDD.LogicName = "Level";
            StorageTank1TemperatureDD.Logic = "";
            StorageTank1TemperatureDD.ValueSet = "50.00";
            StorageTank1TemperatureDD.ActualValue = 49.50;

            StorageTank2TemperatureDD.EqName = "Storage Tank 2";
            StorageTank2TemperatureDD.MeasurementName = "Temperature";
            StorageTank2TemperatureDD.Unit = "Celcius";
            StorageTank2TemperatureDD.LogicName = "Level";
            StorageTank2TemperatureDD.Logic = "";
            StorageTank2TemperatureDD.ValueSet = "50.00";
            StorageTank2TemperatureDD.ActualValue = 49.16;

            DistillationTankTopTemperatureDD.EqName = "Distillation Tank";
            DistillationTankTopTemperatureDD.Location = "Top";
            DistillationTankTopTemperatureDD.MeasurementName = "Temperature";
            DistillationTankTopTemperatureDD.Unit = "Celcius";
            DistillationTankTopTemperatureDD.LogicName = "Level";
            DistillationTankTopTemperatureDD.Logic = "";
            DistillationTankTopTemperatureDD.ValueSet = "50.00";
            DistillationTankTopTemperatureDD.ActualValue = 49.78;

            DistillationTankBottomTemperatureDD.EqName = "Distillation Tank";
            DistillationTankBottomTemperatureDD.Location = "Bottom";
            DistillationTankBottomTemperatureDD.MeasurementName = "Temperature";
            DistillationTankBottomTemperatureDD.Unit = "Celcius";
            DistillationTankBottomTemperatureDD.LogicName = "Level";
            DistillationTankBottomTemperatureDD.Logic = "";
            DistillationTankBottomTemperatureDD.ValueSet = "50.00";
            DistillationTankBottomTemperatureDD.ActualValue = 49.67;

            UltrasonicPowerDD.EqName = "Ultrasonic";
            UltrasonicPowerDD.MeasurementName = "Power";
            UltrasonicPowerDD.Unit = "Percentage";
            UltrasonicPowerDD.ValueSet = "0.00";
            UltrasonicPowerDD.ActualValue = 0.00;

            UltrasonicFrequencyDD.EqName = "Ultrasonic";
            UltrasonicFrequencyDD.MeasurementName = "Frequency";
            UltrasonicFrequencyDD.Unit = "kHz";
            UltrasonicFrequencyDD.ValueSet = "0.00";
            UltrasonicFrequencyDD.ActualValue = 0.00;

            ProcessChamberPressureDD.EqName = "Vacuum Pump";
            ProcessChamberPressureDD.MeasurementName = "Pressure";
            ProcessChamberPressureDD.Unit = "kPa";
            ProcessChamberPressureDD.LogicName = "Level";
            ProcessChamberPressureDD.Logic = "Intermediate";
            ProcessChamberPressureDD.ValueSet = "0.00";
            ProcessChamberPressureDD.ActualValue = 0.00;
        }

        private void StatusOnChange(object sender, AdsNotificationEventArgs e)
        {
            try
            {
                for (int i = 0; i < InputVariable.Count(); i++)
                {

                    if (e.NotificationHandle == hconnect[i])
                    {
                        if (i < separator[0])
                        {
                            double value = binRead.ReadSingle();
                            DecodeValue(i, value);
                        }
                        else if (i< separator[1])
                        {
                            int value = binRead.ReadInt16();
                            DecodeValue(i, value);
                        }
                        else
                        {
                            bool value = binRead.ReadBoolean();
                            DecodeBoolean(i, value);
                        }
                    }
                }
            }
            catch { }
        }

        private void DecodeValue(int index, double status)
        {
            switch (index)
            {
                case 0:
                    ProcessChamberTemperatureDD.ActualValue = status;   // .ARrStnTempPV[1]
                    break;
                case 1:
                    //ProcessChamberTemperatureDD.ValueSet = string.Format("{0:N2}", status);     // .ARrStnTempSV[1]
                    break;
                case 2:
                    ChillerOutletTemperatureDD.ActualValue = status;   // .ARrStnTempPV[2]
                    break;
                case 3:
                    ChillerOutletTemperatureDD.ValueSet = string.Format("{0:N2}", status);     // .ARrStnTempSV[2]
                    break;
                case 4:
                    StorageTank1TemperatureDD.ActualValue = status;   // .ARrStnTempPV[3]
                    break;
                case 5:
                    StorageTank1TemperatureDD.ValueSet = string.Format("{0:N2}", status);     // .ARrStnTempSV[3]
                    break;
                case 6:
                    StorageTank2TemperatureDD.ActualValue = status;   // .ARrStnTempPV[5]
                    break;
                case 7:
                    StorageTank2TemperatureDD.ValueSet = string.Format("{0:N2}", status);     // .ARrStnTempSV[5]
                    break;
                case 8:
                    DistillationTankTopTemperatureDD.ActualValue = status;   // .ARrStnTempPV[4]
                    break;
                case 9:
                    //DistillationTankTopTemperatureDD.ValueSet = string.Format("{0:N2}", status);     // .ARrStnTempSV[4]
                    ReservoirTankPressureDD.ActualValue = status;
                    break;
                case 10:
                    DistillationTankBottomTemperatureDD.ActualValue = status;   // .ARrStnTempPV[6]
                    break;
                case 11:
                    DistillationTankBottomTemperatureDD.ValueSet = string.Format("{0:N2}", status);  // .ARrStnTempSV[6]
                    break;
                case 12:
                    ProcessChamberPressureDD.ActualValue = status;   // .ARrStnVacuumPV[1]
                    break;
                case 13:
                    UltrasonicPowerDD.ActualValue = status;   // .ARiStnUSSideAPv[1]
                    break;
                case 14:
                    UltrasonicPowerDD.ValueSet = string.Format("{0:N2}", status);     // .ARiStnManualUSBtmAsv[1]
                    break;
                case 15:
                    UltrasonicFrequencyDD.ActualValue = status;   // .DSWeberEnclosure[1].DSWeberGenerator[1].IN_iFreqSetPoint
                    break;
                case 16:
                    UltrasonicFrequencyDD.ValueSet = string.Format("{0:N2}", status);  // .DSWeberEnclosure[1].DSWeberGenerator[1].DSWeberMulFreqSwitching.iFreqOutput_TS
                    break;
            }
        }

        private void DecodeBoolean(int index, bool status)
        {
            switch (index)
            {
                case 17:
                    ProcessChamberLevel[2] = status;
                    IndicateLevel3(ProcessChamberLevel, ProcessChamberTemperatureDD);
                    //ProcessChamberTemperatureDD.Logic = hashtable[158].ToString();      // Reg
                    break;
                case 18:
                    ProcessChamberLevel[1] = status;
                    IndicateLevel3(ProcessChamberLevel, ProcessChamberTemperatureDD);
                    //ProcessChamberTemperatureDD.Logic = hashtable[157].ToString();      // Min
                    break;
                case 19:
                    ProcessChamberLevel[0] = status;
                    IndicateLevel3(ProcessChamberLevel, ProcessChamberTemperatureDD);
                    //ProcessChamberTemperatureDD.Logic = hashtable[161].ToString();      // Empty
                    break;
                case 22:
                    StorageTank1Level[0] = status;
                    IndicateLevel4(StorageTank1Level, StorageTank1TemperatureDD);
                    //StorageTank1TemperatureDD.Logic = hashtable[157].ToString();      // Min
                    break;
                case 23:
                    StorageTank1Level[1] = status;
                    IndicateLevel4(StorageTank1Level, StorageTank1TemperatureDD);
                    //StorageTank1TemperatureDD.Logic = hashtable[159].ToString();      // Top
                    break;
                case 24:
                    StorageTank1Level[2] = status;
                    IndicateLevel4(StorageTank1Level, StorageTank1TemperatureDD);
                    //StorageTank1TemperatureDD.Logic = hashtable[158].ToString();      // Reg
                    break;
                case 25:
                    StorageTank1Level[3] = !status;
                    IndicateLevel4(StorageTank1Level, StorageTank1TemperatureDD);
                    //StorageTank1TemperatureDD.Logic = hashtable[160].ToString();      // Max
                    break;
                case 26:
                    StorageTank2Level[0] = status;
                    IndicateLowerLevel1(StorageTank2Level, StorageTank2TemperatureDD);
                    //StorageTank2TemperatureDD.Logic = hashtable[157].ToString();      // Min
                    break;
                case 28:
                    DistillationTankLevel[0] = status;
                    IndicateLevel4(DistillationTankLevel, DistillationTankBottomTemperatureDD);
                    //DistillationTankBottomTemperatureDD.Logic = hashtable[157].ToString();      // Min
                    break;
                case 29:
                    DistillationTankLevel[1] = status;
                    IndicateLevel4(DistillationTankLevel, DistillationTankBottomTemperatureDD);
                    //DistillationTankBottomTemperatureDD.Logic = hashtable[159].ToString();      // Top
                    break;
                case 30:
                    DistillationTankLevel[2] = status;
                    IndicateLevel4(DistillationTankLevel, DistillationTankBottomTemperatureDD);
                    //DistillationTankBottomTemperatureDD.Logic = hashtable[158].ToString();      // Reg
                    break;
                case 31:
                    DistillationTankLevel[3] = !status;
                    IndicateLevel4(DistillationTankLevel, DistillationTankBottomTemperatureDD);
                    //DistillationTankBottomTemperatureDD.Logic = hashtable[160].ToString();      // Max
                    break;
                case 32:
                    VacuumTankLevel[0] = !status;
                    IndicateHigherLevel1(VacuumTankLevel, ProcessChamberPressureDD);
                    //ProcessChamberPressureDD.Logic = hashtable[160].ToString();      // Max
                    break;
            }
            //if (status)
            //{
            //    switch (index)
            //    {
            //        case 20:
            //            // Process Tank Shuttle Top
            //            break;
            //        case 21:
            //            // Process Tank Shuttle Bottom
            //            break;
            //        case 27:
            //            // Water Separator Level
            //            break;
            //    }
            //}
        }

        private void IndicateLowerLevel1(bool[] state, UIElement uiElement)
        {
            UserControls.DigitalDisplay digitalDisplay = (UserControls.DigitalDisplay)uiElement;

            if (state[0])
            {
                digitalDisplay.Logic = hashtable[158].ToString();
            }
            else
                digitalDisplay.Logic = hashtable[161].ToString();
        }

        private void IndicateHigherLevel1(bool[] state, UIElement uiElement)
        {
            UserControls.DigitalDisplay digitalDisplay = (UserControls.DigitalDisplay)uiElement;

            if (state[0])
            {
                digitalDisplay.Logic = hashtable[160].ToString();
            }
            else
                digitalDisplay.Logic = hashtable[158].ToString();
        }

        private void IndicateLevel3(bool[] state, UIElement uiElement)
        {
            UserControls.DigitalDisplay digitalDisplay = (UserControls.DigitalDisplay)uiElement;

            if (state[0])
            {
                if (state[2])
                {
                    digitalDisplay.Logic = hashtable[158].ToString();

                }
                else
                    digitalDisplay.Logic = hashtable[157].ToString();
            }
            else
                digitalDisplay.Logic = hashtable[161].ToString();
        }

        private void IndicateLevel4(bool[] state, UIElement uiElement)
        {
            UserControls.DigitalDisplay digitalDisplay = (UserControls.DigitalDisplay)uiElement;

            if (state[0])
            {
                if (state[1])
                {
                    if (state[2])
                    {
                        if (state[3])
                            digitalDisplay.Logic = hashtable[160].ToString();
                        else
                            digitalDisplay.Logic = hashtable[158].ToString();
                    }
                    else
                        digitalDisplay.Logic = hashtable[159].ToString();
                }
                else
                    digitalDisplay.Logic = hashtable[159].ToString();
                    //digitalDisplay.Logic = hashtable[157].ToString();
            }
            else
                digitalDisplay.Logic = hashtable[157].ToString();
                //digitalDisplay.Logic = hashtable[161].ToString();

        }

        private string[] InputVariable = new string[]
        {
            // Process Chamber
            ".ARrStnTempPV[1]",                                                                     // 0
            ".ARrStnTempSV[1]",                                                                     // 1

            // Chiller 
            ".ARrStnTempPV[6]",                                                                     // 2
            ".ARrStnTempHALsv[6]",                                                                  // 3
            //".ARrStnTempSV[6]",

            // Storage Tank 1
            ".ARrStnTempPV[2]",                                                                     // 4
            ".ARrStnTempSV[2]",                                                                     // 5

            // Storage Tank 2
            ".ARrStnTempPV[3]",                                                                     // 6
            ".ARrStnTempSV[3]",                                                                     // 7

            // Distillation Tank (Top)
            ".ARrStnTempPV[5]",                                                                     // 8
            //".ARrStnTempSV[5]",                                                                     // 9

            // Reservoir Pressure                               
            ".ARrRevVacuumPV[1]",                                                                   // 9

            // Distillation Tank (Bottom)
            ".ARrStnTempPV[4]",                                                                     // 10
            ".ARrStnTempSV[4]",                                                                     // 11

            // Chamber Pressure
            ".ARrStnVacuumPV[1]",                                                                   // 12

            // Ultrasonic Power
            ".ARiUsPowerPV_percent[1]",                                                             // 13
            ".ARDsStnSeqProcessCtrl[1].Out_DSStnSeqProOutput.i3ProTankBtmUsAPwrPercent",            // 14

            // Ultrasonic Frequency
            ".ARDsStnSeqProcessCtrl[1].Out_DSStnSeqProOutput.i8ProTankBtmUsAkHz",                   // 15
            ".ARDsStnSeqProcessCtrl[1].Out_DSStnSeqProOutput.i8ProTankBtmUsAkHz",                   // 16

            // Process Tank
            ".X101_00",                                                                             // 17   - Reg
            ".X101_01",                                                                             // 18   - Min
            ".X101_02",                                                                             // 19   - Fully Drain
            //".X101_03",                                                                             // 20   - Shuttle Top
            //".X101_04",                                                                             // 21   - Shuttle Bot

            // Storage Tank 1 Level
            ".X101_08",                                                                             // 22   - Min
            ".X101_07",                                                                             // 23   - Top
            ".X101_06",                                                                             // 24   - Reg
            ".X101_05",                                                                             // 25   - Max

            // Storage Tank 2 Level
            ".X101_09",                                                                             // 26   - Min

            //// Water Separator Level
            //".X101_10",                                                                             // 27   - Min

            // Distillation Tank Level
            ".X101_14",                                                                             // 28   - Min
            ".X101_13",                                                                             // 29   - Top
            ".X101_12",                                                                             // 30   - Reg
            ".X101_11",                                                                             // 31   - Max

            // Solvent Recovery Unit Level
            ".X101_15",                                                                             // 32   - Max

            // Manual Ultrasonic Value
            //".ARiStnManualUSBtmAsv[1]",
        };

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
                hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("108,109,110,111,112,116,135,136,154,155,156,157,158,159,160,161,162,196,210,921");

                // Process Chamber Temperature
                ProcessChamberTemperatureDD.EqName = hashtable[116].ToString();
                ProcessChamberTemperatureDD.MeasurementName = hashtable[112].ToString();
                ProcessChamberTemperatureDD.Unit = hashtable[155].ToString();
                ProcessChamberTemperatureDD.LogicName = hashtable[154].ToString();
                ProcessChamberTemperatureDD.Logic = hashtable[158].ToString();
                ProcessChamberTemperatureDD.ValueSet = "-";
                ProcessChamberTemperatureDD.ActualValue = 23.67;

                // Process Chamber Pressure
                ProcessChamberPressureDD.EqName = hashtable[116].ToString();
                ProcessChamberPressureDD.MeasurementName = hashtable[156].ToString();
                ProcessChamberPressureDD.Unit = "kPa";
                ProcessChamberPressureDD.LogicName = hashtable[154].ToString();
                ProcessChamberPressureDD.Logic = hashtable[158].ToString();
                ProcessChamberPressureDD.ValueSet = "-";
                ProcessChamberPressureDD.ActualValue = 0.00;

                // Storage Tank 1 Temperature
                StorageTank1TemperatureDD.EqName = hashtable[108].ToString() + " 1";
                StorageTank1TemperatureDD.MeasurementName = hashtable[112].ToString();
                StorageTank1TemperatureDD.Unit = hashtable[155].ToString();
                StorageTank1TemperatureDD.LogicName = hashtable[154].ToString();
                StorageTank1TemperatureDD.Logic = hashtable[158].ToString();
                StorageTank1TemperatureDD.ValueSet = "20.00";
                StorageTank1TemperatureDD.ActualValue = 23.67;

                // Storage Tank 2 Temperature
                StorageTank2TemperatureDD.EqName = hashtable[108].ToString() + " 2";
                StorageTank2TemperatureDD.MeasurementName = hashtable[112].ToString();
                StorageTank2TemperatureDD.Unit = hashtable[155].ToString();
                StorageTank2TemperatureDD.LogicName = hashtable[154].ToString();
                StorageTank2TemperatureDD.Logic = hashtable[158].ToString();
                StorageTank2TemperatureDD.ValueSet = "20.00";
                StorageTank2TemperatureDD.ActualValue = 24.01;

                // Distillation Tank Top Temperature
                DistillationTankTopTemperatureDD.EqName = hashtable[109].ToString();
                DistillationTankTopTemperatureDD.Location = hashtable[110].ToString();
                DistillationTankTopTemperatureDD.MeasurementName = hashtable[112].ToString();
                DistillationTankTopTemperatureDD.Unit = hashtable[155].ToString();
                DistillationTankTopTemperatureDD.LogicName = "";
                DistillationTankTopTemperatureDD.Logic = "";
                DistillationTankTopTemperatureDD.ValueSet = "-";
                DistillationTankTopTemperatureDD.ActualValue = 48.54;

                // Distillation Tank Bottom Temperature
                DistillationTankBottomTemperatureDD.EqName = hashtable[109].ToString();
                DistillationTankBottomTemperatureDD.Location = hashtable[111].ToString();
                DistillationTankBottomTemperatureDD.MeasurementName = hashtable[112].ToString();
                DistillationTankBottomTemperatureDD.Unit = hashtable[155].ToString();
                DistillationTankBottomTemperatureDD.LogicName = hashtable[154].ToString();
                DistillationTankBottomTemperatureDD.Logic = hashtable[158].ToString();
                DistillationTankBottomTemperatureDD.ValueSet = "50.00";
                DistillationTankBottomTemperatureDD.ActualValue = 49.67;

                // Ultrasonic Power
                UltrasonicPowerDD.EqName = hashtable[921].ToString();
                UltrasonicPowerDD.MeasurementName = hashtable[135].ToString();
                UltrasonicPowerDD.Unit = hashtable[162].ToString();
                UltrasonicPowerDD.Logic = "";
                UltrasonicPowerDD.ValueSet = "0.00";
                UltrasonicPowerDD.ActualValue = 10.00;

                // Ultrasonic Frequency
                UltrasonicFrequencyDD.EqName = hashtable[921].ToString();
                UltrasonicFrequencyDD.MeasurementName = hashtable[136].ToString();
                UltrasonicFrequencyDD.Unit = "kHz";
                UltrasonicFrequencyDD.Logic = "";
                UltrasonicFrequencyDD.ValueSet = "0.00";
                UltrasonicFrequencyDD.ActualValue = 0.00;

                // Chiller Temperature
                ChillerOutletTemperatureDD.EqName = hashtable[210].ToString();
                ChillerOutletTemperatureDD.MeasurementName = hashtable[112].ToString();
                ChillerOutletTemperatureDD.Unit = hashtable[155].ToString();
                ChillerOutletTemperatureDD.Logic = "";
                ChillerOutletTemperatureDD.ValueSet = "30.00";
                ChillerOutletTemperatureDD.ActualValue = 25.40;

                // Reservoir Tank Pressure
                ReservoirTankPressureDD.EqName = hashtable[196].ToString();
                ReservoirTankPressureDD.MeasurementName = hashtable[156].ToString();
                ReservoirTankPressureDD.Unit = "kPa";
                ReservoirTankPressureDD.LogicName = "";
                ReservoirTankPressureDD.Logic = "";
                ReservoirTankPressureDD.ValueSet = "-";
                ReservoirTankPressureDD.ActualValue = 0.00;


                hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("157,158,159,160,161");
            }
            catch (NullReferenceException) { }
        }
    }
}
