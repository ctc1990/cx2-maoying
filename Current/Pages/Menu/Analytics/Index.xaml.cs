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

namespace CLEANXCEL2._2.Pages.Menu.Analytics
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
            MENUPAGE_URL = "Graph.xaml";
            RBGraph.IsChecked = true;
            MENUPAGE_REQUEST();
        }

        public void HidePage()
        {
            Storyboard SB = (Storyboard)FindResource("HideFrame");
            SB.Begin();
        }

        private void RBGraph_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "Graph.xaml")
            {
                MENUPAGE_URL = "Graph.xaml";
                HidePage();
            }
        }

        private void RBStatusDiagram_Checked(object sender, RoutedEventArgs e)
        {
            if (MENUPAGE_URL != "StatusDiagram.xaml")
            {
                MENUPAGE_URL = "StatusDiagram.xaml";
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
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("40,132,174,175");

                PageTitle.Text = hashtable[40].ToString();
                PageDescription.Text = hashtable[132].ToString();
                RBGraph.Content = hashtable[174].ToString();
                RBStatusDiagram.Content = hashtable[175].ToString();
            }
            catch { }
        }
    }
}
