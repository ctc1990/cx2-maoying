using Microsoft.Win32;
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
using TwinCAT.Ads;

namespace CLEANXCEL2._2.Pages.Menu.Maintenance
{
    /// <summary>
    /// Interaction logic for Calibration.xaml
    /// </summary>
    public partial class UploadDownload : Page
    {
        int total_recipe_id = 0;
        List<int> selected_recipe_id = new List<int>();
        TcAdsClient adsClient = new TcAdsClient();

        public UploadDownload()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
            LoadRecipe();

            adsClient.Connect(Globals.AMSNetID, Globals.AMSPort);
        }
        
        private void LoadRecipe()
        {
            List<List<string>> recipes = Controllers.RecipeManagement.API.Recipe.Get_SQLRecipeId();

            total_recipe_id = recipes[0].Count();

            for (int i = 0; i < recipes[0].Count(); i++)
            {
                CheckBox checkBox = new CheckBox()
                {
                    Content = recipes[0][i] + " - " + recipes[1][i],
                    Width = 400,
                    Foreground = (SolidColorBrush)FindResource("CWhite"),
                    Style = (Style)FindResource("CBSubMenuRoles"),
                    Tag = recipes[0][i]
                };

                checkBox.Checked += CheckBox_Checked;
                checkBox.Unchecked += CheckBox_Unchecked;
                CBStackRecipeID.Children.Add(checkBox);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int recipe_id = Convert.ToInt32(checkBox.Tag);

            selected_recipe_id.Remove(recipe_id);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int recipe_id = Convert.ToInt32(checkBox.Tag);

            selected_recipe_id.Add(recipe_id);
        }

        private void CBUpload_Click(object sender, RoutedEventArgs e)
        {
            if (CBUpload.IsChecked == true)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.DefaultExt = ".xml";
                openFileDialog.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

                if (openFileDialog.ShowDialog() == true)
                    Controllers.SQL.Backup.XML2Database(openFileDialog.FileName);
            }
        }

        private void CBDownload_Click(object sender, RoutedEventArgs e)
        {
            if (CBDownload.IsChecked == true)
            {
                string name = String.Join(",", selected_recipe_id);

                if (selected_recipe_id.Count() == total_recipe_id)
                    Controllers.SQL.Backup.Database2XML("recipe.xml");
                else
                    Controllers.SQL.Backup.Database2XML_By_ID_List("recipe_id_" + name + ".xml", selected_recipe_id.ToArray());
            }
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("269,270,271");
                
                TBUploadTitle.Text = hashtable[269].ToString();
                TBDownloadTitle.Text = hashtable[270].ToString();
                ExpanderRecipeID.Header= hashtable[271].ToString();
            }
            catch (NullReferenceException) { }
        }
    }
}
