using MySql.Data.MySqlClient;
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


namespace CLEANXCEL2._2.Pages.Menu.Operation
{
    /// <summary>
    /// Interaction logic for Operation.xaml
    /// </summary>
    public partial class Operation : Page
    {
        int TotalProcessTime = 1;
        private TcAdsClient adsClient = new TcAdsClient();
        private static AdsStream adsDataStream = new AdsStream(115);
        private static AdsBinaryReader binRead = new AdsBinaryReader(adsDataStream);
        private static int[] hconnect = new int[13];
        private bool AutoPrepInProgress = false;

        public Operation()
        {
            Debug.WriteLine("Pages.Menu.Operation.Operation()");
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.Page_Loaded()");
            Initialize();
            LoadLanguage();
            LogInterval.SelectedIndex = Globals.IntervalIndex;

            if (Globals.CONNECTION)
            {
                try
                {

                    adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);

                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bAutoModeOnPB", "true", "bool");
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bMainOnOff", "true", "bool");

                    try
                    {
                        ((RadioButton)FindName(Globals.currentRecipe)).IsChecked = true;
                    }
                    catch { }
                    
                    hconnect[0] = adsClient.AddDeviceNotification(".ARDsStnSeqProcessCtrl[1].Out_iCurrentProcessTime", adsDataStream, 0, 4, AdsTransMode.OnChange, 50, 0, null);
                    hconnect[1] = adsClient.AddDeviceNotification(".DSHmiStationDisplayInfo[1].sStationSubDescription", adsDataStream, 4, 100, AdsTransMode.OnChange, 50, 0, null);
                    hconnect[2] = adsClient.AddDeviceNotification(".bAutoPreparationPb", adsDataStream, 104, 1, AdsTransMode.OnChange, 50, 0, null);
                    hconnect[3] = adsClient.AddDeviceNotification(".bAutoPreparationDone", adsDataStream, 105, 1, AdsTransMode.OnChange, 50, 0, null);
                    hconnect[4] = adsClient.AddDeviceNotification(".bStn1DoorOpenCompleted", adsDataStream, 106, 1, AdsTransMode.OnChange, 50, 0, null);
                    hconnect[5] = adsClient.AddDeviceNotification(".bStn1DoorCloseCompleted", adsDataStream, 107, 1, AdsTransMode.OnChange, 50, 0, null);
                    hconnect[6] = adsClient.AddDeviceNotification(".bBasketCfmEn", adsDataStream, 108, 1, AdsTransMode.OnChange, 50, 0, null);

                    // Preparation Status Monitoring
                    hconnect[7] = adsClient.AddDeviceNotification(".X101_06", adsDataStream, 109, 1, AdsTransMode.OnChange, 50, 0, null);                           // Storage Tank 1 Regular Level Reached
                    hconnect[8] = adsClient.AddDeviceNotification("AutoPreparationCtrl.bInitialDrainFunctionCompleted", adsDataStream, 110, 1, AdsTransMode.OnChange, 50, 0, null);     // Process Chamber Drain Completed
                    hconnect[9] = adsClient.AddDeviceNotification(".ArbRevHighVacuumSignal[1]", adsDataStream, 111, 1, AdsTransMode.OnChange, 50, 0, null);         // Reservoir Tank High Vacuum
                    hconnect[10] = adsClient.AddDeviceNotification(".X101_03", adsDataStream, 112, 1, AdsTransMode.OnChange, 50, 0, null);                           // Distillation Tank Top Up Level Reached
                    hconnect[11] = adsClient.AddDeviceNotification(".ARbStnTempRDY[4]", adsDataStream, 113, 1, AdsTransMode.OnChange, 50, 0, null);                  // Distillation Tank Temperature Ready

                    // Activate Auto Cycle
                    hconnect[12] = adsClient.AddDeviceNotification(".bCycleActivated", adsDataStream, 113, 1, AdsTransMode.OnChange, 50, 0, null); 

                    adsClient.AdsNotification += new AdsNotificationEventHandler(StatusOnChange);
                }
                catch
                {

                }
            }
        }

        private void StatusOnChange(object sender, AdsNotificationEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.StatusOnChange()");
            try
            {
                if (e.NotificationHandle == hconnect[0])
                {
                    int value = binRead.ReadInt16();
                    myrad.Value = Convert.ToDouble(((double)value / TotalProcessTime) * 100);
                    myrad.ToolTip = TotalProcessTime - value;
                }
                else if (e.NotificationHandle == hconnect[1])
                {
                    string value = binRead.ReadPlcAnsiString(99);
                    Debug.WriteLine("Description : " + value);
                    //myrad.Tag = string.Format(value);
                    ProcessName.Text = string.Format(value);
                }
                else if (e.NotificationHandle == hconnect[2])
                {
                    AutoPrepInProgress = binRead.ReadBoolean();

                    if (!AutoPrepInProgress)
                    {
                        AutoPreparation.IsChecked = false;
                        Pages.Menu.Index.AppWindow.MMMaintenance.IsEnabled = true;
                    }
                    else
                    {
                        Pages.Menu.Index.AppWindow.MMMaintenance.IsEnabled = false;
                    }
                }
                else if (e.NotificationHandle == hconnect[3])
                {
                    bool AutoPrepCompleted = binRead.ReadBoolean();

                    if (AutoPrepInProgress && !AutoPrepCompleted)
                        AutoPreparation.IsChecked = null;
                    else if (AutoPrepInProgress && AutoPrepCompleted)
                        AutoPreparation.IsChecked = true;
                }
                else if (e.NotificationHandle == hconnect[4])
                {
                    Door.IsChecked = !binRead.ReadBoolean();
                }
                else if (e.NotificationHandle == hconnect[5])
                {
                    Door.IsChecked = binRead.ReadBoolean();
                }
                else if (e.NotificationHandle == hconnect[6])
                {
                    bool BasketConfirm = binRead.ReadBoolean();

                    Start.IsChecked = BasketConfirm;
                    if (BasketConfirm)
                    {
                        StartEllipse.Fill = (Brush)FindResource("RedPinkColor");
                        BlockedRecipe.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        StartEllipse.Fill = (Brush)FindResource("CWhite");
                        BlockedRecipe.Visibility = Visibility.Hidden;
                    }
                }
                else if (e.NotificationHandle == hconnect[7])
                {
                    StorageTank1RegularLevel.IsChecked = binRead.ReadBoolean();
                }
                else if (e.NotificationHandle == hconnect[8])
                {
                    ProcessChamberDrainComplete.IsChecked = binRead.ReadBoolean();
                }
                else if (e.NotificationHandle == hconnect[9])
                {
                    ReservoirTankHighVacuum.IsChecked = binRead.ReadBoolean();
                }
                else if (e.NotificationHandle == hconnect[10])
                {
                    DistillationTankTopUpLevel.IsChecked = binRead.ReadBoolean();
                }
                else if (e.NotificationHandle == hconnect[11])
                {
                    DistillationTankTemperatureReady.IsChecked = binRead.ReadBoolean();
                }
                else if (e.NotificationHandle == hconnect[12])
                {
                    AutoCycle.IsChecked = binRead.ReadBoolean();
                }
            }
            catch
            {

            }
        }

        private void Initialize()
        {
            Debug.WriteLine("Pages.Menu.Operation.Initialize()");
            LoadPartName();
            LoadRecipeName();
        }

        private void LoadRecipeName()
        {
            Debug.WriteLine("Pages.Menu.Operation.LoadRecipeName()");
            List<List<string>> recipes = Controllers.SQL.Query.ExecuteMultiQuery("select * from recipe_id", new string[] { "id", "name" });
            for (int i = 0; i<recipes[0].Count();i++)
            {
                int TotalRecipeTime = Convert.ToInt32((Controllers.SQL.Query.ExecuteSingleQuery(
                    "select sum(recipe.process_time) as total_time from recipe right join " +
                    "recipe_id on recipe_id.id = recipe.recipe_name where recipe_id.id = '" + recipes[0][i] + "'", "total_time"))[0]);
                RadioButton radioButton = new RadioButton()
                {
                    Name = "RECIPES" + recipes[0][i],
                    Tag = recipes[0][i],
                    ToolTip = recipes[1][i],
                    Content = TotalRecipeTime.ToString(),
                    Style = (Style)FindResource("RBStandardSelection"),
                    GroupName = "recipes"
                };
                RegisterName(radioButton.Name, radioButton);
                radioButton.Checked += recipes_Checked;
                RecipeStackPanel.Children.Add(radioButton);

                if (radioButton.Tag.ToString() == Globals.currentRecipe)
                    radioButton.IsChecked = true;
            }
        }

        private void LoadPartName()
        {
            Debug.WriteLine("Pages.Menu.Operation.LoadPartName()");
            RadioButton selected = new RadioButton();
            List<List<string>> parts = Controllers.RecipeManagement.API.Part.Get_SQLPart();
            for(int i = 0; i < parts[0].Count(); i++)
            {
                RadioButton radioButton = new RadioButton()
                {
                    Name = "PARTS" + parts[0][i] + "_" + parts[3][i],
                    Tag = parts[0][i],
                    ToolTip = parts[1][i],
                    Content = parts[2][i],
                    Style = (Style)FindResource("RBStandardSelection"),
                    GroupName = "parts"
                };
                RegisterName(radioButton.Name, radioButton);
                radioButton.Checked += parts_Checked;
                PartStackPanel.Children.Add(radioButton);

                if (radioButton.Tag.ToString() == Globals.currentPart)
                    radioButton.IsChecked = true;
            }
            
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.Grid_Loaded()");
            myrad.Value = 0;
        }

        private void SystemStatus_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.SystemStatus_Click()");
            if (Globals.CONNECTION)
            {
                try
                {
                    CheckBox checkbox = (CheckBox)sender;

                    switch (checkbox.Name)
                    {
                        case "AutoPreparation":
                            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bAutoPreparationPb", checkbox.IsChecked.ToString(), "bool");
                            checkbox.IsChecked = null;
                            break;
                        case "Door":
                            switch (checkbox.IsChecked)
                            {
                                case true:
                                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bMapDoorOpen", (!checkbox.IsChecked).ToString(), "bool");
                                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bMapDoorClose", checkbox.IsChecked.ToString(), "bool");
                                    checkbox.IsChecked = null;
                                    break;
                                case false:
                                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bMapDoorClose", checkbox.IsChecked.ToString(), "bool");
                                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bMapDoorOpen", (!checkbox.IsChecked).ToString(), "bool");
                                    checkbox.IsChecked = null;
                                    break;
                            }
                            break;
                        case "AutoCycle":
                            if (checkbox.IsChecked == true)
                            {
                                Controllers.EventNotifier.Loading_Display.Run(Controllers.EventNotifier.Loading_Display.LoadingActions.Loading);

                                System.ComponentModel.BackgroundWorker RunAutoCycle = new System.ComponentModel.BackgroundWorker();
                                RunAutoCycle.DoWork += RunAutoCycle_DoWork;
                                RunAutoCycle.RunWorkerCompleted += RunAutoCycle_RunWorkerCompleted;
                                RunAutoCycle.RunWorkerAsync(checkbox.IsChecked);
                            }
                            else
                            {
                                Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bCycleActivated", checkbox.IsChecked.ToString(), "bool");
                            }
                            checkbox.IsChecked = null;
                            break;
                    }
                }
                catch { }
            }
        }

        private void RunAutoCycle_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.RunAutoCycle_DoWork()");
            bool argument = Convert.ToBoolean(e.Argument);
            string recipe = Globals.currentRecipe.Replace('_', ' ');
            Controllers.RecipeManagement.API.Recipe_Machine_Com.UploadRecipe(adsClient, recipe, TotalProcessTime);
            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".iAutoCycleRecipeNo", "1", "int");
            Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bCycleActivated", argument.ToString(), "bool");
        }

        private void RunAutoCycle_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.RunAutoCycle_RunWorkerCompleted()");
            Controllers.EventNotifier.Loading_Display.Stop(Controllers.EventNotifier.Loading_Display.LoadingActions.Loading);
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (Globals.currentRecipe != "" && Globals.currentPart != "")
            {
                Debug.WriteLine("Pages.Menu.Operation.Start_Click()");
                //string recipe = Globals.currentRecipe.Replace('_', ' ');
                //Controllers.RecipeManagement.API.RecipeModule.UploadRecipe(adsClient, recipe, TotalProcessTime);


                Controllers.EventNotifier.Loading_Display.Run(Controllers.EventNotifier.Loading_Display.LoadingActions.Loading);
                ToggleButton toggleButton = (ToggleButton)sender;

                System.ComponentModel.BackgroundWorker RunOperation = new System.ComponentModel.BackgroundWorker();
                RunOperation.DoWork += RunOperation_DoWork;
                RunOperation.RunWorkerCompleted += RunOperation_RunWorkerCompleted;

                RunOperation.RunWorkerAsync(toggleButton.IsChecked);
            }
        }

        private void RunOperation_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.RunOperation_DoWork()");
            if (Globals.CONNECTION)
            {
                bool argument = Convert.ToBoolean(e.Argument);
                try
                {
                    Globals.InitiatingRecipe = true;
                    Controllers.ADS.ADS_ReadWrite.ADS_WriteValue(adsClient, ".bAutoStartPB", argument.ToString(), "bool");

                    if (argument == true)
                    {
                        string recipe = Globals.currentRecipe.Replace('_', ' ');

                        Controllers.RecipeManagement.API.Recipe_History.POST_History_Recipe();
                        Controllers.RecipeManagement.API.Standard_Machine_Command.EmptyRecipe(adsClient);
                        Controllers.RecipeManagement.API.Recipe_Machine_Com.UploadRecipe(adsClient, recipe, TotalProcessTime);
                        Controllers.RecipeManagement.API.Standard_Machine_Command.StartRecipeNumber(adsClient, 1);

                        e.Result = true;
                    }
                    else
                    {
                        Controllers.RecipeManagement.API.Standard_Machine_Command.StopProcess(adsClient);

                        e.Result = false;
                    }

                }
                catch { }
            }
        }

        private void RunOperation_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.RunOperation_RunWorkerCompleted()");
            Controllers.EventNotifier.Loading_Display.Stop(Controllers.EventNotifier.Loading_Display.LoadingActions.Loading);

            if ((bool)e.Result)
            {
                Globals.IntervalIndex = LogInterval.SelectedIndex;
                switch (LogInterval.SelectedIndex)
                {
                    case 0:
                        Globals.LoggingHistoryStatusDefault = true;
                        break;
                    case 1:
                        Globals.LoggingHistoryStatusDefault = false;
                        Pages.Menu.Index.AppWindow.RunIntervalLogging(1);
                        break;
                    case 2:
                        Globals.LoggingHistoryStatusDefault = false;
                        Pages.Menu.Index.AppWindow.RunIntervalLogging(2);
                        break;
                    case 3:
                        Globals.LoggingHistoryStatusDefault = false;
                        Pages.Menu.Index.AppWindow.RunIntervalLogging(5);
                        break;
                    case 4:
                        Globals.LoggingHistoryStatusDefault = false;
                        Pages.Menu.Index.AppWindow.RunIntervalLogging(10);
                        break;
                }
            }
        }

        private void recipes_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.recipes_Checked()");
            try
            {
                RadioButton radioButton = (RadioButton)sender;
                TotalProcessTime = Convert.ToInt32(((RadioButton)sender).Content);

                RecipeName.Text = radioButton.ToolTip.ToString();
                myrad.ToolTip = radioButton.Content.ToString();

                //Globals.currentRecipe = myrad.Tag.ToString();
                Globals.currentRecipe = radioButton.Tag.ToString();
            }
            catch { }
        }

        private void parts_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.parts_Checked()");
            try
            {
                RadioButton radioButton = (RadioButton)sender;
                string selectedpart = radioButton.Name;

                Globals.currentPart = radioButton.Tag.ToString();

                ((RadioButton)FindName("RECIPES" + selectedpart.Substring(selectedpart.IndexOf('_') + 1))).IsChecked = true;
            }
            catch { }
        }

        private void Page_Unloaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.Menu.Operation.Page_Unloaded()");
            if (Globals.CONNECTION)
            {
                adsClient.Disconnect();
                adsClient.Dispose();
            }
        }

        private void LoadLanguage()
        {
            Debug.WriteLine("Pages.Menu.Operation.LoadLanguage()");
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("30,114,115,131,186,211,212,213,214,215,216");

                TBPartTitle.Text = hashtable[131].ToString();
                TBRecipeTitle.Text = hashtable[30].ToString();
                myrad.Tag = hashtable[115].ToString();
                AutoPreparation.Content = hashtable[114].ToString();
                Door.Content = hashtable[186].ToString();

                MoreDetails.Header = hashtable[211].ToString();
                StorageTank1RegularLevel.Content = hashtable[212].ToString();
                ProcessChamberDrainComplete.Content = hashtable[213].ToString();
                ReservoirTankHighVacuum.Content = hashtable[214].ToString();
                DistillationTankTopUpLevel.Content = hashtable[215].ToString();
                DistillationTankTemperatureReady.Content = hashtable[216].ToString();
            }
            catch (NullReferenceException) { }
        }
    }
}
