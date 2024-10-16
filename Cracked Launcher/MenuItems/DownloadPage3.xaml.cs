using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Windows.Security.Cryptography.Core;
using System.Runtime.InteropServices;
using WinRT.Interop;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace Cracked_Launcher.MenuItems
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class DownloadPage3 : Page
    {
        [DllImport("C:\\Projects\\arduino projects\\arduino my projects\\LauncherS\\Debug\\AppDLL.dll", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
        private static extern IntPtr openFileDiag(IntPtr hwndOwner, string filter, string tittle);

        public DownloadPage3()
        {
            this.InitializeComponent();
        }
        private async void AddTorrent_Click (object sender, RoutedEventArgs e)
        {
            IntPtr hwndOwner = WindowNative.GetWindowHandle(App.MainWindow);
            string filter = "All Files\0*.*\0Executable Files\0*.EXE\0Torrent Files\0*.TORRENT\0";
            string tittle = "Select a torrent:";
            IntPtr resultPtr = openFileDiag(hwndOwner, filter, tittle);
            if (resultPtr != IntPtr.Zero)
            {
                string fileName = Marshal.PtrToStringAnsi(resultPtr);
                await ShowContentDialog($"Selected file: {fileName}");
            }
            else
            {
                await ShowContentDialog("No file selected.");
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
