using MySql.Data.MySqlClient;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CLEANXCEL2._2.Pages.User
{
    /// <summary>
    /// Interaction logic for Register.xaml
    /// </summary>
    public partial class Register : Page
    {
        public Register()
        {
            InitializeComponent();
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            // field validations
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";
            if (Name.Text != "")
            {
                if (Password.Password != "")
                {
                    if (Validate_Email(Email.Text))
                    {
                        if (Key.Password == Globals.Key)
                        {
                            PassingParameters.RegisterRoles passingParameters = new PassingParameters.RegisterRoles();

                            Globals.passingParameters = passingParameters.ToRoles(Name.Text, Email.Text.ToLower().Trim(), Password.Password);
                            Globals.SUBPAGE_URL = "Roles.xaml";
                            Globals.SUBPAGE_REQUEST();
                        }
                        else
                            Globals.POPUP_REQUEST("50", "47", Window.WindowsMessageBox.State.Ok);
                    }
                    else
                        Globals.POPUP_REQUEST("50", "46", Window.WindowsMessageBox.State.Ok);
                }
                else
                    Globals.POPUP_REQUEST("50", "45", Window.WindowsMessageBox.State.Ok);
            }
            else
                Globals.POPUP_REQUEST("50", "44", Window.WindowsMessageBox.State.Ok);
        }

        private bool Validate_Email(string email)
        {
            try
            {
                System.Net.Mail.MailAddress mailAddress = new System.Net.Mail.MailAddress(email);
                return true;
            }
            catch (System.FormatException) { return false; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("3,4,5,6,7,8,9");

                RegisterCap.Text = hashtable[8].ToString();
                RegisterDesc.Text = hashtable[9].ToString();
                NameCap.Text = hashtable[3].ToString();
                EmailCap.Text = hashtable[4].ToString();
                PasswordCap.Text = hashtable[5].ToString();
                KeyCap.Text = hashtable[6].ToString();
                BtnRegister.Content = hashtable[7].ToString();
            }
            catch { }
        }
    }
}
