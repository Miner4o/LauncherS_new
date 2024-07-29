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
            contentFrame.Navigate(typeof(BlankPage1));
            nvSample.SelectedItem = nvSample.MenuItems[0];
        }

        private void NvSample_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.InvokedItemContainer != null)
            {
                var tag = args.InvokedItemContainer.Tag.ToString();

                if (tag == "HomePage")
                {
                    contentFrame.Navigate(typeof(BlankPage1));
                }
                // Add more conditions here for other pages if needed
            }
        }
    }
}
