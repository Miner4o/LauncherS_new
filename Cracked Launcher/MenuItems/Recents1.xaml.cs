using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.ObjectModel;

namespace Cracked_Launcher
{
    public class GameItem
    {
        public string Title { get; set; }
        public string Image { get; set; }
        public double Rating { get; set; }
        public string Status { get; set; }
    }

    public sealed partial class Recents1 : Page
    {
        public ObservableCollection<GameItem> Games { get; set; }

        public Recents1()
        {
            this.InitializeComponent();
            Games = new ObservableCollection<GameItem>
            {
                new GameItem { Title = "Minecraft: Java & Bedrock Edition for PC", Image = "ms-appx:///Assets/minecraft.jpg", Rating = 4.6, Status = "Owned" },
                new GameItem { Title = "Roblox", Image = "ms-appx:///Assets/roblox.jpg", Rating = 4.2, Status = "Free" },
                new GameItem { Title = "Candy Crush Saga", Image = "ms-appx:///Assets/candy_crush.jpg", Rating = 4.7, Status = "Owned" },
                new GameItem { Title = "Naval Armada: Naval battles on ships", Image = "ms-appx:///Assets/naval_armada.jpg", Rating = 4.3, Status = "Free" },
                new GameItem { Title = "March of Empires: War of Lords", Image = "ms-appx:///Assets/march_of_empires.jpg", Rating = 4.5, Status = "Free" },
                new GameItem { Title = "Asphalt Legends Unite", Image = "ms-appx:///Assets/asphalt_legends.jpg", Rating = 4.7, Status = "Owned" }
            };
            this.DataContext = this;
        }

        private void GamesList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedGame = (GameItem)e.ClickedItem;
            Frame.Navigate(typeof(GameDetailPage), clickedGame);
        }
    }
}