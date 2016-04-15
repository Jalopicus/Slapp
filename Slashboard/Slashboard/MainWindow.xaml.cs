using System;
using System.Windows;
using System.Windows.Controls;
using Datality;
using Datality.Minions;

namespace Slashboard {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainMinion Minion { get; set; }

        public Pro Pro { get; set; }
        public Blend Blend { get; set; }

        public MainWindow() {
            InitializeComponent();
            Minion = new MainMinion();
            DataContext = Minion;
        }
        private void NavJump(object sender, RoutedEventArgs e) {
            var snd = (Button)sender;
            var whichBox = (snd.Name.StartsWith("Pro", StringComparison.CurrentCulture)) ? ProCata : BlendCata;
            var howFar = (snd.Name.EndsWith("Up", StringComparison.CurrentCulture)) ? 1 : -1;
            whichBox.NavJump(howFar);
            if (snd.Name.StartsWith("Pro", StringComparison.CurrentCulture)) {
                ProCataGo_Click(ProCataGo, new RoutedEventArgs());
            }
            else {
                BlendCataGo_Click(BlendCataGo, new RoutedEventArgs());
            }
        }
        private void Save_Click(object sender, RoutedEventArgs e) {
            Minion.Save();
        }
        private void New_Click(object sender, RoutedEventArgs e) {
            Minion.NewPro();
        }
        private void NewBlend_Click(object sender, RoutedEventArgs e) {
         //   Minion.NewBlend();
        }
        private void DelBlend_Click(object sender, RoutedEventArgs e) {
           //Minion.Blend.Delete();
        }
        private void ProCataGo_Click(object sender, RoutedEventArgs e) {
            if (ProCata.SelectedValue == null) return;
            Minion.NavTo(ProCata.ToId());
            
        }
        private void BlendCataGo_Click(object sender, RoutedEventArgs e) {
            if (BlendCata.SelectedValue == null) return;
            Minion.BlNavTo(BlendCata.ToId());
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
        /// <summary>
        /// Returns the Id of the selected item as determined by the markup for SelectedValuePath
        /// </summary>
        /// <param name="whichCb">Which combobox?</param>
        /// <returns>Integer corresponding to the Id</returns>
        public static int ToId(this ComboBox whichCb) {
            //what a fucking mess. go home.
            if (!whichCb.HasItems()) return -1; //Throw???
            var ret = (whichCb.SelectedItem) ?? whichCb.Items[0];
            return (int)ret;
        }
    }
}
