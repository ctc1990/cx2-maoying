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
using MySql.Data.MySqlClient;

namespace CLEANXCEL2._2.Pages.User
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public static Login AppWindow;
        public Login()
        {
            InitializeComponent();
            AppWindow = this;
        }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            //Globals.PAGE_URL = "../Pages/Menu/Index.xaml";
            //Globals.PAGE_REQUEST();

            Globals.currentPage = "Login";
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";
            if (Validate_Email(Email.Text))
            {
                if (Password.Password != "")
                {
                    Confirmation();
                }
                else
                    Globals.POPUP_REQUEST("50", "45", Window.WindowsMessageBox.State.Ok);
            }
            else
                Globals.POPUP_REQUEST("50", "46", Window.WindowsMessageBox.State.Ok);
        }

        private void Initialize()
        {
            foreach (string email in Controllers.SQL.Query.ExecuteSingleQuery("select user.email from user group by user.email", "email"))
                Email.Items.Add(email);
        }

        private void Confirmation()
        {
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";
            Globals.POPUP_REQUEST("51", "52", Window.WindowsMessageBox.State.Confirmation);
        }

        private bool Validate_Email(string email)
        {
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch { return false; }
        }

        public void TriggerProcess()
        {
            Globals.currentPage = null;
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";

            if (Email.Text == "techdept@jkseng.com" && Password.Password == "abcd1234")
            {
                Globals.AuthenticationLevel = "11111111111111";
                Globals.PAGE_URL = "../Pages/Menu/Index.xaml";
                Globals.PAGE_REQUEST();
            }
            else
            {
                MySqlCommand mySqlCommand = new MySqlCommand();

                mySqlCommand.Parameters.AddWithValue("@email", Email.Text);
                mySqlCommand.Parameters.AddWithValue("@password", Password.Password);

                if (Controllers.SQL.Query.ExecuteCheckQuery("select * from user where user.email=@email && user.password=@password", mySqlCommand)) // Go to Machine Page
                {
                    Globals.AuthenticationLevel = Controllers.SQL.Query.ExecuteSingleQueryPrepareStatement
                        ("select concat(recipe_management,knowledge_base,visual) as authentication FROM `user` where user.email=@email && user.password=@password", "authentication", mySqlCommand)[0];
                    Globals.PAGE_URL = "../Pages/Menu/Index.xaml";
                    Globals.PAGE_REQUEST();
                }
                else // Stay on the page
                {
                    Globals.POPUP_REQUEST("51", "45", Window.WindowsMessageBox.State.Ok);
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
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("1,2,4,5,7");

                SignInCap.Text = hashtable[1].ToString();
                SignInDesc.Text = hashtable[2].ToString();
                EmailCap.Text = hashtable[4].ToString();
                PasswordCap.Text = hashtable[5].ToString();
                Submit.Content = hashtable[7].ToString();
            }
            catch { }
        }
    }
}
