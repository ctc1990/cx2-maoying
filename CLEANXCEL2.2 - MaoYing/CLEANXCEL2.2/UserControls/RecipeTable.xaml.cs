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
    public partial class RecipeTable : UserControl
    {
        public string ProcessName;
        Hashtable hashtable;

        public RecipeTable()
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
            DependencyProperty.Register("Title", typeof(string), typeof(RecipeTable), new PropertyMetadata(new PropertyChangedCallback(OnSetTitleChanged)));


        private static void OnSetTitleChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            RecipeTable recipeTable = d as RecipeTable;
            recipeTable.OnSetTitleChanged(e);
        }

        private void OnSetTitleChanged(DependencyPropertyChangedEventArgs e)
        {
            title.Text = e.NewValue.ToString();
        }

        public double ProcessTime
        {
            get { return (double)GetValue(ProcessTimeProperty); }
            set { SetValue(ProcessTimeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ProcessTime.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProcessTimeProperty =
            DependencyProperty.Register("ProcessTime", typeof(double), typeof(RecipeTable), new PropertyMetadata((double)0));

        public double Power
        {
            get { return (double)GetValue(PowerProperty); }
            set { SetValue(PowerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Power.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PowerProperty =
            DependencyProperty.Register("Power", typeof(double), typeof(RecipeTable), new PropertyMetadata((double)0));

        public double Frequency
        {
            get { return (double)GetValue(FrequencyProperty); }
            set { SetValue(FrequencyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Frequency.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FrequencyProperty =
            DependencyProperty.Register("Frequency", typeof(double), typeof(RecipeTable), new PropertyMetadata((double)0));

        // Using a DependencyProperty as the backing store for VacuumLevel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VacuumLevelProperty =
            DependencyProperty.Register("VacuumLevel", typeof(double), typeof(RecipeTable), new PropertyMetadata((double)0));

        public void Encode()
        {
            Controllers.RecipeManagement.API.Recipe.Create_SQLRecipe(Title, ProcessTime.ToString(), Power.ToString(), Frequency.ToString());
        }

        private void Protect_DeleteButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as StackPanel).Children.Remove(this);
        }

        private void LoadLanguage()
        {
            try
            {
                hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("135,136,950");
                TBPowerTitle.Text = hashtable[135].ToString();
                TBFrequencyTitle.Text = hashtable[136].ToString();
                TBProcessTimeTitle.Text = hashtable[950].ToString();
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
