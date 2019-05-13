using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace Arknights_Simulation.Controls
{
    public enum FloorTypes
    {
        [Description("普通可部署低地")]
        Ground,
        [Description("普通可部署高台")]
        Highland,
        [Description("不可部署地面")]
        Forbidden,
        [Description("地面敌人入口")]
        GroundEnemyEntry,
        [Description("空中敌人入口")]
        AirEnemyEntry,
        [Description("敌人出口")]
        EnemyExit,
        [Description("深坑")]
        Pithole,
        [Description("医疗符文")]
        MedicalRune,
        [Description("防御符文")]
        ProtectRune,
        [Description("防空符文")]
        AntiAirRune,
        [Description("草丛")]
        Grass,
        [Description("侦查塔")]
        ScoutTower,
        [Description("EMP震撼装置")]
        EMP,
        [Description("活性源石")]
        ActivatedOriginStone,
        [Description("热泵通道")]
        HeatPump
    }

    public class Floor : Control, INotifyPropertyChanged
    {
        public Floor()
        {
        }

        private void Children_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine(sender);
        }

        static Floor()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Floor), new FrameworkPropertyMetadata(typeof(Floor)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        #region Properties

        public static DependencyProperty FloorTypeProperty = DependencyProperty.Register("FloorType", typeof(FloorTypes),
            typeof(Floor), new FrameworkPropertyMetadata(FloorTypes.Ground));

        public FloorTypes FloorType
        {
            set { SetValue(FloorTypeProperty, value); }
            get { return (FloorTypes)GetValue(FloorTypeProperty); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #endregion

        #region Routed Events

        public static readonly RoutedEvent FloorTypeChangedEvent = EventManager.RegisterRoutedEvent("NdoeTypeChanged",
            RoutingStrategy.Direct, typeof(RoutedPropertyChangedEventHandler<Floor>), typeof(Floor));

        public event RoutedPropertyChangedEventHandler<Floor> FloorTypeChanged
        {
            add { AddHandler(FloorTypeChangedEvent, value); }
            remove { RemoveHandler(FloorTypeChangedEvent, value); }
        }

        #endregion
    }

    public class FloorTypeToVisibility : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((FloorTypes)value == (FloorTypes)parameter)
            {
                return Visibility.Visible;
            }
            else
            {
                return Visibility.Hidden;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}