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
    public partial class StandardTable : UserControl
    {
        private int TotalProcessTime = 0;
        public Categories Category;
        public string ProcessName;
        public string Time;
        public string Parameters;
        private int Count = 0;
        Hashtable hashtable;

        public StandardTable()
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
            DependencyProperty.Register("Title", typeof(string), typeof(StandardTable), new PropertyMetadata(new PropertyChangedCallback(OnSetTitleChanged)));

        private void Render_SubProcess(string Title)
        {
            foreach (string equipmentname in Controllers.SQL.Query.ExecuteSingleQuery("select distinct sub_process.equipment_name from sub_process left join sub_process_id on sub_process_id.id = sub_process.sub_process_name where sub_process_id.name='" + Title + "'", "equipment_name"))
            {
                RangeSlider rangeSlider = new RangeSlider()
                {
                    Slider_Label = equipmentname,              // Store Equipment Label
                    Minimum = 0,                                // Minimum Value of Slider
                    Maximum = 3600,                             // Maximum Value of Slider
                    Start = 0,                                  // Start Point of Slider
                    End = 500,                                 // End Point of Slider
                    Slider_Width = this.Width - RangeSliderStackPanel.Margin.Left - RangeSliderStackPanel.Margin.Right,           // Slider Width     
                    Slider_Height = 20                          // Slider Height
                };
                rangeSlider.ValueChanged += RangeSlider_ValueChanged;

                RangeSliderStackPanel.Children.Add(rangeSlider);
            }
        }

        private void Decode_SubProcess(string Title)
        {
            List<string> subprocessname = Controllers.SQL.Query.ExecuteSingleQuery("select distinct sub_process.equipment_name from sub_process left join sub_process_id on sub_process_id.id = sub_process.sub_process_name where sub_process_id.name='" + Title + "'", "equipment_name");
            string[] ParseTime = Time.Split(':', '~');

            for (int i = 0; i < subprocessname.Count(); i++)
            {
                RangeSlider rangeSlider = new RangeSlider()
                {
                    Slider_Label = subprocessname[i],              // Store Equipment Label
                    Minimum = 0,                                // Minimum Value of Slider
                    Maximum = 3600,                             // Maximum Value of Slider
                    End = Convert.ToDouble(ParseTime[(i * 2) + 1]),                                 // End Point of Slider
                    Start = Convert.ToDouble(ParseTime[i * 2]),                                  // Start Point of Slider
                    Slider_Width = this.Width - RangeSliderStackPanel.Margin.Left - RangeSliderStackPanel.Margin.Right,           // Slider Width     
                    Slider_Height = 20                          // Slider Height
                };
                rangeSlider.ValueChanged += RangeSlider_ValueChanged; ;

                RangeSliderStackPanel.Children.Add(rangeSlider);
            }
        }

        //private void Render_SubProcess(string Title)
        //{
        //    Count = Controllers.SQL.Query.ExecuteSingleQuery("select distinct sub_process.equipment_name from sub_process where sub_process.sub_process_name='" + Title + "'", "equipment_name").Count();
        //    RangeSliderStackPanel.Children.Add(new RangeSlider()
        //    {
        //        Slider_Label = "All", //subprocessname,              // Store Equipment Label
        //        Minimum = 0,                                // Minimum Value of Slider
        //        Maximum = 3600,                             // Maximum Value of Slider
        //        Start = 0,                                  // Start Point of Slider
        //        Duration = 500,                                 // End Point of Slider
        //        Slider_Width = this.Width - RangeSliderStackPanel.Margin.Left - RangeSliderStackPanel.Margin.Right,           // Slider Width     
        //        Slider_Height = 20                          // Slider Height
        //    });
        //}

        //private void Decode_SubProcess(string Title)
        //{
        //    Count = Controllers.SQL.Query.ExecuteSingleQuery("select distinct sub_process.equipment_name from sub_process where sub_process.sub_process_name='" + Title + "'", "equipment_name").Count();
        //    string[] ParseTime = Time.Split(':', '~');

        //    //for (int i = 0; i < subprocessname.Count(); i++)
        //    RangeSliderStackPanel.Children.Add(new RangeSlider
        //    {
        //        Slider_Label = "All", //subprocessname[i],              // Store Equipment Label
        //        Minimum = 0,                                // Minimum Value of Slider
        //        Maximum = 3600,                             // Maximum Value of Slider
        //        End = Convert.ToDouble(ParseTime[1]), //(i * 2) + 1]),                                 // End Point of Slider
        //        Start = Convert.ToDouble(ParseTime[0]), //i * 2]),                                  // Start Point of Slider
        //        Slider_Width = this.Width - RangeSliderStackPanel.Margin.Left - RangeSliderStackPanel.Margin.Right,           // Slider Width     
        //        Slider_Height = 20                          // Slider Height
        //    });
        //}

        private void Render_Process()
        {
            List<int> list = new List<int>();
            foreach (string processconditions in Controllers.SQL.Query.ExecuteSingleQuery("select process.conditions from process where process.process_name='" + Title + "'", "conditions"))
            {
                list.AddRange(processconditions.Split(':', '~').Select(x => Convert.ToInt32(x)));
            }
            TotalProcessTime = list.Max() - list.Min();
            RangeSliderStackPanel.Children.Add(new TextBlock() { Style = (Style)FindResource("Desc"), Text = hashtable[950].ToString() + ": " + TotalProcessTime + "s", Margin = new Thickness(0, 10, 0, 0) });
            
            if (Controllers.SQL.Query.ExecuteCheckQuery("select process.process_name, process.sub_process_name, sub_process.equipment_name from process right join sub_process on process.sub_process_name = sub_process.sub_process_name where (sub_process.equipment_name = 'US' and process.process_name ='" + Title + "')", new MySqlCommand()))
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                TextBlock textblock = new TextBlock() {Style = (Style)FindResource("Label"), Text= hashtable[135].ToString() + " (%)", Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                TextBox textBox = new TextBox() { Name = "Power", Style = (Style)FindResource("TextBox"), Margin = new Thickness(0, 10, 0, 0), Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                stackPanel.Children.Add(textblock);
                stackPanel.Children.Add(textBox);
                RegisterName("Power", textBox);
                RangeSliderStackPanel.Children.Add(stackPanel);

                stackPanel = new StackPanel();

                textblock = new TextBlock() { Style = (Style)FindResource("Label"), Text = hashtable[136].ToString() + " (kHz)", Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                textBox = new TextBox() { Name = "Frequency", Style = (Style)FindResource("TextBox"), Margin = new Thickness(0, 10, 0, 0), Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                stackPanel.Children.Add(textblock);
                stackPanel.Children.Add(textBox);
                RegisterName("Frequency", textBox);
                RangeSliderStackPanel.Children.Add(stackPanel);
            }
        }

        private void Decode_Process()
        {
            string[] parameters = Parameters.Split(new char[] { '~', '=' });
            RangeSliderStackPanel.Children.Add(new TextBlock() { Style = (Style)FindResource("Desc"), Text = hashtable[950].ToString() + ": " + Time + "s", Margin = new Thickness(0, 10, 0, 0) });

            if (Controllers.SQL.Query.ExecuteCheckQuery("select process.process_name, process.sub_process_name, sub_process.equipment_name from process right join sub_process on process.sub_process_name = sub_process.sub_process_name where (sub_process.equipment_name = 'US' and process.process_name ='" + Title + "')", new MySqlCommand()))
            {
                StackPanel stackPanel = new StackPanel();
                stackPanel.Orientation = Orientation.Horizontal;

                TextBlock textblock = new TextBlock() { Style = (Style)FindResource("Label"), Text = hashtable[135].ToString() + " (%)", Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                TextBox textBox = new TextBox() { Name = "Power", Style = (Style)FindResource("TextBox"), Text = parameters[1], Margin = new Thickness(0, 10, 0, 0), Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                stackPanel.Children.Add(textblock);
                stackPanel.Children.Add(textBox);
                RegisterName("Power", textBox);
                RangeSliderStackPanel.Children.Add(stackPanel);

                stackPanel = new StackPanel();

                textblock = new TextBlock() { Style = (Style)FindResource("Label"), Text = hashtable[136].ToString() + " (kHz)", Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                textBox = new TextBox() { Name = "Frequency", Style = (Style)FindResource("TextBox"), Text = parameters[3], Margin = new Thickness(0, 10, 0, 0), Width = 100, HorizontalAlignment = HorizontalAlignment.Left };
                stackPanel.Children.Add(textblock);
                stackPanel.Children.Add(textBox);
                RegisterName("Frequency", textBox);
                RangeSliderStackPanel.Children.Add(stackPanel);
            }
        }

        private void Render_aVX()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            
            TextBox textBox = new TextBox() { Name = "Start_Time", Style = (Style)FindResource("TextBox"), Tag = "Start Time", Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Start_Time", textBox);
            textBox = new TextBox() { Name = "Vacuum_Hold_Time", Style = (Style)FindResource("TextBox"), Tag = "Vacuum Hold Time", Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Hold_Time", textBox);
            textBox = new TextBox() { Name = "Vacuum_Release_Time", Style = (Style)FindResource("TextBox"), Tag = "Vacuum Release Time", Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Release_Time", textBox);
            RangeSliderStackPanel.Children.Add(stackPanel);

            stackPanel = new StackPanel();

            textBox = new TextBox() { Name = "Vacuum_Repeat", Style = (Style)FindResource("TextBox"), Tag = "aVX Pulses", Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Repeat", textBox);
            textBox = new TextBox() { Name = "Vacuum_Level", Style = (Style)FindResource("TextBox"), Tag = "Vacuum Level", Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Level", textBox);
            RangeSliderStackPanel.Children.Add(stackPanel);
        }

        private void Decode_aVX()
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Orientation = Orientation.Horizontal;
            string[] ParseTime = Time.Split(':', '~');

            TextBox textBox = new TextBox() { Name = "Start_Time", Style = (Style)FindResource("TextBox"), Tag = "Start Time", Text = ParseTime[0], Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Start_Time", textBox);
            textBox = new TextBox() { Name = "Vacuum_Hold_Time", Style = (Style)FindResource("TextBox"), Tag = "Vacuum Hold Time", Text = ParseTime[1], Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Hold_Time", textBox);
            textBox = new TextBox() { Name = "Vacuum_Release_Time", Style = (Style)FindResource("TextBox"), Tag = "Vacuum Release Time", Text = ParseTime[2], Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Release_Time", textBox);
            RangeSliderStackPanel.Children.Add(stackPanel);

            stackPanel = new StackPanel();

            textBox = new TextBox() { Name = "Vacuum_Repeat", Style = (Style)FindResource("TextBox"), Tag = "aVX Pulses", Text = ParseTime[3], Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Repeat", textBox);
            textBox = new TextBox() { Name = "Vacuum_Level", Style = (Style)FindResource("TextBox"), Tag = "Vacuum Level", Text = ParseTime[4], Margin = new Thickness(0, 10, 0, 10), HorizontalAlignment = HorizontalAlignment.Left };
            stackPanel.Children.Add(textBox);
            RegisterName("Vacuum_Level", textBox);
            RangeSliderStackPanel.Children.Add(stackPanel);
        }

        private static void OnSetTitleChanged(DependencyObject d,
           DependencyPropertyChangedEventArgs e)
        {
            StandardTable standardTable = d as StandardTable;
            standardTable.OnSetTitleChanged(e);
        }

        private void OnSetTitleChanged(DependencyPropertyChangedEventArgs e)
        {
            title.Text = e.NewValue.ToString();
            switch (Category)
            {
                case Categories.Process:
                    Render_SubProcess(e.NewValue.ToString());
                    break;
                case Categories.LoadProcess:
                    Decode_SubProcess(e.NewValue.ToString());
                    break;
                case Categories.Recipe:
                    Render_Process();
                    break;
                case Categories.LoadRecipe:
                    Decode_Process();
                    break;
                case Categories.aVX:
                    Render_aVX();
                    break;
                case Categories.LoadaVX:
                    Decode_aVX();
                    break;
            }
        }

        public void Encode(Categories Category)
        {
            switch (Category)
            {
                case Categories.Process:
                case Categories.LoadProcess:
                    Encode_Process();
                    break;
                case Categories.Recipe:
                case Categories.LoadRecipe:
                    Encode_Recipe();
                    break;
                case Categories.aVX:
                case Categories.LoadaVX:
                    //Controllers.RecipeManagement.SubProcessBlock.aVX.Encode_aVX( ProcessName,
                    //                Convert.ToInt32(((TextBox)FindName("Start_Time")).Text),
                    //                Convert.ToInt32(((TextBox)FindName("Vacuum_Hold_Time")).Text),
                    //                //Convert.ToInt32(((TextBox)FindName("Vacuum_Release_Time")).Text),
                    //                Convert.ToInt32(((TextBox)FindName("Vacuum_Repeat")).Text),
                    //                Convert.ToInt32(((TextBox)FindName("Vacuum_Level")).Text));
                    break;
            }
        }

        private void Encode_Process()
        {
            string Conditions = "";

            for (int i = 0; i < RangeSliderStackPanel.Children.Count; i++)
            {
                RangeSlider rangeSlider = ((RangeSlider)RangeSliderStackPanel.Children[0]);
                Conditions += rangeSlider.Start + ":" + rangeSlider.End.ToString() + (i == RangeSliderStackPanel.Children.Count - 1 ? "" : "~");
            }

            Controllers.RecipeManagement.API.Process.Create_SQLProcess(Title, Conditions);
        }

        //private void Encode_Process()
        //{
        //    string Conditions = "";

        //    for(int i = 0; i< Count /*RangeSliderStackPanel.Children.Count*/;i++)
        //    {
        //        RangeSlider rangeSlider = ((RangeSlider)RangeSliderStackPanel.Children[0]);
        //        Conditions += rangeSlider.Start + ":" + rangeSlider.End.ToString() + (i == Count /*RangeSliderStackPanel.Children.Count*/ - 1 ? "" : "~");
        //    }

        //    Controllers.RecipeManagement.API.Process.Create_SQLProcess(ProcessName, Title, Conditions);
        //}

        private void Encode_Recipe()
        {
            //if (FindName("Power") != null && FindName("Frequency") != null)
            //    Controllers.RecipeManagement.API.Recipe.Create_SQLRecipe(ProcessName, Title, TotalProcessTime.ToString(), ((TextBox)FindName("Power")).Text, ((TextBox)FindName("Frequency")).Text);
            //else
            //    Controllers.RecipeManagement.API.Recipe.Create_SQLRecipe(ProcessName, Title, TotalProcessTime.ToString(), "10", "40");
        }

        private void Protect_DeleteButton_PreviewMouseUp(object sender, MouseButtonEventArgs e)
        {
            (this.Parent as StackPanel).Children.Remove(this);
        }

        public enum Categories
        {
            Process,
            LoadProcess,
            Recipe,
            LoadRecipe,
            aVX,
            LoadaVX
        }

        private void LoadLanguage()
        {
            try
            {
                hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("135,136,950");
            }
            catch (NullReferenceException) { }
        }

        private void RangeSlider_ValueChanged(object sender, object e)
        {
            if(CBAlign.IsChecked == true)
            {
                RangeSlider rangeSlider = sender as RangeSlider;

                UpdateAllSlider(RangeSliderStackPanel.Children.IndexOf(rangeSlider));
                
            }
        }

        private void UpdateAllSlider(int index)
        {
            RangeSlider firstRangeSlider = (RangeSlider)RangeSliderStackPanel.Children[index];
            double start = firstRangeSlider.Start;
            double stop = firstRangeSlider.End;

            foreach (UIElement uiElement in RangeSliderStackPanel.Children)
            {
                RangeSlider rangeSlider = (RangeSlider)uiElement;
                rangeSlider.Start = start;
                rangeSlider.End = stop;
            }
        }
    }
}
