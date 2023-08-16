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
    /// Interaction logic for RangeSlider.xaml
    /// </summary>
    public partial class RangeSlider : UserControl, INotifyPropertyChanged
    {
        public event EventHandler ValueChanged;
        double d_LowerSliderValue = 0, d_UpperSliderValue = 100;
        bool mousePosXflag = false;
        int LowOffset = 0, UppOffset = 0;
        double sliderHeight = 0;

        public string Slider_Label
        {
            set { EquipmentLabel.Text = value; }
            get { return EquipmentLabel.Text; }
        }

        double m_Start = 0;
        public double Start
        {
            get
            {
                End = m_Start + m_Duration;
                //Duration = m_End - m_Start;
                return m_Start;
            }

            set
            {
                try { SetProperty(ref m_Start, value); }
                catch { m_Start = value; m_Duration = UpperSlider.Value - value; LowerSlider.Value = value; }
            }
        }

        double m_End = 500;
        public double End
        {
            get
            {
                //Start = m_End - m_Duration;
                Duration = m_End - m_Start;
                return m_End;
            }

            set
            {
                try { SetProperty(ref m_End, value); }
                catch { m_Duration = value - LowerSlider.Value; UpperSlider.Value = value; }
                
            }
        }
        double m_Duration = 500;
        public double Duration
        {
            get
            {
                End = m_Start + m_Duration;
                return m_Duration;
            }

            set
            {
                SetProperty(ref m_Duration, value);
            }
        }

        public double Slider_Width
        {
            set
            {
                UserControlRangeSlider.Width = value;
            }
        }

        public double Slider_Height
        {
            set
            {
                LowerSlider.Tag = value - Math.Ceiling(value / 5);
                UpperSlider.Tag = value - Math.Ceiling(value / 5);
                LowerSlider.Height = value;
                UpperSlider.Height = value;
                borderRepeatButtonBackground.CornerRadius = new CornerRadius(value / 2);
                borderRepeatButtonFill.CornerRadius = new CornerRadius(value / 2);
                borderRepeatButtonBackground.Height = value;
                borderRepeatButtonFill.Height = value;
                sliderHeight = value;
            }
        }

        public double Minimum
        {
            set
            {
                LowerSlider.Minimum = value;
                UpperSlider.Minimum = value;
            }
        }

        public double Maximum
        {
            set
            {
                LowerSlider.Maximum = value;
                UpperSlider.Maximum = value;
            }
        }

        public RangeSlider()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            Fill_RepeatButton();
        }

        private void LowerSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (LowerSlider.Value <= UpperSlider.Value)
            {
                d_LowerSliderValue = LowerSlider.Value;
                Fill_RepeatButton();
            }
            else
                LowerSlider.Value = d_LowerSliderValue;
        }

        private void UpperSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (UpperSlider.Value >= LowerSlider.Value)
            {
                d_UpperSliderValue = UpperSlider.Value;
                Fill_RepeatButton();
            }
            else
                UpperSlider.Value = d_UpperSliderValue;
        }

        private void Fill_RepeatButton()
        {
            int i_Lapsed = Convert.ToInt32(UpperSlider.Value - LowerSlider.Value + 100);
            double i_Lower = (LowerSlider.Value / LowerSlider.Maximum) * (LowerSlider.ActualWidth * (0.9982142857 - (0.0009642857 * sliderHeight)));
            double i_Upper = (UpperSlider.Value / UpperSlider.Maximum) * (UpperSlider.ActualWidth) +
                             ((UpperSlider.Maximum - UpperSlider.Value) / UpperSlider.Maximum) * (UpperSlider.ActualWidth * 0.001105 * sliderHeight);

            borderRepeatButtonFill.Width = i_Upper - i_Lower;

            Thickness margin = borderRepeatButtonFill.Margin;

            margin.Left = i_Lower;

            borderRepeatButtonFill.Margin = margin;

            if (this.ValueChanged != null)
            {
                ValueChanged(this, null);
            }
        }

        private void LowerSlider_onMouseMove(object sender, MouseEventArgs e)
        {
            LowerSlider.ToolTip = LowerSlider.Value;
        }

        private void UpperSlider_onMouseMove(object sender, MouseEventArgs e)
        {
            UpperSlider.ToolTip = UpperSlider.Value;
        }

        private void borderRepeatButtonFill_onMouseMove(object sender, MouseEventArgs e)
        {
            borderRepeatButtonFill.Height = sliderHeight + 2;
            double i_Lower, i_Upper;
            if (mousePosXflag)
            {
                i_Lower = RefMove(e, LowerSlider) - LowOffset;
                i_Upper = i_Lower + UppOffset;
                if (i_Lower >= LowerSlider.Minimum && i_Upper <= UpperSlider.Maximum)
                {
                    LowerSlider.Value = i_Lower;
                    UpperSlider.Value = i_Upper;
                }
            }
        }

        private int RefMove(MouseEventArgs e, Slider slider)
        {
            double d = 1.0d / slider.ActualWidth * e.GetPosition(this).X;
            return Convert.ToInt32(slider.Maximum * d);
        }

        private void borderRepeatButtonFill_onMouseLeave(object sender, MouseEventArgs e)
        {
            borderRepeatButtonFill.Height = sliderHeight;
        }

        private void borderRepeatButtonFill_onMouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
            {
                LowerSlider.Value += 1;
                UpperSlider.Value += 1;
            }
            else
            {
                LowerSlider.Value -= 1;
                UpperSlider.Value -= 1;
            }
        }

        private void borderRepeatButtonFill_onMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            mousePosXflag = true;

            LowOffset = RefMove(e, LowerSlider) - Convert.ToInt32(LowerSlider.Value);
            UppOffset = Convert.ToInt16(UpperSlider.Value - LowerSlider.Value);
            borderRepeatButtonFill.CaptureMouse();
        }

        private void borderRepeatButtonFill_onGotMouseCapture(object sender, MouseEventArgs e)
        {
            borderRepeatButtonFill_onMouseMove(sender, e);
        }

        private void borderRepeatButtonFill_onMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mousePosXflag)
            {
                mousePosXflag = false;
                borderRepeatButtonFill.Height = sliderHeight;
                borderRepeatButtonFill.ReleaseMouseCapture();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void UserControlRangeSlider_Loaded(object sender, RoutedEventArgs e)
        {
            LoadLanguage();
        }

        void SetProperty<T>(ref T storage, T value, [System.Runtime.CompilerServices.CallerMemberName] string propertyName = null)
        {
            if (!object.Equals(storage, value))
            {
                storage = value;
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private void LoadLanguage()
        {
            try
            {
                Hashtable hashtable = Controllers.SQL.Query.ExecuteLanguageQuery("133,134");

                TBStartTitle.Text = hashtable[133].ToString();
                TBDurationTitle.Text = hashtable[134].ToString();
            }
            catch (NullReferenceException) { }
        }
    }
}
