using MySql.Data.MySqlClient;
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

namespace CLEANXCEL2._2.UserControls
{
    /// <summary>
    /// Interaction logic for ConditionRow.xaml
    /// </summary>
    public partial class ConditionRow : UserControl
    {
        List<ConditionLabel> conditionlabel = new List<ConditionLabel>();
        public string Language = MainWindow.language;


        public ConditionRow(string category)
        {
            InitializeComponent();
            PopulateVariable(category);
        }

        private void UC_ConditionRow_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Protect_DeleteButton_MouseUp(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as StackPanel).Children.Remove(this);
        }

        public string Encode()
        {
            string variable = conditionlabel.Where(x => x.terms == Equipment.SelectedItem.ToString()).First().variable_name;

            if (Condition.Text != "")
            {
                if (conditionlabel.Where(x => x.terms == Equipment.SelectedItem.ToString()).First().variable_name.ToLower().Contains("en"))
                    return variable + Condition.Text + Bit.IsChecked;
                else
                    return variable + Condition.Text + Value.Text;
            }
            else
                return "";
        }

        private void PopulateVariable(string category)
        {
            try
            {
                string connString = "server=localhost;database=fe01fs;uid=root;password=abcd1234;SSL Mode=none;";
                string query = "select " + Language + ".terms, condition_list.unit, condition_list.variable_name from condition_list inner join " + Language + " on condition_list.description = " + Language + ".id && condition_list.category = '" + category + "';";
                
                MySqlConnection mySqlConnection = new MySqlConnection(connString);
                MySqlCommand mySqlCommand = new MySqlCommand();

                mySqlCommand.Connection = mySqlConnection;
                mySqlCommand.CommandText = query;

                mySqlConnection.Open();

                MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
                while (mySqlDataReader.Read())
                {
                    if (!(mySqlDataReader["variable_name"].ToString().ToLower().Contains("below") || mySqlDataReader["variable_name"].ToString().ToLower().Contains("above")))
                        Equipment.Items.Add(mySqlDataReader["terms"]);
                    conditionlabel.Add(new ConditionLabel() { terms = mySqlDataReader["terms"].ToString(), unit = mySqlDataReader["unit"].ToString(), variable_name = mySqlDataReader["variable_name"].ToString() });
                }

                mySqlConnection.Close();
            }
            catch { }
        }

        private void Equipment_SelectionChanged(object sender, RoutedEventArgs e)
        {
            Condition.Items.Clear();
            Unit.Text = conditionlabel.Where(x => x.terms == Equipment.SelectedItem.ToString()).First().unit;
            if (conditionlabel.Where(x => x.terms == Equipment.SelectedItem.ToString()).First().variable_name.ToLower().Contains("en"))
            {
                Condition.Items.Add("=");
                Bit.IsChecked = true;
                BitBorder.Visibility = Visibility.Visible;
                Value.Visibility = Visibility.Hidden;
            }
            else
            {
                Condition.Items.Add(">");
                Condition.Items.Add("<");
                BitBorder.Visibility = Visibility.Hidden;
                Value.Visibility = Visibility.Visible;
            }
            Condition.SelectedIndex = 0;
        }

        public void Decode(string variable, string condition, string value)
        {
            Equipment.SelectedItem = conditionlabel.Where(x => x.variable_name == variable).First().terms;
            Condition.SelectedItem = condition;

            if (value == "true" || value == "false")
                    Bit.IsChecked = Convert.ToBoolean(value);
                else
                    Value.Text = value;
        }

        private struct ConditionLabel
        {
            public string variable_name;
            public string terms;
            public string unit;
        }
    }
}
