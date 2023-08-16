using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace CLEANXCEL2._2.Pages.User
{
    /// <summary>
    /// Interaction logic for Reset.xaml
    /// </summary>
    public partial class Reset : Page
    {
        public static Reset AppWindow;
        public Reset()
        {
            InitializeComponent();
            AppWindow = this;
        }

        private void BtnRecover_Click(object sender, RoutedEventArgs e)
        {
            Globals.currentPage = "Reset";
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";
            if (Validate_Email(Email.Text))
            {
                    if (Password.Password != "")
                    {
                        if (Key.Password == Globals.Key)
                            Confirmation();
                    else
                        Globals.POPUP_REQUEST("50", "47", Window.WindowsMessageBox.State.Ok);
                }
                else
                    Globals.POPUP_REQUEST("50", "45", Window.WindowsMessageBox.State.Ok);
            }
            else
                Globals.POPUP_REQUEST("50", "46", Window.WindowsMessageBox.State.Ok);
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
            MySqlCommand mySqlCommand = new MySqlCommand();
            mySqlCommand.Parameters.AddWithValue("@password", Password.Password);
            mySqlCommand.Parameters.AddWithValue("@email", Email.Text);

            Controllers.SQL.Query.ExecuteNonQuery("update user set password=@password where email=@email;", mySqlCommand);

            Pages.User.Index.AppWindow.RBSignIn.IsChecked = true;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("4,6,7,10,11,48");

                ResetPasswordCap.Text = hashtable[10].ToString();
                ResetPasswordDesc.Text = hashtable[11].ToString();
                EmailCap.Text = hashtable[4].ToString();
                NewPasswordCap.Text = hashtable[48].ToString();
                KeyCap.Text = hashtable[6].ToString();
                BtnRecover.Content = hashtable[7].ToString();
            }
            catch { }
        }
    }
}
