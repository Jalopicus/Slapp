using System.Windows;
using System.Windows.Controls;
using Datality.Overlords;
using MahApps.Metro.Controls;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for BrandWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow {
        public MainWindow() {
            InitializeComponent();
        }
        private BrandPage _brandPage = null;
        private MainPage _mainPage = null;
        private Badmin _badmin = null;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            //var content = (Page) RootFrame.Content;
            //((IOverlord) (content)).Dispose();
            _mainPage?.Dispose();
            _brandPage?.Dispose();
            _badmin?.Dispose();
        }
        private void BrandPage_Click(object sender, RoutedEventArgs e) {
            if (_brandPage == null) _brandPage = new BrandPage();
            RootFrame.Navigate(_brandPage);
            _badmin?.Dispose();
        }
        private void Badmin_Click(object sender, RoutedEventArgs e) {
            if (_badmin == null) _badmin = new Badmin();
            RootFrame.Navigate(_badmin);
        }
        private void MainPage_Click(object sender, RoutedEventArgs e) {
            if (_mainPage == null) _mainPage = new MainPage();
            RootFrame.Navigate(_mainPage);
            _badmin?.Dispose();
        }
    }
}


