using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Clock.clock
{
    /// <summary>
    /// Interaction logic for AnalogClock.xaml
    /// </summary>
    public partial class AnalogClock : UserControl
    {
        public AnalogClock()
        {
            InitializeComponent();
        }




        public SolidColorBrush Stroke
        {
            get { return ((SolidColorBrush)GetValue(StrokeProperty)); }
            set { SetValue(StrokeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Stroke.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty StrokeProperty =
            DependencyProperty.Register("Stroke", typeof(SolidColorBrush), typeof(AnalogClock), new UIPropertyMetadata(Brushes.Black));

        
    }
}
