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
    /// Interaction logic for Card.xaml
    /// </summary>
    public partial class Card : UserControl
    {
        public Card()
        {
            InitializeComponent();
        }

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Label.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(Card), new PropertyMetadata(""));

        public string Equipment
        {
            get { return (string)GetValue(EquipmentProperty); }
            set { SetValue(EquipmentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Equipment.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EquipmentProperty =
            DependencyProperty.Register("Equipment", typeof(string), typeof(Card), new PropertyMetadata(""));

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(Card), new PropertyMetadata(""));

        private void LoadDescription()
        {
            //List<List<string>> info = 
            //    Controllers.SQL.Query.ExecuteMultiQuery("select " + MainWindow.language + ".terms,  from io_list where io_list.")
        }
        //This is a door with no safety measures equipped and will shut and
        //clamp your hand if you close it while putting ur hand into the
        //process chamber. :)
    }
}
