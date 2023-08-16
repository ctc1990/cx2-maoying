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

namespace CLEANXCEL2._2.Pages.Window
{
    /// <summary>
    /// Interaction logic for WindowsMessageBox.xaml
    /// </summary>
    public partial class WindowsMessageBox : Page
    {
        private static string s_caption;
        private static string s_message;
        private static State s_state;
        public static WindowsMessageBox AppWindow;

        public WindowsMessageBox(string caption, string message, State state)
        {
            InitializeComponent();
            AppWindow = this;
            
            s_caption = caption;
            s_message = message;
            s_state = state;
        }

        private void ButtonYes_Click(object sender, RoutedEventArgs e)
        {
            Globals.POPDOWN_REQUEST();
        }

        private void ButtonCancel_Click(object sender, RoutedEventArgs e)
        {
            Globals.currentPage = "";
            Globals.passingParameters = false;
            Globals.POPDOWN_REQUEST();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery(s_caption + "," + s_message + ",81,82");

                switch (s_state)
                {
                    case State.Confirmation:
                        ButtonYes.Visibility = Visibility.Visible;
                        ButtonOK.Visibility = Visibility.Hidden;
                        ButtonCancel.Visibility = Visibility.Visible;
                        ButtonYes.Content = hashtable[81].ToString();
                        ButtonCancel.Content = hashtable[82].ToString();
                        break;
                    case State.Ok:
                        ButtonYes.Visibility = Visibility.Hidden;
                        ButtonOK.Visibility = Visibility.Visible;
                        ButtonCancel.Visibility = Visibility.Hidden;
                        ButtonOK.Content = hashtable[81].ToString();
                        break;
                }

                Caption.Text = hashtable[Convert.ToInt32(s_caption)].ToString();
                Message.Text = hashtable[Convert.ToInt32(s_message)].ToString();
            }
            catch { }
        }

        public void PopDown_Completed()
        {
            switch (Globals.currentPage)
            {
                case "Login":
                    ((MainWindow.AppWindow.FrameContainer.Content as Pages.User.Index).FrameLocalContainer.Content as Pages.User.Login).TriggerProcess();
                    break;
                case "Reset":
                    ((MainWindow.AppWindow.FrameContainer.Content as Pages.User.Index).FrameLocalContainer.Content as Pages.User.Reset).TriggerProcess();
                    break;
                case "Roles":
                    ((MainWindow.AppWindow.FrameContainer.Content as Pages.User.Index).FrameLocalContainer.Content as Pages.User.Roles).TriggerProcess();
                    break;
                case "SubProcess":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.RecipeManagement.Index).
                        FrameLocalContainer.Content as Pages.Menu.RecipeManagement.SubProcess).TriggerProcess();
                    break;
                case "SubProcessOverwrite":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.RecipeManagement.Index).
                        FrameLocalContainer.Content as Pages.Menu.RecipeManagement.SubProcess).TriggerOverwriteProcess();
                    break;
                case "Process":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.RecipeManagement.Index).
                        FrameLocalContainer.Content as Pages.Menu.RecipeManagement.Process).TriggerProcess();
                    break;
                case "ProcessOverwrite":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.RecipeManagement.Index).
                        FrameLocalContainer.Content as Pages.Menu.RecipeManagement.Process).TriggerOverwriteProcess();
                    break;
                case "Recipe":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.RecipeManagement.Index).
                        FrameLocalContainer.Content as Pages.Menu.RecipeManagement.Recipe).TriggerProcess();
                    break;
                case "RecipeOverwrite":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.RecipeManagement.Index).
                        FrameLocalContainer.Content as Pages.Menu.RecipeManagement.Recipe).TriggerOverwriteProcess();
                    break;
                case "Part":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.RecipeManagement.Index).
                        FrameLocalContainer.Content as Pages.Menu.RecipeManagement.Part).TriggerProcess();
                    break;
                case "General":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.DefaultSettings.Index).
                        FrameLocalContainer.Content as Pages.Menu.DefaultSettings.General).TriggerProcess();
                    break;
                case "Station1":
                    (((MainWindow.AppWindow.FrameContainer.Content as Pages.Menu.Index).FrameContainer.Content as Pages.Menu.DefaultSettings.Index).
                        FrameLocalContainer.Content as Pages.Menu.DefaultSettings.Station1).TriggerProcess();
                    break;
            }
        }

        public enum State
        {
            Confirmation,
            Ok
        }
    }
}
