using CLEANXCEL2._2.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace CLEANXCEL2._2.Pages.Menu.RecipeManagement
{
    /// <summary>
    /// Interaction logic for Process.xaml
    /// </summary>
    public partial class Process : Page
    {
        public Process()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            List<List<string>> SubProcess = Controllers.SQL.Query.ExecuteMultiQuery("select sub_process_id.id, sub_process_id.name from sub_process_id where (sub_process_id.status = '1' and sub_process_id.name not LIKE '%TEMPLATE%')", new string[] { "id", "name" });
            for(int i = 0; i< SubProcess[0].Count(); i++)
            {
                Button button = new Button()
                {
                    Name = SubProcess[1][i].Replace('-','_').Replace('=','_').Replace(' ','_'),
                    ToolTip = SubProcess[1][i],
                    Content = "Sub Process ID: " + SubProcess[0][i],
                    Style = (Style)FindResource("BStandardSelection")
                };
                button.Click += SubProcessName_Click;

                SubProcessList.Children.Add(button); //(SubProcessList.Items.Count + 1) + "\t" + 
            }
            foreach (string processname in Controllers.SQL.Query.ExecuteSingleQuery("select process_id.name from process_id where process_id.status = '1'", "name"))
                CBProcessName.Items.Add(processname);
        }

        private void SubProcessName_Click(object sender, RoutedEventArgs e)
        {
            string subprocessname = (sender as Button).ToolTip.ToString();
            Controllers.SQL.Query query = new Controllers.SQL.Query();
            try
            {
                if (subprocessname.Contains("aVX"))
                {
                    SubProcessDuration.Children.Add(new aVXTable() { Title = subprocessname });
                }
                else
                {
                    SubProcessDuration.Children.Add(new StandardTable() { Category = StandardTable.Categories.Process, Title = subprocessname });
                }
            }
            catch { }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Globals.currentPage = "Process";
            Globals.POPUP_URL = "../Pages/Window/WindowsMessageBox.xaml";
            Globals.POPUP_REQUEST("51", "52", Window.WindowsMessageBox.State.Confirmation);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Globals.currentPage = "Process_Delete";
            Globals.POPUP_URL = "../Pages/Window/WindowsMessageBox.xaml";
            Globals.POPUP_REQUEST("51", "52", Window.WindowsMessageBox.State.Confirmation);
        }

        public void TriggerProcess()
        {
            Globals.currentPage = null;
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";

            MySqlCommand mySqlCommand = new MySqlCommand();

            mySqlCommand.Parameters.AddWithValue("@process_name", CBProcessName.Text.ToString());

            if (!Controllers.SQL.Query.ExecuteCheckQuery("select * from process_id where process_id.name=@process_name and status = '1'", mySqlCommand))
            {
                UploadSubProcess();
            }
            else // Stay on the page
            {
                //Globals.currentPage = "ProcessOverwrite";

                //query.ExecuteNonQuery("update process set process.status = '0' where process.process_name = '" + CBProcessName.Text.ToString() + "'", mySqlCommand);

                Globals.POPUP_REQUEST("51", "41", Window.WindowsMessageBox.State.Ok);
            }
        }

        public void TriggerDeleteProcess()
        {
            Globals.currentPage = null;
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";

            MySqlCommand mySqlCommand = new MySqlCommand();

            mySqlCommand.Parameters.AddWithValue("@process_name", CBProcessName.Text.ToString());

            if (Controllers.SQL.Query.ExecuteCheckQuery("select * from process_id where process_id.name=@process_name and status = '1'", mySqlCommand))
            {
                // Reset Process Status
                Controllers.SQL.Query.ExecuteNonQuery("update process_id set process_id.status = '0' where process_id.name=@process_name", mySqlCommand);

                // Reset Recipe Status
                Controllers.SQL.Query.ExecuteNonQuery("update recipe_id " +
                                                    "inner join recipe on recipe.recipe_name = recipe_id.id " +
                                                    "inner join process_id on process_id.id = recipe.process_name " +
                                                    "set recipe_id.status = '0' " +
                                                    "where process_id.name = @process_name", mySqlCommand);

                // Reset Part Status
                Controllers.SQL.Query.ExecuteNonQuery("update part_id " +
                                                    "inner join part on part.part_name = part_id.id " +
                                                    "inner join recipe_id on recipe_id.id = part.recipe_name " +
                                                    "inner join recipe on recipe.recipe_name = recipe_id.id " +
                                                    "inner join process_id on process_id.id = recipe.process_name " +
                                                    "set part_id.status = '0' " +
                                                    "where process_id.name = @process_name", mySqlCommand);

                // Clear Process
                CBProcessName.Items.Clear();

                // Clear Sub-Process
                SubProcessDuration.Children.Clear();

                // Populate Process
                foreach (string processname in Controllers.SQL.Query.ExecuteSingleQuery("select process_id.name from process_id where process_id.status = '1'", "name"))
                    CBProcessName.Items.Add(processname);
            }
            else // Stay on the page
            {
                //Globals.currentPage = "ProcessOverwrite";

                //query.ExecuteNonQuery("update process set process.status = '0' where process.process_name = '" + CBProcessName.Text.ToString() + "'", mySqlCommand);

                Globals.POPUP_REQUEST("51", "81", Window.WindowsMessageBox.State.Ok);
            }
        }

        public void TriggerOverwriteProcess()
        {
            UploadSubProcess();
        }

        private void UploadSubProcess()
        {
            Controllers.RecipeManagement.API.Process.Create_SQLProcessId(CBProcessName.Text.ToString());
            foreach (UIElement children in SubProcessDuration.Children)
            {
                try
                {
                    StandardTable table = (StandardTable)children;
                    table.Encode(table.Category);
                }
                catch (InvalidCastException)
                {
                    aVXTable table = (aVXTable)children;
                    table.Encode();
                }
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Initialize();
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("105,3,28,29");

                TBSubProcessNameTitle.Text = hashtable[28].ToString() + ((MainWindow.language == "mandarin" || MainWindow.language == "japanese") ? "" : " ") + hashtable[3].ToString();
                TBProcessNameTitle.Text = hashtable[29].ToString() + ((MainWindow.language == "mandarin" || MainWindow.language == "japanese") ? "" : " ") + hashtable[3].ToString();
                Save.Content = hashtable[105].ToString();
            }
            catch { }
        }

        private void CBProcessName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBProcessName.SelectedIndex != -1)
            {
                //try
                //{
                    int vacuum = 0, vacuum_hold = 0, vacuum_release = 0, vacuum_level = 0;

                    SubProcessDuration.Children.Clear();

                    List<List<string>> list = Controllers.SQL.Query.ExecuteMultiQuery(
                        "select sub_process_id.name, process_info.conditions from " +
                        "(select process.sub_process_name, process.conditions from process left join process_id on process_id.id = process.process_name where " +
                        "(process_id.status = '1' and process_id.name = '" + CBProcessName.SelectedItem.ToString()+"')) as process_info " +
                        "left join sub_process_id on process_info.sub_process_name = sub_process_id.id", new string[] { "name", "conditions" });
                    for (int i = 0; i < list[0].Count(); i++)
                    {
                        if (list[0][i].Contains("VACUUM WITH ULTRASONIC") && ((i + 2) < list[0].Count()))
                        {
                            vacuum_level = Convert.ToInt32(list[0][i].Substring(list[0][i].IndexOf('=') + 1));
                            int repeat = 1;
                            while (list[0][i].Contains("VACUUM WITH ULTRASONIC") && list[0][i + 1].Contains("VACUUM HOLD WITH ULTRASONIC") && list[0][i + 2].Contains("VACUUM RELEASE WITH ULTRASONIC"))
                            {
                                if (repeat == 1)
                                {
                                    int[] vacuum_list = list[1][i].Split(':', '~').Select(x => Convert.ToInt32(x)).ToArray();
                                    int[] vacuum_hold_list = list[1][++i].Split(':', '~').Select(x => Convert.ToInt32(x)).ToArray();
                                    int[] vacuum_release_list = list[1][++i].Split(':', '~').Select(x => Convert.ToInt32(x)).ToArray();
                                    vacuum = vacuum_list[0];
                                    vacuum_hold = vacuum_hold_list[1] - vacuum_hold_list[0];
                                    vacuum_release = vacuum_release_list[1] - vacuum_release_list[0];
                                    i++;
                                }
                                if (list[0][i].Contains("VACUUM WITH ULTRASONIC"))
                                {
                                    i += 3;
                                    repeat++;
                                }
                                if (i > (list[0].Count() - 2))
                                    break;
                            }
                            i -= 1;
                            SubProcessDuration.Children.Add(new aVXTable()
                            {
                                Title = "aVX",
                                Start = vacuum,
                                Hold = vacuum_hold,
                                Release = vacuum_release,
                                Pulses = repeat,
                                VacuumLevel = vacuum_level
                            });
                        }
                        else
                            SubProcessDuration.Children.Add(new StandardTable() { Category = StandardTable.Categories.LoadProcess, Time = list[1][i], Title = list[0][i] });

                    }
                //}
                //catch { }
            }
        }
    }
}
