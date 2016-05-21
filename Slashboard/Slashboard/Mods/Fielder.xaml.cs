using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;


namespace Slashboard.Mods {
    /// <summary>
    /// Interaction logic for Fielder.xaml
    /// </summary>
    public partial class Fielder : UserControl {
        public Fielder() {
            InitializeComponent();
            LayoutRoot.DataContext = this;
        }
        public string Label {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string),
                typeof(Fielder), new PropertyMetadata(""));
        public string Val {
            get { return (string)GetValue(ValProperty); }
            set { SetValue(ValProperty, value); }
        }
        public static readonly DependencyProperty ValProperty =
            DependencyProperty.Register("Val", typeof(string),
                typeof(Fielder), new PropertyMetadata(""));

        private void Tb_TextChanged(object sender, TextChangedEventArgs e) {
            var snd = (TextBox)sender;
            if (snd.Text.Length == 0) {
                snd.Text = null;
                GotCleared?.Invoke(this, new RoutedEventArgs());
            }
        }
        public event RoutedEventHandler GotCleared;
    }
    public class NullConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value == null) {
                return Visibility.Collapsed;
            } else {
                return Visibility.Visible;
            }
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
    public class ClearButton : ICommand {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {
            throw new NotImplementedException();
        }

        public void Execute(object parameter) {
            throw new NotImplementedException();
        }
    }
}
