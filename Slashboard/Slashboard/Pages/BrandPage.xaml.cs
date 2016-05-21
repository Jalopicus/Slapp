using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Datality;
using Datality.Smashley;
using Datality.Overlords;
using System.Linq;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class BrandPage : Page, IOverlord {
        public ElderOverlord<Brand> Overlord { get; set; } = new ElderOverlord<Brand>();
        public BrandPage() {
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
