using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.ObjectModel;

namespace Cracked_Launcher
{
    public class GameItem
    {
        public string Title { get; set; }
        public string Rating { get; set; }
        public string Status { get; set; }
        public string Image { get; set; } // ƒобав€ме Image свойство
    }

    public sealed partial class Recents1 : Page
    {
        public ObservableCollection<GameItem> GameItems { get; set; }

        public Recents1()
        {
            this.InitializeComponent();
            GameItems = new ObservableCollection<GameItem>
            {
                new GameItem { Title = "Minecraft: Java & Bedrock Edition", Rating = "4.6", Status = "Owned", Image = "https://example.com/minecraft.jpg" },
                new GameItem { Title = "Roblox", Rating = "4.2", Status = "Free", Image = "https://example.com/roblox.jpg" },
                new GameItem { Title = "Candy Crush Saga", Rating = "4.7", Status = "Owned", Image = "https://example.com/candycrush.jpg" },
                new GameItem { Title = "Naval Armada: Naval battles on ships", Rating = "4.3", Status = "Free", Image = "https://example.com/navalarmada.jpg" },
                new GameItem { Title = "March of Empires: War of Lords", Rating = "4.5", Status = "Free", Image = "https://example.com/marchofempires.jpg" },
                new GameItem { Title = "Asphalt Legends Unite", Rating = "4.7", Status = "Owned", Image = "https://example.com/asphaltlegends.jpg" }
            };
            this.DataContext = this;
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedItem = e.ClickedItem as GameItem;
            if (clickedItem != null)
            {
                // Ќавигиране до нова страница и предаване на избрани€ елемент
                Frame.Navigate(typeof(GameDetailPage), clickedItem);
            }
        }
    }
}
