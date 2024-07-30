using Cracked_Launcher.Library;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

namespace Cracked_Launcher
{
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Set custom title bar
            ExtendsContentIntoTitleBar = true;
            SetTitleBar(AppTitleBar);

            // Handle navigation item click
            nvSample.ItemInvoked += NvSample_ItemInvoked;
            contentFrame.Navigate(typeof(HomePage1));
            nvSample.SelectedItem = nvSample.MenuItems[0];
        }

        private void NvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer != null)
            {
                var tag = args.InvokedItemContainer.Tag.ToString();

                if (tag == "HomePage1")
                {
                    contentFrame.Navigate(typeof(HomePage1));
                }
                else if (tag == "Recents1")
                {
                    contentFrame.Navigate(typeof(Recents1));
                }
                else if(tag == "Settings")
                {
                    contentFrame.Navigate(typeof(Settings));
                }
                else if (tag == "Library")
                {
                    contentFrame.Navigate(typeof(LibraryPage));
                }
            }
        }
    }
}
