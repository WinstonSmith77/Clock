using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using CommonStuff.WPF;

namespace Clock.clock
{
    public class ClockViewModel : DependencyObject
    {
        public ClockViewModel()
        {
            Timer timer = new Timer(50);
            timer.Elapsed += timer_Elapsed;
            timer.Start();

            ResetOffset = new RelayCommand(() => Offset = 0);
        }

        public ICommand ResetOffset { get; private set; }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            void DoIt()
            {
                var now = DateTime.Now.AddHours(Offset);

                Seconds = now.Second;

                Minutes = now.Minute + Seconds / 60;

                Hours = now.Hour + Minutes / 60;
            }

            this.DispatchAction(DoIt);
        }

        public double Offset
        {
            get => (double)GetValue(OffsetProperty);
            set => SetValue(OffsetProperty, value);
        }

        // Using a DependencyProperty as the backing store for Offset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register(nameof(Offset), typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));


        public double Minutes
        {
            get => (double)GetValue(MinutesProperty);
            set => SetValue(MinutesProperty, value);
        }

        // Using a DependencyProperty as the backing store for Minutes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinutesProperty =
            DependencyProperty.Register(nameof(Minutes), typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));


        public double Hours
        {
            get => (double)GetValue(HoursProperty);
            set => SetValue(HoursProperty, value);
        }

        // Using a DependencyProperty as the backing store for Hours.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoursProperty =
            DependencyProperty.Register(nameof(Hours), typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));


        public double Seconds
        {
            get => (double)GetValue(SecondsProperty);
            set => SetValue(SecondsProperty, value);
        }

        // Using a DependencyProperty as the backing store for Seconds.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondsProperty =
            DependencyProperty.Register(nameof(Seconds), typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));
    }
}
