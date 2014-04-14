using System;
using System.Windows;

namespace Clock
{
    public static class WPF
    {
        public static void DispatchAction(this DependencyObject host, Action toDo)
        {
            if (host.Dispatcher.CheckAccess())
            {
                toDo();
            }
            else
            {
                try
                {
                    //Beim disposen können Asynchronitäten zu Problemen führen
                    host.Dispatcher.Invoke(toDo);
                }
                catch (NullReferenceException)
                {

                }
            }
        }

       
    }
}
