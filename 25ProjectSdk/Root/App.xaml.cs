using System.Windows;

namespace Root
{
    public partial class App : Application
    {
        public static string EventName = default;

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (e.Args.Length == 1)
            {
                EventName = e.Args[0];
            }
        }
    }
}
