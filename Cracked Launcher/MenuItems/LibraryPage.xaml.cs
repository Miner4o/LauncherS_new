using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using System;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using Windows.UI.Popups;
using WinRT.Interop;

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
        public string Staus { get; set; }
    }

    public sealed partial class LibraryPage : Page
    {
        [DllImport("D:\\Projects\\arduino projects\\arduino my projects\\LauncherS\\Debug\\AppDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern IntPtr openFileDiag(IntPtr hwndOwner, string filter, string tittle);

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

            this.DataContext = this; // Уверете се, че DataContext е зададен
        }

        private void NavLinksList_ItemClick(object sender, ItemClickEventArgs e)
        {
            // Handle navigation item clicks
        }
        
        private async void AddGameButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Проверете дали основният прозорец е зададен
                if (App.MainWindow == null)
                {
                    await ShowContentDialog("Error: Main window is not set.");
                    return;
                }

                // Получаване на хендъла на основния прозорец
                IntPtr hwndOwner = WindowNative.GetWindowHandle(App.MainWindow);

                // Проверка дали хендълът е валиден
                if (hwndOwner == IntPtr.Zero)
                {
                    await ShowContentDialog("Error: Unable to get the window handle.");
                    return;
                }

                // Извикване на OpenFileDialog от DLL
                string filter = "All Files\0*.*\0Executable Files\0*.EXE";
                string tittle = "Select a game:";
                IntPtr resultPtr = openFileDiag(hwndOwner, filter, tittle);

                if (resultPtr != IntPtr.Zero)
                {
                    string fileName = Marshal.PtrToStringAnsi(resultPtr);
                    Games.Add(new GameItem
                    {
                        Title = System.IO.Path.GetFileNameWithoutExtension(fileName),
                        Image = "\"D:\\Need for Speed Most Wanted Black Edition\\NFSMW_icon.ico\""
                    });
                }
                else
                {
                    await ShowContentDialog("No file selected.");
                }
            }
            catch (Exception ex)
            {
                await ShowContentDialog($"Error: {ex.Message}");
            }

        }
        private async System.Threading.Tasks.Task ShowContentDialog(string message)
        {
            ContentDialog dialog = new ContentDialog
            {
                Title = "File Selection",
                Content = message,
                CloseButtonText = "OK",
                XamlRoot = this.XamlRoot
            };

            await dialog.ShowAsync();
        }
    }
}
