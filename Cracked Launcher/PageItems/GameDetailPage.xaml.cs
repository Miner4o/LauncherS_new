using Cracked_Launcher.Library;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;

namespace Cracked_Launcher
{
    public sealed partial class GameDetailPage : Page
    {
        public GameDetailPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var game = e.Parameter as GameItem;
            GameImage.Source = new Microsoft.UI.Xaml.Media.Imaging.BitmapImage(new Uri(game.Image));
            GameTitle.Text = game.Title;
            GameRating.Text = $"Rating: {game.Rating}";
            GameStatus.Text = $"Status: {game.Status}";
        }

        private void GoBack_Click(object sender, Microsoft.UI.Xaml.RoutedEventArgs e)
        {
            Frame.GoBack();
        }
    }
}
