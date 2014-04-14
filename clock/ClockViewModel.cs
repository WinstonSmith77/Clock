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

            Action doIt =
            () =>
            {
                var now = DateTime.Now.AddHours(Offset);

                Seconds = now.Second;

                Minutes = now.Minute + Seconds / 60;

                Hours = now.Hour + Minutes / 60;


            };


            this.DispatchAction(doIt);
        }





        public double Offset
        {
            get { return (double)GetValue(OffsetProperty); }
            set { SetValue(OffsetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Offset.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OffsetProperty =
            DependencyProperty.Register("Offset", typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));





        public double Minutes
        {
            get { return (double)GetValue(MinutesProperty); }
            set { SetValue(MinutesProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Minutes.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MinutesProperty =
            DependencyProperty.Register("Minutes", typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));




        public double Hours
        {
            get { return (double)GetValue(HoursProperty); }
            set { SetValue(HoursProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Hours.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HoursProperty =
            DependencyProperty.Register("Hours", typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));



        public double Seconds
        {
            get { return (double)GetValue(SecondsProperty); }
            set { SetValue(SecondsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Seconds.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SecondsProperty =
            DependencyProperty.Register("Seconds", typeof(double), typeof(ClockViewModel), new UIPropertyMetadata(0d));





    }
}
