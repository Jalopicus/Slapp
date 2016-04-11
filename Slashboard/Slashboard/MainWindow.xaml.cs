using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Datality.Minions;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainMinion Minion { get; set; }
        public MainWindow() {
            InitializeComponent();
            Minion = new MainMinion();
            HeroPanel.DataContext = Minion.Pro;
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            var a = 1;
            a = 2;


        }
        private void Nav_Click(object sender, RoutedEventArgs e) {
            var snd = (Button)(sender);
            Minion.Nav(snd.Name == "Up");
            HeroPanel.DataContext = null;
            HeroPanel.DataContext = Minion.Pro;
            ZeroPanel.DataContext = null;
            ZeroPanel.DataContext = Minion.Pro.Blend;
        }
        private void Save_Click(object sernder, RoutedEventArgs e) {
            Minion.Save();
        }
    }
}
