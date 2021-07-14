using System;
using System.Threading;
using System.Windows;

namespace Root
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (App.EventName != default)
            {
                try
                {
                    using (var mainWindowLoadedEvent = EventWaitHandle.OpenExisting(App.EventName))
                    {
                        mainWindowLoadedEvent.Set();
                        Application.Current.Shutdown();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.GetType().Name}: {ex.Message} '{App.EventName}'");
                }
            }
        }
    }
}
