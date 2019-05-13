using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Xml;
using Arknights_Simulation.Controls;
using Arknights_Simulation.Protocols;

namespace Arknights_Simulation
{
    public class DesignerCanvas : Canvas
    {
        // start point of the rubberband drag operation
        private Point? rubberbandSelectionStartPoint;

        // keep track of selected items 
        private List<ISelectable> selectedItems;

        public DesignerCanvas()
        {
            AllowDrop = true;
        }

        public List<ISelectable> SelectedItems
        {
            get
            {
                if (selectedItems == null)
                    selectedItems = new List<ISelectable>();
                return selectedItems;
            }
            set { selectedItems = value; }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Source == this)
            {
                // in case that this click is the start for a 
                // drag operation we cache the start point
                rubberbandSelectionStartPoint = e.GetPosition(this);

                // if you click directly on the canvas all 
                // selected items are 'de-selected'
                foreach (var item in SelectedItems)
                    item.IsSelected = false;
                selectedItems.Clear();

                // clear property panel values
                Grid FloorPropertyGrid = (Grid)this.FindName("FloorPropertyGrid");
                FloorPropertyGrid.DataContext = null;
                e.Handled = true;
            }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            e.Handled = true;
        }

        protected override void OnDrop(DragEventArgs e)
        {
            base.OnDrop(e);
            var dragObject = e.Data.GetData(typeof(DragObject)) as DragObject;
            if (dragObject != null && !string.IsNullOrEmpty(dragObject.Xaml))
            {
                DesignerItem newItem = null;
                Floor content = XamlReader.Load(XmlReader.Create(new StringReader(dragObject.Xaml))) as Floor;

                if (content != null)
                {
                    newItem = new DesignerItem();
                    newItem.Content = content;

                    var position = e.GetPosition(this);

                    if (dragObject.DesiredSize.HasValue)
                    {
                        var desiredSize = dragObject.DesiredSize.Value;
                        newItem.Width = desiredSize.Width;
                        newItem.Height = desiredSize.Height;

                        SetLeft(newItem, Math.Max(0, position.X - newItem.Width / 2));
                        SetTop(newItem, Math.Max(0, position.Y - newItem.Height / 2));
                    }
                    else
                    {
                        SetLeft(newItem, Math.Max(0, position.X));
                        SetTop(newItem, Math.Max(0, position.Y));
                    }

                    Children.Add(newItem);

                    //update selection
                    foreach (var item in SelectedItems)
                        item.IsSelected = false;
                    SelectedItems.Clear();
                    newItem.IsSelected = true;
                    SelectedItems.Add(newItem);

                    Grid FloorPropertyGrid = (Grid)this.FindName("FloorPropertyGrid");
                    FloorPropertyGrid.DataContext = newItem.Content as Floor;
                }

                e.Handled = true;
            }
        }

        protected override Size MeasureOverride(Size constraint)
        {
            var size = new Size();
            foreach (UIElement element in Children)
            {
                var left = GetLeft(element);
                var top = GetTop(element);
                left = double.IsNaN(left) ? 0 : left;
                top = double.IsNaN(top) ? 0 : top;

                //measure desired size for each child
                element.Measure(constraint);

                var desiredSize = element.DesiredSize;
                if (!double.IsNaN(desiredSize.Width) && !double.IsNaN(desiredSize.Height))
                {
                    size.Width = Math.Max(size.Width, left + desiredSize.Width);
                    size.Height = Math.Max(size.Height, top + desiredSize.Height);
                }
            }
            // add margin 
            size.Width += 10;
            size.Height += 10;
            return size;
        }
    }
}