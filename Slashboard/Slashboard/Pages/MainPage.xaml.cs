using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Datality.Smashley;
using Datality.Overlords;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq.Expressions;
using MahApps.Metro.Controls;
using Slashboard.Mods;
namespace Slashboard {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainPage : Page, IOverlord {
        public AlphaOverlord Overlord { get; set; } = new AlphaOverlord();
        public List<Thing> LocalSp { get { return _specList; } }
        private List<Thing> _specList;
        public MainPage() {
            InitializeComponent();
            OkGo();
            Overlord.ProMinion.LootSwap += MasterLooter;
            Overlord.BrandMinion.LootSwap += MasterLooter;
            Overlord.BlendMinion.LootSwap += MasterLooter;
            foreach (var child in BlendStack.Children) {
                ((Fielder)child).GotCleared += HandleCleared;
            }
        }
        private void OkGo() {
            _specList = new List<Thing>();
            foreach (var x in BlendStack.Children) {
                var y = (Fielder)x;
                if ( y.IsVisible) _specList.Add(new Thing(1, y.Label));
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e) {
           ProStack.DataContext = Overlord.ProMinion.LootItem;
            BrandStack.DataContext = Overlord.BrandMinion.LootItem;
            BlendStack.DataContext = Overlord.BlendMinion.LootItem;

        }
        public void MasterLooter(object sender, PropertyChangedEventArgs e) {
            ProStack.DataContext = Overlord.ProMinion.LootItem;
            BrandStack.DataContext = Overlord.BrandMinion.LootItem;
            BlendStack.DataContext = Overlord.BlendMinion.LootItem;
        }
        public void HandleCleared(object sender, RoutedEventArgs e) {
            var snd = (Fielder)sender;
            BlendStack.InvalidateVisual();
        }
       
        public void Dispose() {
            Overlord?.Dispose();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            int a = 1;
        }

        private void DropDownButton_Selected(object sender, RoutedEventArgs e) {
            var snd = (ListBoxItem)sender;
        }

        private void ContextMenu_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e) {
            var a = 1;
        }

        private void ContextMenu_GotMouseCapture(object sender, System.Windows.Input.MouseEventArgs e) {
            var fuckthis = 1;
        }

        private void SplitButt_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var snd = (SplitButton)sender;
            var thng = (Thing) snd.SelectedItem;
            BlendStack.FindChild<Fielder>(thng.Text).Val = "";
            BlendStack.InvalidateVisual();
        }
    }
    public class HideNullConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return value == null ? (Visibility.Collapsed) : (Visibility.Visible);
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
   public class Spec {
        public Spec(string propName, string dispName, bool vis) {
            Visible = vis;
            DispName = dispName;
            PropName = propName;
        }
        public bool Visible { get; set; }
        public string DispName { get; set; }
        public string PropName { get; set; }
    }
}
