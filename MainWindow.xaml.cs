using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Interop;

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
            if (sizeInfo.NewSize.Width > 0)
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
            Left = _startLeft + (e.HorizontalChange);
            Top = _startTop + (e.VerticalChange);

            _startLeft = Left;
            _startTop = Top;
        }

        [DllImport("user32")]
        public static extern void LockWorkStation();


        [DllImport("user32.dll")]
        static extern IntPtr SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        private int SC_MONITORPOWER = 0xF170;
        private int WM_SYSCOMMAND = 0x0112;

        public  void TurnOffScreen()
        {
            const int off = 2;
            var handle  = new WindowInteropHelper(this).Handle;
            SendMessage(handle, WM_SYSCOMMAND, SC_MONITORPOWER, 2);
        }


        private void Lock_CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            LockWorkStation();
        }

        private void ScreenOff_CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            TurnOffScreen();
        }
    }
}
