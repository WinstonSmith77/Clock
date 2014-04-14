using System.Windows;
using System.Windows.Controls.Primitives;

namespace Clock
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }


        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo)
        {
            if(sizeInfo.NewSize.Width > 0)
            {
                base.OnRenderSizeChanged(sizeInfo);
            }
        }

        private double _startLeft;
        private double _startTop;
 
        

        private void Thumb_DragStarted(object sender, DragStartedEventArgs e)
        {
            _startLeft = Left;
            _startTop = Top;
        }

        private void Thumb_DragDelta(object sender, DragDeltaEventArgs e)
        {
            Left = _startLeft +(e.HorizontalChange);
            Top = _startTop +(e.VerticalChange);

            _startLeft = Left;
            _startTop = Top;
        }
    }
}
