using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;

namespace Cracked_Launcher
{
    public sealed partial class DetailPage : Page
    {
        public NewsItem DetailedObject { get; set; }

        public DetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            DetailedObject = e.Parameter as NewsItem;
            ConnectedAnimationService.GetForCurrentView().GetAnimation("Image")?.TryStart(detailedImage);
            Bindings.Update();
        }

        private void BackButton_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
