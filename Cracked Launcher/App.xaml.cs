using Microsoft.UI.Xaml;

namespace Cracked_Launcher
{
    public partial class App : Application
    {
        public static Window MainWindow { get; private set; }

        public App()
        {
            this.InitializeComponent();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            if (MainWindow == null)
            {
                // Създаване на основния прозорец и задаване на препратката
                MainWindow = new MainWindow();
                MainWindow.Activate();
            }
        }
    }
}