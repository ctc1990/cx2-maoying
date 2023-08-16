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
    /// Interaction logic for ConditionPanel.xaml
    /// </summary>
    public partial class ConditionPanel : UserControl
    {
        List<string> startCondList = new List<string>();
        List<string> stopCondList = new List<string>();

        public struct EquipmentConditions
        {
            public string Name;
            public List<string> StartConditions;
            public List<string> StopConditions;
        }

        public ConditionPanel()
        {
            InitializeComponent();
        }

        private void AddStartCondition_onClick(object sender, RoutedEventArgs e)
        {
            ConditionRow conditionRow = new ConditionRow("0");
            StartCondition.Children.Insert(StartCondition.Children.Count - 1, conditionRow);
        }

        private void AddStopCondition_onClick(object sender, RoutedEventArgs e)
        {
            ConditionRow conditionRow = new ConditionRow("1");
            StopCondition.Children.Insert(StopCondition.Children.Count - 1, conditionRow);
        }

        public EquipmentConditions Encode(string EquipmentVariable)
        {
            List<string> startCond = new List<string>();
            List<string> stopCond = new List<string>();
            EquipmentVariable += "=true";

            for (int i = 1; i < StartCondition.Children.Count - 1; i++)
                try { if (((ConditionRow)StartCondition.Children[i]).Encode()!="") startCond.Add(((ConditionRow)StartCondition.Children[i]).Encode()); }
                catch { }

            for (int i = 1; i < StopCondition.Children.Count - 1; i++)
                try { if (((ConditionRow)StopCondition.Children[i]).Encode()!="") stopCond.Add(((ConditionRow)StopCondition.Children[i]).Encode()); }
                catch { }

            return new EquipmentConditions { Name = EquipmentVariable, StartConditions = startCond, StopConditions = stopCond };
        }

        public void Decode(string variable, string condition, string value)
        {
            if (variable.Contains("St"))
                StartCondition_Add(variable, condition, value);
            else
                StopCondition_Add(variable, condition, value);
        }

        private void StartCondition_Add(string variable, string condition, string value)
        {
            ConditionRow conditionRow = new ConditionRow("0");
            conditionRow.Decode(variable, condition, value);
            StartCondition.Children.Insert(StartCondition.Children.Count - 1, conditionRow);
        }

        private void StopCondition_Add(string variable, string condition, string value)
        {
            ConditionRow conditionRow = new ConditionRow("1");
            conditionRow.Decode(variable, condition, value);
            StopCondition.Children.Insert(StopCondition.Children.Count - 1, conditionRow);
        }
    }
}
