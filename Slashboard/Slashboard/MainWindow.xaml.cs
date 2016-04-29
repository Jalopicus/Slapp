using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Datality.Minions;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public SaneMinion Minion { get; set; }
        public MainWindow() {
            InitializeComponent();
            Minion = new SaneMinion();
            DataContext = Minion;
        }
        private void Flish(object sender , PropertyChangedEventArgs e) {
            InvalidateVisual();
        }
        private void NavJump(object sender, RoutedEventArgs e) {
            //var snd = (Button)sender;
            //var whichBox = (snd.Name.StartsWith("Pro", StringComparison.CurrentCulture)) ? ProCata : BlendCata;
            //var howFar = (snd.Name.EndsWith("Up", StringComparison.CurrentCulture)) ? 1 : -1;
            //whichBox.NavJump(howFar);
            //if (snd.Name.StartsWith("Pro", StringComparison.CurrentCulture)) {
            //    ProCataGo_Click(ProCataGo, new RoutedEventArgs());
            //}
            //else {
            //    BlendCataGo_Click(BlendCataGo, new RoutedEventArgs());
            //}
        }
        private void Save_Click(object sender, RoutedEventArgs e) {
            Minion.Save();
        }
        private void New_Click(object sender, RoutedEventArgs e) {
            //Minion.NewPro();
        }
        private void NewBlend_Click(object sender, RoutedEventArgs e) {
         //   Minion.NewBlend();
        }
        private void DelBlend_Click(object sender, RoutedEventArgs e) {
           //Minion.Blend.Delete();
        }
        private void ProCataGo_Click(object sender, RoutedEventArgs e) {
            //if (ProCata.SelectedItem == null) return;
            // Minion.ProFetch(((Moniker)ProCata.SelectedItem).Id);
        }
        private void BlendCataGo_Click(object sender, RoutedEventArgs e) {
            //if (BlendCata.SelectedItem == null) return;
            //Minion.BlendFetch(((Moniker)BlendCata.SelectedItem).Id);
        }
        private void AddFormulino_Click(object sender, RoutedEventArgs e) {
            RootGrid.DataContext = null;
            RootGrid.DataContext = Minion;
        }

        private void FilterBox_TextChanged(object sender, TextChangedEventArgs e) {

        }
    }
    public static class ComboBoxExtension {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="whichCb"></param>
        /// <param name="howMany"></param>
        public static void NavJump(this ComboBox whichCb, int howMany) {
            var i = whichCb.SelectedIndex;
            var cnt = whichCb.Items.Count;
            whichCb.SelectedIndex = (cnt > 0) ?  (i + cnt + howMany) % cnt : i;
        }
    }
}
