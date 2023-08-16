using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
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

namespace CLEANXCEL2._2.Pages.User
{
    /// <summary>
    /// Interaction logic for Index.xaml
    /// </summary>

    public partial class Index : Page
    {
        public static Index AppWindow;
        public Index()
        {
            string language = MainWindow.language;
            Debug.WriteLine("Pages.User.Index()");
            InitializeComponent();
            AppWindow = this;
            CbxMainLanguage_Select(language);
        }

        private void FrameContainerLoaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.User.FrameContainerLoaded()");
            RBSignIn.IsChecked = true;
        }

        private void LoadPage(object sender, EventArgs e)
        {
            Debug.WriteLine("Pages.User.LoadPage()");
            Globals.SUBPAGE_REQUEST();
            //Storyboard SB = (Storyboard)FindResource("ShowFrame");
            //SB.Begin();
            Globals.SUBPAGE_URL = "";
        }

        public void HidePage()
        {
            Debug.WriteLine("Pages.User.HidePage()");
            Storyboard SB = (Storyboard)FindResource("HideFrame");
            SB.Begin();
        }

        private void RBSignIn_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.User.RBSignIn_Checked()");
            if (Globals.SUBPAGE_URL != "Login.xaml")
            {
                Globals.SUBPAGE_URL = "Login.xaml";
                HidePage();
            }
        }

        private void RBRegistration_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.User.RBRegistration_Checked()");
            if (Globals.SUBPAGE_URL != "Register.xaml")
            {
                Globals.SUBPAGE_URL = "Register.xaml";
                HidePage();
            }
        }

        private void RBPassword_Checked(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.User.RBPassword_Checked()");
            if (Globals.SUBPAGE_URL != "Reset.xaml")
            {
                Globals.SUBPAGE_URL = "Reset.xaml";
                HidePage();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Pages.User.Page_Loaded()");
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            Debug.WriteLine("Pages.User.LoadLanguage()");
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("1,49,55");

                RBSignIn.Content = hashtable[1].ToString();
                RBRegistration.Content = hashtable[55].ToString();
                RBPassword.Content = hashtable[49].ToString();
            }
            catch { }
        }

        private void CbxMainLanguage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("Pages.User.CbxMainLanguage_SelectionChanged()");
            switch (((ComboBoxItem)CbxMainLanguage.SelectedValue).Content)
            {
                case "English":
                    MainWindow.language = "english";
                    break;
                case "中文 (简体)":
                    MainWindow.language = "mandarin";
                    break;
                case "Français":
                    MainWindow.language = "english";//"french";
                    break;
                case "Deutsche":
                    MainWindow.language = "english";//"german";
                    break;
                case "日本語":
                    MainWindow.language = "english";//"japanese";
                    break;
            }
            FrameLocalContainer.Refresh();
            LoadLanguage();
        }

        private void CbxMainLanguage_Select(string language)
        {
            switch (language)
            {
                case "english":
                    CbxMainLanguage.SelectedIndex = 0;
                    break;
                case "mandarin":
                    CbxMainLanguage.SelectedIndex = 1;
                    break;
                case "french":
                    CbxMainLanguage.SelectedIndex = 2;
                    break;
                case "german":
                    CbxMainLanguage.SelectedIndex = 3;
                    break;
                case "japanese":
                    CbxMainLanguage.SelectedIndex = 4;
                    break;
            }
        }
    }
}
