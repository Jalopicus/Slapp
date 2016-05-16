using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Datality.Smashley;
using Datality.Overlords;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : Page, IOverlord {
        public ElderOverlord<Brand> Overlord { get; set; } = new ElderOverlord<Brand>();
        public MainPage() {
            InitializeComponent();
            Overlord.Ops.Minion.LootSwap += LootSwapHandler;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) {
            Root.DataContext = Overlord;
        }
        public void LootSwapHandler(object sender, PropertyChangedEventArgs e) {
            LootWindow.DataContext = Overlord.Ops.Minion.LootItem;
        }
        public void Dispose() {
            Overlord.Dispose();
        }
    }

}
