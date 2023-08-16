using System;
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
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Diagnostics;

namespace CLEANXCEL2._2.Pages.Menu.DefaultSettings
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
            MENUPAGE_URL = "General.xaml";
            RBGeneral.IsChecked = true;
            MENUPAGE_REQUEST();
        }

        public void HidePage()
        {
            Storyboard SB = (Storyboard)FindResource("HideFrame");
            SB.Begin();
        }

        private void RBGeneral_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "General.xaml")
            {
                MENUPAGE_URL = "General.xaml";
                HidePage();
            }
        }

        //private void RBStation1_Checked(object sender, RoutedEventArgs e)
        //{
        //    if (MENUPAGE_URL != "Station1.xaml")
        //    {
        //        MENUPAGE_URL = "Station1.xaml";
        //        HidePage();
        //    }
        //}

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
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("32,89,100,101");

                PageTitle.Text = hashtable[32].ToString();
                PageDescription.Text = hashtable[89].ToString();
                RBGeneral.Content = hashtable[32].ToString();
                //RBStation1.Content = hashtable[101].ToString() + " 1";
            }
            catch (NullReferenceException) { }
        }
    }
}
