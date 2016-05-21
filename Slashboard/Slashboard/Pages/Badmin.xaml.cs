using System.Windows.Controls;
using Datality.Smashley;
using Datality.Overlords;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for Badmin.xaml
    /// </summary>
    public partial class Badmin : Page {
        public SupremeOverlord<Pro> Overlord { get; set; } = new SupremeOverlord<Pro>();
        public Badmin() {
            InitializeComponent();
            DataContext = Overlord;
        }
        public void Dispose() {
            Overlord?.Dispose();
        }
    }
}
