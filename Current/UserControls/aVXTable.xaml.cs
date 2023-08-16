using MySql.Data.MySqlClient;
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
    /// Interaction logic for Table.xaml
    /// </summary>
    public partial class aVXTable : UserControl
    {
        public string ProcessName;
        Hashtable hashtable;

        public aVXTable()
        {
            InitializeComponent();
            LoadLanguage();
        }

        public string Title
        {
            get { return (string)GetValue(SetTitleProperty); }
            set { SetValue(SetTitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SetTitle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SetTitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(aVXTable), new PropertyMetadata(new PropertyChangedCallback(OnSetTitleChanged)));


        private static void OnSetTitleChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            aVXTable avxTable = d as aVXTable;
            avxTable.OnSetTitleChanged(e);
        }

        private void OnSetTitleChanged(DependencyPropertyChangedEventArgs e)
        {
            title.Text = e.NewValue.ToString();
        }

        public double Start
        {
            get { return (double)GetValue(StartProperty); }
            set { SetValue(StartProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Start.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StartProperty =
            DependencyProperty.Register("Start", typeof(double), typeof(aVXTable), new PropertyMetadata((double)0));

        public double Hold
        {
            get { return (double)GetValue(HoldProperty); }
            set { SetValue(HoldProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hold.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoldProperty =
            DependencyProperty.Register("Hold", typeof(double), typeof(aVXTable), new PropertyMetadata((double)0));

        public double Release
        {
            get { return (double)GetValue(ReleaseProperty); }
            set { SetValue(ReleaseProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Release.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReleaseProperty =
            DependencyProperty.Register("Release", typeof(double), typeof(aVXTable), new PropertyMetadata((double)0));

        public double Pulses
        {
            get { return (double)GetValue(PulsesProperty); }
            set { SetValue(PulsesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Pulses.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PulsesProperty =
            DependencyProperty.Register("Pulses", typeof(double), typeof(aVXTable), new PropertyMetadata((double)0));

        public double VacuumLevel
        {
            get { return (double)GetValue(VacuumLevelProperty); }
            set { SetValue(VacuumLevelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for VacuumLevel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VacuumLevelProperty =
            DependencyProperty.Register("VacuumLevel", typeof(double), typeof(aVXTable), new PropertyMetadata((double)0));

        public void Encode()
        {
            Controllers.RecipeManagement.SubProcessBlock.aVX.Encode_aVX(title.Text,
                            Convert.ToInt32(Start.ToString()),
                            Convert.ToInt32(Hold.ToString()),
                            Convert.ToInt32(Pulses.ToString()),
                            Convert.ToInt32(VacuumLevel.ToString()));
        }

        private void Protect_DeleteButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as StackPanel).Children.Remove(this);
        }

        private void LoadLanguage()
        {
            try
            {
                hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("133,168,169,170,946");

                TBStartTitle.Text = hashtable[133].ToString();
                TBHoldTitle.Text = hashtable[168].ToString();
                //TBReleaseTitle.Text = hashtable[169].ToString();
                TBPulsesTitle.Text = hashtable[170].ToString();
                TBVacuumTitle.Text = hashtable[946].ToString();
            }
            catch (NullReferenceException) { }
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
    }
}
