using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace CLEANXCEL2._2.Pages.Menu.RecipeManagement
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>
    public partial class Index : Page
    {
        public static Index AppWindow;
        public Index()
        {
            InitializeComponent();
            AppWindow = this;
        }

        private void CheckAuthentication()
        {
            RBRecipe.IsEnabled = Globals.AuthenticationLevel.Substring(2, 1).Contains("1");
            RBProcess.IsEnabled = Globals.AuthenticationLevel.Substring(1, 1).Contains("1");
            RBSubProcess.IsEnabled = Globals.AuthenticationLevel.Substring(0, 1).Contains("1");

            switch(Globals.AuthenticationLevel.Substring(0, 3))
            {
                case "000":
                    RBPart.IsChecked = true;
                    break;
                case "001":
                    RBRecipe.IsChecked = true;
                    break;
                case "011":
                    RBProcess.IsChecked = true;
                    break;
                case "111":
                    RBSubProcess.IsChecked = true;
                    break;
            }
        }

        public static String MENUPAGE_URL = null; // Modifiable

        public static void MENUPAGE_REQUEST()
        {
            if (MENUPAGE_URL != null)
            {
                AppWindow.FrameLocalContainer.Source = new Uri(MENUPAGE_URL, UriKind.RelativeOrAbsolute);
                Storyboard SB = (Storyboard)AppWindow.FindResource("ShowFrame");
                SB.Begin();
                Debug.WriteLine("MENUPAGE_REQUEST : Completed.");
            }
            else
            {
                Debug.WriteLine("MENUPAGE_REQUEST : MENUPAGE_URL is not defined.");
            }
        }

        private void FrameLocalContainer_Loaded(object sender, RoutedEventArgs e)
        {
            MENUPAGE_URL = "SubProcess.xaml";
            CheckAuthentication();
            MENUPAGE_REQUEST();
        }

        public void HidePage()
        {
            Storyboard SB = (Storyboard)FindResource("HideFrame");
            SB.Begin();
        }

        private void RBPart_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "Part.xaml")
            {
                MENUPAGE_URL = "Part.xaml";
                HidePage();
            }
        }

        private void RBRecipe_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "Recipe.xaml")
            {
                MENUPAGE_URL = "Recipe.xaml";
                HidePage();
            }
        }

        private void RBProcess_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "Process.xaml")
            {
                MENUPAGE_URL = "Process.xaml";
                HidePage();
            }
        }

        private void RBSubProcess_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "SubProcess.xaml")
            {
                MENUPAGE_URL = "SubProcess.xaml";
                HidePage();
            }
        }

        private void RBUploadDownload_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "UploadDownload.xaml")
            {
                MENUPAGE_URL = "UploadDownload.xaml";
                HidePage();
            }
        }

        private void LoadPage(object sender, EventArgs e)
        {
            MENUPAGE_REQUEST();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("27,92,30,29,28,131,269,270");

                PageTitle.Text = hashtable[27].ToString();
                PageDescription.Text = hashtable[92].ToString();
                RBPart.Content = hashtable[131].ToString();
                RBRecipe.Content = hashtable[30].ToString();
                RBProcess.Content = hashtable[29].ToString();
                RBSubProcess.Content = hashtable[28].ToString();
                RBUploadDownload.Content = hashtable[269].ToString() + "/" + hashtable[270].ToString();
            }
            catch (NullReferenceException) { }
        }
    }
}
