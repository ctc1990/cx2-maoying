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
    /// Interaction logic for Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
        private bool mutexKey = true;
        public static Roles AppWindow;
        public Roles()
        {
            InitializeComponent();
            AppWindow = this;
        }

        private void RB_Clicked(object sender, RoutedEventArgs e)
        {
            bool? state = ((CheckBox)sender).IsChecked;
            if (mutexKey)
            {
                CbxRoles.SelectedIndex = CbxRoles.Items.Count - 1;
                ((CheckBox)sender).IsChecked = state;
            }
        }

        private void PopulateRoles(Hashtable hashtable)
        {
            List<string> data = new List<string>(); // to be populated from DB

            CBxIProfessional.Content = hashtable[15].ToString();
            CBxIEngineer.Content = hashtable[16].ToString();
            CBxISupervisor.Content = hashtable[17].ToString();
            CBxIAnalyst.Content = hashtable[18].ToString();
            CBxIMaintenance.Content = hashtable[19].ToString();
            CBxIOperator.Content = hashtable[20].ToString();
            CBxICustom.Content = hashtable[56].ToString();
            //data.Add(hashtable[15].ToString());
            //data.Add(hashtable[16].ToString());
            //data.Add(hashtable[17].ToString());
            //data.Add(hashtable[18].ToString());
            //data.Add(hashtable[19].ToString());
            //data.Add(hashtable[20].ToString());
            //data.Add(hashtable[56].ToString());
            //CbxRoles.ItemsSource = data;
            CbxRoles.Text = hashtable[14].ToString();
        }

        private void PopulateLanguages(Hashtable hashtable)
        {
            List<string> data = new List<string>(); // to be populated from DB

            data.Add(hashtable[22].ToString());
            data.Add(hashtable[23].ToString());
            data.Add(hashtable[24].ToString());
            data.Add(hashtable[25].ToString());
            data.Add(hashtable[26].ToString());

            CbxLanguage.ItemsSource = data;
            CbxLanguage.Text = hashtable[21].ToString();
            CbxLanguage.SelectedIndex = 0;
        }

        private void CbxRoles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            mutexKey = false;
            switch (CbxRoles.SelectedIndex)
            {
                case 0:
                    SetRoles("11111111", "1111", "11");
                    break;
                case 1:
                    SetRoles("11111011", "1111", "10");
                    break;
                case 2:
                    SetRoles("01111010", "1111", "10");
                    break;
                case 3:
                    SetRoles("00010010", "1111", "11");
                    break;
                case 4:
                    SetRoles("00011010", "1111", "10");
                    break;
                case 5:
                    SetRoles("00010010", "1111", "10");
                    break;
                case 6:
                    SetRoles("00000000", "0000", "00");
                    break;
                //case 7:
                //    SetRoles("000000", "0000", "00");
                //    break;
            }
            mutexKey = true;
        }

        private void SetRoles(string recipe_management, string knowledge_base, string visualisation)
        {
            RBComplexRecipe.IsChecked = isTrue(recipe_management.Substring(0, 1));
            RBSimpleRecipe.IsChecked = isTrue(recipe_management.Substring(1, 1));
            RBGuidedRecipe.IsChecked = isTrue(recipe_management.Substring(2, 1));
            RBFixedRecipe.IsChecked = isTrue(recipe_management.Substring(3, 1));
            RBMaintenance.IsChecked = isTrue(recipe_management.Substring(4, 1));
            RBBypass.IsChecked = isTrue(recipe_management.Substring(5, 1));
            RBDefault.IsChecked = isTrue(recipe_management.Substring(6, 1));
            RBArmProfile.IsChecked = isTrue(recipe_management.Substring(7, 1));

            RBOperationManual.IsChecked = isTrue(knowledge_base.Substring(0, 1));
            RBProcessVideo.IsChecked = isTrue(knowledge_base.Substring(1, 1));
            RBSpareParts.IsChecked = isTrue(knowledge_base.Substring(2, 1));
            RBTutorial.IsChecked = isTrue(knowledge_base.Substring(3, 1));

            RBCurrentStatus.IsChecked = isTrue(visualisation.Substring(0, 1));
            RBAnalytics.IsChecked = isTrue(visualisation.Substring(1, 1));
        }

        private void GetRoles()
        {
            Get_RecipeManagement();
            Get_KnowledgeBase();
            Get_Visualisation();
        }

        private bool isTrue(string a)
        {
            return a == "1" ? true : false;
        }

        private string isOne(bool? a)
        {
            return a==true ? "1" : "0";
        }

        private string Get_RecipeManagement()
        {
            string a = "";
            a += isOne(RBComplexRecipe.IsChecked);
            a += isOne(RBSimpleRecipe.IsChecked);
            a += isOne(RBGuidedRecipe.IsChecked);
            a += isOne(RBFixedRecipe.IsChecked);
            a += isOne(RBMaintenance.IsChecked);
            a += isOne(RBBypass.IsChecked);
            a += isOne(RBDefault.IsChecked);
            a += isOne(RBArmProfile.IsChecked);

            return a;
        }

        private string Get_KnowledgeBase()
        {
            string a = "";
            a += isOne(RBOperationManual.IsChecked);
            a += isOne(RBProcessVideo.IsChecked);
            a += isOne(RBSpareParts.IsChecked);
            a += isOne(RBTutorial.IsChecked);

            return a;
        }

        private string Get_Visualisation()
        {
            string a = "";
            a += isOne(RBCurrentStatus.IsChecked);
            a += isOne(RBAnalytics.IsChecked);

            return a;
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            Confirmation();
        }

        private void Confirmation()
        {
            Globals.currentPage = "Roles";
            Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";
            if (CbxRoles.SelectedItem != null)
            {
                if (CbxLanguage.SelectedItem != null)
                {
                    Globals.POPUP_URL = "Pages/Window/WindowsMessageBox.xaml";
                    Globals.POPUP_REQUEST("51", "52", Window.WindowsMessageBox.State.Confirmation);
                }
                else
                    Globals.POPUP_REQUEST("50", "53", Window.WindowsMessageBox.State.Ok);
            }
            else
                Globals.POPUP_REQUEST("50", "54", Window.WindowsMessageBox.State.Ok);
        }

        public void TriggerProcess()
        {
            Globals.currentPage = null;
            MySqlCommand mySqlCommand = new MySqlCommand();

            PassingParameters.RegisterRoles.user_info user_Info = (PassingParameters.RegisterRoles.user_info)Globals.passingParameters;

            mySqlCommand.Parameters.AddWithValue("@username", user_Info.name);
            mySqlCommand.Parameters.AddWithValue("@password", user_Info.password);
            mySqlCommand.Parameters.AddWithValue("@email", user_Info.email);
            mySqlCommand.Parameters.AddWithValue("@roles", CbxRoles.SelectedItem);
            mySqlCommand.Parameters.AddWithValue("@recipe_management", Get_RecipeManagement());
            mySqlCommand.Parameters.AddWithValue("@knowledge_base", Get_KnowledgeBase());
            mySqlCommand.Parameters.AddWithValue("@visualisation", Get_Visualisation());
            mySqlCommand.Parameters.AddWithValue("@language", CbxLanguage.SelectedItem);

            Controllers.SQL.Query.ExecuteNonQuery("insert into user (username, password, email, roles, recipe_management, knowledge_base, visual, language, status) values(" +
                "@username, @password, @email, @roles, @recipe_management, @knowledge_base, @visualisation, @language, '11');", mySqlCommand);

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
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("7,12,13,14,15,16,17,18,19,20,56,21,22,23,24,25,26,27," +
                    "                                                           32,33,34,35,36,37,38,39,40,125,137,138,139,140,164,165,166,167");

                ChooseRoleCap.Text = hashtable[12].ToString();
                ChooseRoleDesc.Text = hashtable[13].ToString();
                PopulateRoles(hashtable);
                PopulateLanguages(hashtable);
                BtnRegister.Content = hashtable[7].ToString();

                RecipeManagementCap.Text = hashtable[27].ToString();
                RBComplexRecipe.Content = hashtable[137].ToString();
                RBSimpleRecipe.Content = hashtable[138].ToString();
                RBGuidedRecipe.Content = hashtable[139].ToString();
                RBFixedRecipe.Content = hashtable[140].ToString();
                RBMaintenance.Content = hashtable[19].ToString();
                RBBypass.Content = hashtable[125].ToString();
                RBDefault.Content = hashtable[32].ToString();
                RBArmProfile.Content = hashtable[33].ToString();

                KnowledgeBasedCap.Text = hashtable[34].ToString();
                RBOperationManual.Content = hashtable[164].ToString();
                RBProcessVideo.Content = hashtable[165].ToString();
                RBSpareParts.Content = hashtable[166].ToString();
                RBTutorial.Content = hashtable[167].ToString();

                VisualisationCap.Text = hashtable[38].ToString();
                RBCurrentStatus.Content = hashtable[39].ToString();
                RBAnalytics.Content = hashtable[40].ToString();
            }
            catch { }
        }
    }
}
