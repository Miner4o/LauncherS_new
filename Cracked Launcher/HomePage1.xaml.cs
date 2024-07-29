using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
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
                new NewsItem { Title = "News Title 1", Description = "Description for news item 1", Date = DateTime.Now },
                new NewsItem { Title = "News Title 2", Description = "Description for news item 2", Date = DateTime.Now.AddDays(-1) },
                new NewsItem { Title = "News Title 3", Description = "Description for news item 3", Date = DateTime.Now.AddDays(-2) }
            };

            // Set the DataContext for data binding
            this.DataContext = this;
        }
    }
}
