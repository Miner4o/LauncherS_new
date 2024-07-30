using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Animation;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

namespace Cracked_Launcher
{
    public class NewsItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; } // Add an image property
    }

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage1 : Page
    {
        // Declare the ObservableCollection for NewsItems
        public ObservableCollection<NewsItem> NewsItems { get; set; }

        public HomePage1()
        {
            this.InitializeComponent();

            // Initialize the collection of news items
            NewsItems = new ObservableCollection<NewsItem>
            {
                new NewsItem { Title = "Minecraft for Windows 10", Description = "Play the free trial today", Date = DateTime.Now, Image = "ms-appx:///Assets/minecraft.jpg" },
                new NewsItem { Title = "Mystery of the Opera", Description = "Das Geheimnis des Phantom", Date = DateTime.Now.AddDays(-1), Image = "ms-appx:///Assets/opera.jpg" },
                new NewsItem { Title = "Game of Emperors", Description = "", Date = DateTime.Now.AddDays(-2), Image = "ms-appx:///Assets/emperors.jpg" },
                new NewsItem { Title = "Amazon Music", Description = "", Date = DateTime.Now.AddDays(-3), Image = "ms-appx:///Assets/music.jpg" },
                new NewsItem { Title = "iTunes", Description = "", Date = DateTime.Now.AddDays(-4), Image = "ms-appx:///Assets/itunes.jpg" },
                new NewsItem { Title = "Cooking Fever", Description = "", Date = DateTime.Now.AddDays(-5), Image = "ms-appx:///Assets/cooking.jpg" }
            };

            // Set the DataContext for data binding
            this.DataContext = this;
        }
        private void NewsItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            var border = (Border)sender;
            var connectedAnimationService = ConnectedAnimationService.GetForCurrentView();
            connectedAnimationService.PrepareToAnimate("Image", border);
            Frame.Navigate(typeof(DetailPage), border.DataContext);
        }
    }
}
