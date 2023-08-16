using System;
using System.Collections;
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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CLEANXCEL2._2.UserControls
{
    /// <summary>
    /// Interaction logic for DigitalDisplay.xaml
    /// </summary>
    public partial class DigitalDisplay : UserControl, INotifyPropertyChanged
    {
        public DigitalDisplay()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        string m_EqName = default(string);
        public string EqName
        {
            get
            {
                return m_EqName;
            }

            set
            {
                SetProperty(ref m_EqName, value);
            }
        }

        string m_Location = default(string);
        public string Location
        {
            get
            {
                return m_Location;
            }

            set
            {
                SetProperty(ref m_Location, value);
            }
        }

        string m_MeasurementName = default(string);
        public string MeasurementName
        {
            get
            {
                return m_MeasurementName;
            }

            set
            {
                SetProperty(ref m_MeasurementName, value);
            }
        }

        string m_Unit = default(string);
        public string Unit
        {
            get
            {
                return m_Unit;
            }

            set
            {
                SetProperty(ref m_Unit, value);
            }
        }

        string m_LogicName = default(string);
        public string LogicName
        {
            get
            {
                return m_LogicName;
            }

            set
            {
                SetProperty(ref m_LogicName, value);
            }
        }

        string m_Logic = default(string);
        public string Logic
        {
            get
            {
                return m_Logic;
            }

            set
            {
                SetProperty(ref m_Logic, value);
            }
        }

        double m_ActualValue = default(double);
        public double ActualValue
        {
            get
            {
                return m_ActualValue;
            }

            set
            {
                SetProperty(ref m_ActualValue, value);
            }
        }

        string m_ValueSet = default(string);
        public string ValueSet
        {
            get
            {
                return m_ValueSet;
            }

            set
            {
                SetProperty(ref m_ValueSet, value);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("172");
                
                TBSetValueTitle.Text = hashtable[172].ToString();
            }
            catch (NullReferenceException) { }
        }
    }
}
