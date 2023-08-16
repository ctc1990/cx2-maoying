using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace CLEANXCEL2._2.Pages.Menu.Analytics
{
    /// <summary>
    /// Interaction logic for StatusDiagram.xaml
    /// </summary>
    public partial class StatusDiagram : Page
    {
        public StatusDiagram()
        {
            InitializeComponent();
        }

        private void LoadSelection()
        {
            // Load Recipe Selection
            List<List<string>> list = Controllers.SQL.Query.ExecuteMultiQuery("select * from history_recipe inner join recipe_id on recipe_id.id = history_recipe.recipe_name order by history_recipe.id desc", new string[] { "id", "name" });

            for (int i = 0; i < list[0].Count(); i++)
                RecipeSelection.Items.Add(new ComboBoxItem() { Content = list[1][i], Tag = list[0][i] });

            RecipeSelection.SelectedIndex = 0;
        }

        private static List<TimeStamp> Standard(int index, List<List<string>> parameters, List<string> duration)
        {
            string equipment_name = parameters[0][index * 2];
            List<TimeStamp> list = new List<TimeStamp>();

            for (int i = 0; i < parameters.Count(); i++)
            {
                string parameter = parameters[i][(index * 2) + 1];

                if (parameter.ToLower().Contains("true") || parameter.ToLower().Contains("false"))
                    list.Add(new TimeStamp() { line = equipment_name, time = Convert.ToInt32(duration[i]), status = Convert.ToBoolean(parameters[i][(index * 2) + 1]) });
                else if (parameter.ToLower().Contains("null"))
                    list.Add(new TimeStamp() { line = equipment_name, time = Convert.ToInt32(duration[i]), status = null });
                else
                    list.Add(new TimeStamp() { line = equipment_name, time = Convert.ToInt32(duration[i]), value = Convert.ToDouble(parameters[i][(index * 2) + 1]) });
            }

            return list;
        }

        private Chart PlotLogicTimeline(Chart chart, List<TimeStamp> list)
        {
            StackedBarSeries stackSeries = new StackedBarSeries();

            stackSeries.Template = (ControlTemplate)FindResource("GraphStackedBarSeries");

            for (int i = 0; i < list.Count(); i++)
            {
                SeriesDefinition tempSeries = new SeriesDefinition();
                tempSeries.ItemsSource = new List<TimeStamp>() { list[i] };
                tempSeries.Title = "";
                tempSeries.IndependentValuePath = "line";
                tempSeries.DependentValuePath = "time";
                switch (list[i].status)
                {
                    case true:
                        tempSeries.DataPointStyle = (Style)FindResource("GreenBlueBarDataPointStyle");
                        break;
                    case false:
                        tempSeries.DataPointStyle = (Style)FindResource("TransparentBarDataPointStyle");
                        break;
                    case null:
                        tempSeries.DataPointStyle = (Style)FindResource("RedPinkBarDataPointStyle");
                        break;

                }
                stackSeries.SeriesDefinitions.Add(tempSeries);
            }
            chart.Series.Add(stackSeries);
            return chart;
        }

        private void Render()
        {
            Controllers.EventNotifier.Loading_Display.Run(Controllers.EventNotifier.Loading_Display.LoadingActions.Analysing);

            int recipe_ID = Convert.ToInt32(((ComboBoxItem)RecipeSelection.SelectedValue).Tag);
            Chart chart = TimelineChart;

            List<List<string>> list = Decode_Recipe(recipe_ID);
            List<List<string>> parameters = Decode_Parameters(list);

            int equipment_count = parameters[0].Count() / 2;
            int a = 33;

            chart.Series.Clear();
            
            for (int i = 0; i < a; i++)
            {
                chart = PlotLogicTimeline(chart, Standard(i, parameters, list[4]));
            }
            TimelineChart = chart;

            Controllers.EventNotifier.Loading_Display.Stop(Controllers.EventNotifier.Loading_Display.LoadingActions.Analysing);
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

        private class TimeStamp
        {
            public string line { get; set; }
            public int time { get; set; }
            public bool? status { get; set; }
            public double value { get; set; }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
            LoadSelection();
            RecipeSelection.SelectedIndex = 0;
        }

        private void Analyse_Click(object sender, RoutedEventArgs e)
        {
            Controllers.EventNotifier.Loading_Display.Run(Controllers.EventNotifier.Loading_Display.LoadingActions.Analysing);


            Dispatcher.Invoke((Action)(() =>
            {
                Render();
            }), DispatcherPriority.Render);

            Controllers.EventNotifier.Loading_Display.Stop(Controllers.EventNotifier.Loading_Display.LoadingActions.Analysing);
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("107,176,177,178,180");

                bAnalyse.Content = hashtable[176].ToString();
                YAxisLabel.Text = hashtable[180].ToString();
                XAxisLabel.Text = hashtable[107].ToString() + " (s)";
                TBSetTitle.Text = hashtable[177].ToString();
                TBActualTitle.Text = hashtable[178].ToString();
            }
            catch (NullReferenceException) { }
        }
    }
}
