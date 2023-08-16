using CLEANXCEL2._2.UserControls;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

namespace CLEANXCEL2._2.Pages.Menu.RecipeManagement
{
    /// <summary>
    /// Interaction logic for Recipe.xaml
    /// </summary>
    public partial class Recipe : Page
    {
        public Recipe()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            foreach (string processname in Controllers.SQL.Query.ExecuteSingleQuery("select process_id.name from process_id where process_id.status = '1'", "name"))
            {
                Button button = new Button()
                {
                    Name = processname.Replace('-', '_').Replace('=', '_').Replace(' ', '_').Replace(',','_'),
                    ToolTip = processname,
                    Content = "Process ID: " + (ProcessList.Children.Count + 1),
                    Style = (Style)FindResource("BStandardSelection")
                };
                button.Click += SubProcessName_Click;

                ProcessList.Children.Add(button); //(ProcessList.Items.Count + 1) + "\t" + 
            }
            foreach (string processname in Controllers.SQL.Query.ExecuteSingleQuery("select recipe_id.name from recipe_id where recipe_id.status = '1'", "name"))
                CBRecipeName.Items.Add(processname);
        }

        private void SubProcessName_Click(object sender, RoutedEventArgs e)
        {
            string processname = (sender as Button).ToolTip.ToString();
            Controllers.SQL.Query query = new Controllers.SQL.Query();
            try
            {
                ProcessDuration.Children.Add(new RecipeTable() { Title = processname, ProcessTime = ProcessTime(processname) });
            }
            catch { }
        }

        private int ProcessTime(string title)
        {
            List<int> list = new List<int>();
            foreach (string processconditions in Controllers.SQL.Query.ExecuteSingleQuery("select process.conditions from process right join process_id on process_id.id = process.process_name where process_id.name='" + title + "'", "conditions"))
            {
                list.AddRange(processconditions.Split(':', '~').Select(x => Convert.ToInt32(x)));
            }

            return (list.Max() - list.Min());
        }

        //private void ProcessList_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        //{
        //    Controllers.SQL.Query query = new Controllers.SQL.Query();
        //    try
        //    {
        //        ProcessDuration.Children.Add(new StandardTable() { Category = StandardTable.Categories.Recipe, Title = ProcessList.SelectedItem.ToString()});
        //        ProcessList.SelectedIndex = -1;
        //    }
        //    catch { }
        //}

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            Globals.currentPage = "Recipe";
            Globals.POPUP_URL = "../Pages/Window/WindowsMessageBox.xaml";
            Globals.POPUP_REQUEST("51", "52", Window.WindowsMessageBox.State.Confirmation);
        }

        public void TriggerProcess()
        {
            Globals.currentPage = null;
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";

            MySqlCommand mySqlCommand = new MySqlCommand();

            mySqlCommand.Parameters.AddWithValue("@recipe_name", CBRecipeName.Text.ToString());

            if (!Controllers.SQL.Query.ExecuteCheckQuery("select * from recipe_id where recipe_id.name=@recipe_name", mySqlCommand))
            {
                UploadProcess();
                CBRecipeName.SelectedIndex = -1;
                ProcessDuration.Children.Clear();
            }
            else // Stay on the page
            {
                //Globals.currentPage = "RecipeOverwrite";

                //query.ExecuteNonQuery("update recipe set recipe.status = '0' where recipe.recipe_name = '" + CBRecipeName.Text.ToString() + "'", mySqlCommand);

                Globals.POPUP_REQUEST("51", "41", Window.WindowsMessageBox.State.Ok);
            }
        }

        public void TriggerOverwriteProcess()
        {
            UploadProcess();
        }

        public void UploadProcess()
        {
            Controllers.RecipeManagement.API.Recipe.Create_SQLRecipeId(CBRecipeName.Text.ToString());
            foreach (UIElement children in ProcessDuration.Children)
            {
                RecipeTable standardTable = (RecipeTable)children;
                standardTable.ProcessName = CBRecipeName.Text.ToString();
                ((RecipeTable)children).Encode();
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
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("105,3,29,30");

                TBProcessNameTitle.Text = hashtable[29].ToString() + ((MainWindow.language == "mandarin" || MainWindow.language == "japanese") ? "" : " ") + hashtable[3].ToString();
                TBRecipeNameTitle.Text = hashtable[30].ToString() + ((MainWindow.language == "mandarin" || MainWindow.language == "japanese") ? "" : " ") + hashtable[3].ToString();
                Save.Content = hashtable[105].ToString();
            }
            catch { }
        }

        private void CBRecipesName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (CBRecipeName.SelectedIndex != -1)
            {
                try
                {
                    ProcessDuration.Children.Clear();

                    List<List<string>> list = Controllers.SQL.Query.ExecuteMultiQuery("select * from (select recipe.process_name, recipe.process_time, recipe.parameters from recipe right join recipe_id on recipe_id.id = recipe.recipe_name where recipe_id.name = '" + CBRecipeName.SelectedItem.ToString() + "') as process left join process_id on process_id.id = process.process_name", new string[] { "name", "process_time", "parameters" });
                    for (int i = 0; i < list[0].Count(); i++)
                    {
                        string[] parameters = list[2][i].Split(new char[] { '~', '=' });

                        ProcessDuration.Children.Add(new RecipeTable()
                        {
                            ProcessTime = Convert.ToDouble(list[1][i]),
                            Power = Convert.ToDouble(parameters[1]),
                            Frequency = Convert.ToDouble(parameters[3]),
                            Title = list[0][i]
                        });
                    }
                }
                catch { }
            }
        }
    }
}
