using System.Windows;
using System.Windows.Controls;
using Datality.Overlords;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for PrimaryWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e) {
            var content = (Page) RootFrame.Content;
            ((IOverlord) (content)).Dispose();
        }
    }
}


