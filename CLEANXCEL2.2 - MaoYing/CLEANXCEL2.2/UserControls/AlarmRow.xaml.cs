using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CLEANXCEL2._2.UserControls
{
    /// <summary>
    /// Interaction logic for AlarmRow.xaml
    /// </summary>
    public partial class AlarmRow : UserControl
    {
        bool active = false;
        string ColorStatus = "CBlack";
        private List<AlarmInfo> Items = new List<AlarmInfo>();
        public string ID { get { return id.Text; } set { id.Text = value; } }
        public string AlarmCode { get { return code.Text; } set { code.Text = value; } }
        public string DateTime { get { return date.Text; } set { date.Text = value; } }
        public string IO { get { return io.Text; } set { io.Text = value; } }
        public string Languages = MainWindow.language;

        public AlarmRow()
        {
            InitializeComponent();
        }

        private void UserWindow_Loaded(object sender, RoutedEventArgs e)
        {
            Query();
        }

        public void Query()
        {
            string MyConString =
                   "SERVER=localhost;" +
                   "DATABASE=fe01fs;" +
                   "UID=root;" +
                   "PASSWORD=abcd1234;" +
                   "SSLMode=none;";
            if (CallAlarmCodeDesc(AlarmCode, MyConString))
            {
                CallAlarmInfo(AlarmCode, MyConString);
                CallAlarmIO(IO, MyConString);
            }
            else
            {
                AlarmCode = "ER999";
                CallAlarmCodeDesc(AlarmCode, MyConString);
                CallAlarmInfo(AlarmCode, MyConString);
                CallAlarmIO(IO, MyConString);
                ColorStatus = "DarkGreenBlueColor";
                Foreground = (Brush)FindResource("DarkGreenBlueColor");
            }
            Actions.ItemsSource = Items;
        }

        private bool CallAlarmCodeDesc(string code, string MyConString)
        {
            bool ErrorState = false;
            string sql = "select terms from (select description from alarm_code  where code = '" + code + "') a inner join " + Languages + " b where a.description = b.id";

            MySqlConnection mySqlConnection = new MySqlConnection(MyConString);
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                description.Text = mySqlDataReader["terms"].ToString();
                ErrorState = true;
            }
            mySqlConnection.Close();

            return ErrorState;
        }

        private void CallAlarmIO(string io, string MyConString)
        {
            string sql = "select " + MainWindow.language + ".terms, io_list.station, io_list.tag from io_list inner join " + MainWindow.language + " on io_list.name = " + MainWindow.language + ".id where io_code = '" + io + "'";

            MySqlConnection mySqlConnection = new MySqlConnection(MyConString);
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                station.Text = mySqlDataReader["station"].ToString();
                equipment_description.Text = mySqlDataReader["terms"].ToString();
                //equipment.Text = mySqlDataReader["terms"].ToString();
                //tag.Text = mySqlDataReader["tag"].ToString();
            }
            mySqlConnection.Close();
        }

        private void CallAlarmInfo(string code, string MyConString)
        {
            string temp = "";

            string sql = "select terms from (select possibility from alarm_action  where fk_code = '" + code + "') a inner join " + Languages + " b where a.possibility = b.id";

            MySqlConnection mySqlConnection = new MySqlConnection(MyConString);
            MySqlCommand mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            mySqlConnection.Open();
            MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
            while (mySqlDataReader.Read())
            {
                if (temp != mySqlDataReader["terms"].ToString())
                    Items.Add(new AlarmInfo()
                    {
                        POSSIBILITIES = mySqlDataReader["terms"].ToString(),
                        STATUS = false
                    });
                else
                    Items.Add(new AlarmInfo()
                    {
                        POSSIBILITIES = "",
                        STATUS = false
                    });
                temp = mySqlDataReader["terms"].ToString();
            }
            mySqlDataReader.Close();

            sql = "select terms from (select action from alarm_action  where fk_code = '" + code + "') a inner join " + Languages + " b where a.action = b.id";

            mySqlCommand = new MySqlCommand(sql, mySqlConnection);
            mySqlDataReader = mySqlCommand.ExecuteReader();
            int i = 0;
            while (mySqlDataReader.Read())
            {
                Items[i++].ACTIONS = mySqlDataReader["terms"].ToString();
            }

            mySqlConnection.Close();
        }

        public class AlarmInfo : INotifyPropertyChanged
        {
            private string possibilities;
            public string POSSIBILITIES
            {
                get { return possibilities; }
                set { possibilities = value; ReportChange("Possibilities"); }
            }

            private string actions;
            public string ACTIONS
            {
                get { return actions; }
                set { actions = value; ReportChange("Actions"); }
            }

            private bool status;
            public bool STATUS
            {
                get { return status; }
                set { status = value; ReportChange("Status"); }
            }

            #region INotifyPropertyChanged Members

            public event PropertyChangedEventHandler PropertyChanged;
            private void ReportChange(string propertyName)
            {
                if (null != PropertyChanged) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

            #endregion
        }

        private void Error()
        {
            Items.Add(new AlarmInfo()
            {
                POSSIBILITIES = "Device is not connected to machine",
                ACTIONS = "Please ping for machine device.",
                //ACTIONS = "Check inverter MCCB (refer to electrical diagram) and make sure in ON condition. Picture shown the inverter is ON.",
                STATUS = false
            });

            Items.Add(new AlarmInfo()
            {
                POSSIBILITIES = "",
                ACTIONS = "Please ensure AMS Net ID is correctly configured.",
                STATUS = false
            });

            Items.Add(new AlarmInfo()
            {
                POSSIBILITIES = "Software is not updated to latest version",
                ACTIONS = "Please refer to manufacturer for the latest version of software.",
                STATUS = false
            });
        }

        private void MoreDetails_Click(object sender, RoutedEventArgs e)
        {
            if (active)
            {
                Foreground = (Brush)FindResource(ColorStatus);
                Background = (Brush)FindResource("Transparent");
                Height = 60;
                //Storyboard storyboard = (Storyboard)FindResource("ShowDetails");
                //storyboard.Begin();
                active = false;
            }
            else
            {
                Foreground = (Brush)FindResource("CWhite");
                Background = (Brush)FindResource("AlarmPinkH3");
                Height = Double.NaN;
                //Storyboard storyboard = (Storyboard)FindResource("HideDetails");
                //storyboard.Begin();
                active = true;
            }
        }
    }
}
