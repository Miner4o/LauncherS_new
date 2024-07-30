using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System.Collections.ObjectModel;

namespace Cracked_Launcher.Library
{
    public class NavLink
    {
        public string Label { get; set; }
        public Symbol Symbol { get; set; }
    }

    public class GameItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public double Rating { get; set; }
    }

    public sealed partial class LibraryPage : Page
    {
        public ObservableCollection<NavLink> NavLinks { get; set; }
        public ObservableCollection<GameItem> Games { get; set; }

        public LibraryPage()
        {
            this.InitializeComponent();
            NavLinks = new ObservableCollection<NavLink>
            {
                new NavLink { Label = "Library", Symbol = Symbol.Library },
                new NavLink { Label = "Settings", Symbol = Symbol.Setting }
            };
            Games = new ObservableCollection<GameItem>
            {
                new GameItem { Title = "Minecraft", Description = "A game about placing blocks and going on adventures.", Image = "ms-appx:///Assets/minecraft.jpg", Rating = 4.8 },
                new GameItem { Title = "Roblox", Description = "A global platform that brings people together through play.", Image = "ms-appx:///Assets/roblox.jpg", Rating = 4.5 }
            };
            this.DataContext = this;
        }

        private void NavLinksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Handle navigation item clicks
        }

        private void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Handle adding a new game
        }
    }
}
