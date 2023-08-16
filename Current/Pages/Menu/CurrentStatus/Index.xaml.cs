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

namespace CLEANXCEL2._2.Pages.Menu.CurrentStatus
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
            //MENUPAGE_URL = "Schematics.xaml";
            MENUPAGE_URL = "MachineStatus.xaml";
            RBSchematics.IsChecked = true;
            MENUPAGE_REQUEST();
        }

        public void HidePage()
        {
            Storyboard SB = (Storyboard)FindResource("HideFrame");
            SB.Begin();
        }

        private void RBSchematics_Checked(object sender, RoutedEventArgs e)
        {
            //if (MENUPAGE_URL != "Schematics.xaml")
            if (MENUPAGE_URL != "MachineStatus.xaml")
            {
                //MENUPAGE_URL = "Schematics.xaml";
                MENUPAGE_URL = "MachineStatus.xaml";
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
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("39,88");

                PageTitle.Text = hashtable[39].ToString();
                PageDescription.Text = hashtable[88].ToString();
                RBSchematics.Content = hashtable[39].ToString();
            }
            catch { }
        }
    }
}
