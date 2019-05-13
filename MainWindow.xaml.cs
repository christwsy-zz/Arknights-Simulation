using Arknights_Simulation.Simulation.Base;
using Arknights_Simulation.Simulation.Models.Agents;
using Arknights_Simulation.Simulation.Models.Enemies;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Arknights_Simulation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TestAttack();
        }

        private void TestAttack()
        {
            Angelina angelina = new Angelina();
            IList<AbstractEnemy> enemies = new List<AbstractEnemy>();
            for (int i = 0; i < 3; i++)
            {
                enemies.Add(new InsectAlpha());
            }
            angelina.PerformSuperchargedAction(enemies);
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