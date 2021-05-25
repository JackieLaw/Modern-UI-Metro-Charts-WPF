﻿namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows;


    public class RowSeriesPanel : Grid

    {
        protected override Size MeasureOverride(Size availableSize)
        {
            foreach (UIElement child in Children)
                child.Measure(availableSize);

            return base.MeasureOverride(availableSize);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            Size cellSize = new Size(finalSize.Width, finalSize.Height / Children.Count);
            int row = 0, col = 0;

            double leftposition = 0;
            foreach (UIElement child in Children)
            {
                double height= finalSize.Height;
                double width = child.DesiredSize.Width;
                double x = leftposition;
                double y = 0;
                Rect rect = new Rect(x, y, width, height);
                child.Arrange(rect);

                leftposition += width;
                col++;
            }
            return finalSize;
        }
    }
}
