using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Arknights_Simulation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PropertyTextbox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            BindingExpression binding = (sender as TextBox).GetBindingExpression(TextBox.TextProperty);
            if (binding.DataItem != null)
            {
                binding.UpdateSource();
            }
            // also update the nodes' values
        }
    }

    public class DataContextToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return Visibility.Collapsed;
            }
            else
            {
                return Visibility.Visible;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}