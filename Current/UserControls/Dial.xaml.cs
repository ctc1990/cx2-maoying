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
using System.Windows.Media.Animation;
using System.ComponentModel;


namespace CLEANXCEL2._2.UserControls
{
    /// <summary>
    /// Interaction logic for Dial.xaml
    /// </summary>
    public sealed partial class Dial : UserControl, INotifyPropertyChanged
    {
        public Dial()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        public event EventHandler AmountChanged;

        private void GridManipulator(object sender, ManipulationDeltaEventArgs e)
        {
            this.Angle = GetAngle(e.ManipulationOrigin, this.RenderSize);
            this.Amount = (int)(this.Angle / 360 * this.MaxValue) + this.MinValue;
            if (this.AmountChanged != null)
            {
                this.AmountChanged(this, e);
            }
        }

        public void ChangeAmount(int value)
        {
            Amount = value;
            Angle = ((double)(Amount - MinValue) / MaxValue) * 360;
        }

        int m_Amount = default(int);
        public int Amount
        {
            get
            {
                return m_Amount;
            }

            set
            {
                SetProperty(ref m_Amount, value);
            }
        }

        double m_Angle = default(double);
        public double Angle
        {
            get
            {
                return m_Angle;
            }

            set
            {
                SetProperty(ref m_Angle, value);
            }
        }

        public string Unit
        {
            get { return (string)this.GetValue(UnitProperty); }
            set { this.SetValue(UnitProperty, value); }
        }
        public static readonly DependencyProperty UnitProperty = DependencyProperty.Register(
          "Unit", typeof(string), typeof(Dial), new PropertyMetadata("%"));


        public string Title
        {
            get { return (string)this.GetValue(TitleProperty); }
            set { this.SetValue(TitleProperty, value); }
        }
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
          "Title", typeof(string), typeof(Dial), new PropertyMetadata("title"));

        public int MinValue
        {
            get { return (int)this.GetValue(MinValueProperty); }
            set { this.SetValue(MinValueProperty, value); }
        }
        public static readonly DependencyProperty MinValueProperty = DependencyProperty.Register(
          "MinValue", typeof(int), typeof(Dial), new PropertyMetadata(0));

        public int MaxValue
        {
            get { return (int)this.GetValue(MaxValueProperty); }
            set { this.SetValue(MaxValueProperty, value + 1); }
        }
        public static readonly DependencyProperty MaxValueProperty = DependencyProperty.Register(
          "MaxValue", typeof(int), typeof(Dial), new PropertyMetadata(101));

        public event PropertyChangedEventHandler PropertyChanged;
        void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public enum Quadrants : int { nw = 2, ne = 1, sw = 4, se = 3 }
        private double GetAngle(Point touchPoint, Size CircleSize)
        {
            var _X = touchPoint.X - (CircleSize.Width / 2d);
            var _Y = CircleSize.Height - touchPoint.Y - (CircleSize.Height / 2d);
            var _Hypot = Math.Sqrt(_X * _X + _Y * _Y);
            var _Value = Math.Asin(_Y / _Hypot) * 180 / Math.PI;
            var _Quadrant = (_X >= 0) ?
                (_Y >= 0) ? Quadrants.ne : Quadrants.se :
                (_Y >= 0) ? Quadrants.nw : Quadrants.sw;
            switch (_Quadrant)
            {
                case Quadrants.ne: _Value = 090 - _Value; break;
                case Quadrants.nw: _Value = 270 + _Value; break;
                case Quadrants.se: _Value = 090 - _Value; break;
                case Quadrants.sw: _Value = 270 + _Value; break;
            }

            return _Value;
        }

        private void Grid_ManipulationStarted(object sender, ManipulationStartedEventArgs e)
        {
            Storyboard SB = (Storyboard)FindResource("StartDialAnimation");
            SB.Begin();
        }

        private void Grid_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
        {
            Storyboard SB = (Storyboard)FindResource("StartDialAnimation");
            SB.Stop();
        }
    }
}
