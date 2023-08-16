using System;
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
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Threading;
using System.Collections;

namespace CLEANXCEL2._2.Pages.Menu.Analytics
{
    /// <summary>
    /// Interaction logic for Performance.xaml
    /// </summary>
    public partial class Graph : Page
    {
        Hashtable hashTableTypeList = new Hashtable();

        public Graph()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
            LoadSelection();
        }

        private static List<TimeStamp> Cumulative(int index, List<List<string>> parameters, List<string> duration)
        {
            int value = 0;
            string equipment_name = parameters[0][index];
            List<TimeStamp> list = new List<TimeStamp>();

            for (int i = 0; i < parameters.Count(); i++)
            {
                string parameter = parameters[i][index + 1];

                if (parameter.ToLower().Contains("true") || parameter.ToLower().Contains("false"))
                    list.Add(new TimeStamp() { line = equipment_name, time = value, status = Convert.ToBoolean(parameters[i][index + 1]) });
                else if (parameter.ToLower().Contains("null"))
                    list.Add(new TimeStamp() { line = equipment_name, time = value, status = null });
                else
                    list.Add(new TimeStamp() { line = equipment_name, time = value, value = Convert.ToDouble(parameters[i][index + 1]) });

                value += Convert.ToInt32(duration[i]);
            }

            return list;
        }

        private Chart PlotValueTimeline(Chart chart, List<TimeStamp> list, bool status)
        {
            LineSeries lineSeries = new LineSeries();

            if (list[0].line.Contains("Set"))
                lineSeries.Title = "Set";
            else
                lineSeries.Title = "Actual";
            lineSeries.IndependentValuePath = "time";
            lineSeries.DependentValuePath = "value";
            lineSeries.ItemsSource = list;

            switch (status)
            {
                case true:
                    lineSeries.DataPointStyle = (Style)FindResource("GreenBlueLineDataPointStyle");
                    break;
                case false:
                    lineSeries.DataPointStyle = (Style)FindResource("RedPinkLineDataPointStyle");
                    break;
            }

            chart.Series.Add(lineSeries);
            
            return chart;
        }

        private void LoadSelection()
        {
            try
            {
                // Load Recipe Selection
                List<List<string>> list = Controllers.SQL.Query.ExecuteMultiQuery("select * from history_recipe left join recipe_id on recipe_id.id = history_recipe.recipe_name order by history_recipe.id desc", new string[] { "id", "name" });

                for (int i = 0; i < list[0].Count(); i++)
                    RecipeSelection.Items.Add(new ComboBoxItem() { Content = list[1][i], Tag = list[0][i] });

                RecipeSelection.SelectedIndex = 0;


                list = Decode_Recipe(Convert.ToInt32(list[0][0]));
                List<List<string>> parameters = Decode_Parameters(list);

                //foreach (string value in (parameters[0].Where(x => x.Contains("Set"))).Select(x => x.Substring(0, x.IndexOf(' ', x.IndexOf("Set") - 10) - 1)))
                foreach (string value in parameters[0].Where(x => x.Contains("Set")).Select(x => x.Replace(" Set", "")))
                    GraphSelection.Items.Add(hashTableTypeList[value].ToString());

                GraphSelection.SelectedIndex = 0;
                //foreach (string value in (parameters[0].Where(x => x.Contains("Set"))).Select(x => x.Replace("Set", "")))
                //    GraphSelection.Items.Add(value);
            }
            catch (ArgumentOutOfRangeException) { }
        }

        private List<List<string>> Decode_Recipe(int id)
        {
            List<List<string>> list = new List<List<string>>();

            list = Controllers.RecipeManagement.API.Recipe_History.GET_History_Status_By_ID(id);

            return list;
        }

        private static List<List<string>> Decode_Parameters(List<List<string>> list)
        {
            List<List<string>> parameters = new List<List<string>>();

            parameters = list[3].Select(x => x.Split('~', ':').ToList()).ToList();

            return parameters;
        }

        private Chart Render(int recipe_ID, string graph, Chart chart)
        {
            List<List<string>> list = Decode_Recipe(recipe_ID);
            List<List<string>> parameters = Decode_Parameters(list);

            int equipment_count = parameters[0].Count() / 2;
            int a = 33;

            chart.Series.Clear();

            string selected = GraphSelection.SelectedItem.ToString();
            string key = hashTableTypeList.Keys.OfType<string>().First(x => hashTableTypeList[x].ToString() == selected);
            int index = parameters[0].FindIndex(x => x.Contains(key));

            chart = PlotValueTimeline(chart, Cumulative(index, parameters, list[4]), true);
            index += 2;
            chart = PlotValueTimeline(chart, Cumulative(index, parameters, list[4]), false);
            
            YAxisLabel.Text = DefineAxis(hashTableTypeList, key);
            return chart;
        }

        private static string DefineAxis(Hashtable hashtable, string key)
        {
            switch (key)
            {
                case "187":
                case "188":
                case "189":
                case "190":
                case "191":
                case "192":
                    return hashtable["112"].ToString() + " (°C)";
                case "193":
                    return hashtable["113"].ToString() + " (kPa)";
                case "194":
                    return hashtable["135"].ToString() + " (%)";
                case "195":
                    return hashtable["136"].ToString() + " (kHz)";
                default:
                    return "";
        }
        }
        /*

        private Chart PlotValueTimeline(Chart chart, List<TimeStamp> list, bool status)
        {
            LineSeries lineSeries = new LineSeries();

            lineSeries.Title = list[0].line;
            lineSeries.IndependentValuePath = "time";
            lineSeries.DependentValuePath = "value";
            lineSeries.ItemsSource = list;

            switch(status)
            {
                case true:
                    lineSeries.DataPointStyle = (Style)FindResource("GreenBlueLineDataPointStyle");
                    break;
                case false:
                    lineSeries.DataPointStyle = (Style)FindResource("RedPinkLineDataPointStyle");
                    break;
            }

            chart.Series.Add(lineSeries);
            
            return chart;
        }

        private void LoadSelection()
        {
            // Load Recipe Selection
            List<List<string>> list = Controllers.SQL.Query.ExecuteMultiQuery("select * from history_recipe", new string[] { "id", "recipe_name" });
            
            for (int i = 0; i < list[0].Count(); i++)
                RecipeSelection.Items.Add(new ComboBoxItem() { Content = list[1][i], Tag = list[0][i] });

            RecipeSelection.SelectedIndex = 0;


            list = Decode_Recipe(1);
            List<List<string>> parameters = Decode_Parameters(list);
            foreach (string value in (parameters[0].Where(x => x.Contains("Set"))).Select(x => x.Replace("Set", "")))
                GraphSelection.Items.Add(value);
        }

        private List<List<string>> Decode_Recipe(int id)
        {
            List<List<string>> list = new List<List<string>>();

            list = Controllers.RecipeManagement.RecipeStructure.API.Recipe_History.GET_History_Status_By_ID(id);

            return list;
        }

        private static List<List<string>> Decode_Parameters(List<List<string>> list)
        {
            List<List<string>> parameters = new List<List<string>>();

            parameters = list[3].Select(x => x.Split('~', ':').ToList()).ToList();

            return parameters;
        }

        private Chart Render(int recipe_ID, int graph_ID, Chart chart)
        {
            List<List<string>> list = Decode_Recipe(recipe_ID);
            List<List<string>> parameters = Decode_Parameters(list);

            int equipment_count = parameters[0].Count() / 2;
            int a = 33;

            chart.Series.Clear();

            switch (graph_ID)
            {
                case 0:
                    for (int i = 0; i < a; i++)
                    {
                        chart = PlotLogicTimeline(chart, Standard(i, parameters, list[4]));
                    }
                    //chart.LegendStyle = (Style)FindResource("HiddenLegend");
                    break;
                default:
                    string[] substring = GraphSelection.SelectedItem.ToString().Split(' ');

                    int index = parameters[0].FindIndex(x => x.Contains(GraphSelection.SelectedItem.ToString()));

                    chart = PlotValueTimeline(chart, Cumulative(index += 2, parameters, list[4]), false);
                    chart = PlotValueTimeline(chart, Cumulative(index, parameters, list[4]), true);

                    //chart.LegendStyle = (Style)FindResource("VisibleLegend");
                    break;
            }

            return chart;
        }*/

        private void Analyse_Click(object sender, RoutedEventArgs e)
        {
            Controllers.EventNotifier.Loading_Display.Run(Controllers.EventNotifier.Loading_Display.LoadingActions.Analysing);

            Dispatcher.Invoke((Action)(() => 
            {
                Render(Convert.ToInt32(((ComboBoxItem)RecipeSelection.SelectedValue).Tag), GraphSelection.SelectedItem.ToString(), TimelineChart);
            }), DispatcherPriority.Render);

            Controllers.EventNotifier.Loading_Display.Stop(Controllers.EventNotifier.Loading_Display.LoadingActions.Analysing);
        }

        private class TimeStamp
        {
            public string line { get; set; }
            public int time { get; set; }
            public bool? status { get; set; }
            public double value { get; set; }
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("107,112,113,135,136,176,177,178,179,187,188,189,190,191,192,193,194,195");

                bAnalyse.Content = hashtable[176].ToString();
                YAxisLabel.Text = hashtable[179].ToString();
                XAxisLabel.Text = hashtable[107].ToString() + " (s)";
                TBSetTitle.Text = hashtable[177].ToString();
                TBActualTitle.Text = hashtable[178].ToString();

                hashTableTypeList.Add("187", hashtable[187].ToString());
                hashTableTypeList.Add("188", hashtable[188].ToString());
                hashTableTypeList.Add("189", hashtable[189].ToString());
                hashTableTypeList.Add("190", hashtable[190].ToString());
                hashTableTypeList.Add("191", hashtable[191].ToString());
                hashTableTypeList.Add("192", hashtable[192].ToString());
                hashTableTypeList.Add("193", hashtable[193].ToString());
                hashTableTypeList.Add("194", hashtable[194].ToString());
                hashTableTypeList.Add("195", hashtable[195].ToString());

                hashTableTypeList.Add("112", hashtable[112].ToString());
                hashTableTypeList.Add("113", hashtable[113].ToString());
                hashTableTypeList.Add("135", hashtable[135].ToString());
                hashTableTypeList.Add("136", hashtable[136].ToString());
            }
            catch (NullReferenceException) { }
        }
    }
}
