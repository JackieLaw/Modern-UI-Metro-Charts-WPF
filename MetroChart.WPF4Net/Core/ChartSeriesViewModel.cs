namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows;

    /// <summary>
    /// we cannot use the ChartSeries directly because we will join the data to internal Chartseries
    /// </summary>
    public class ChartLegendItemViewModel : DependencyObject
    {
        public static readonly DependencyProperty CaptionProperty =
            DependencyProperty.Register("Caption",
            typeof(string),
            typeof(ChartLegendItemViewModel),
            new PropertyMetadata(null));
        public static readonly DependencyProperty ItemBrushProperty =
            DependencyProperty.Register("ItemBrush",
            typeof(Brush),
            typeof(ChartLegendItemViewModel),
            new PropertyMetadata(null));

        public string Caption
        {
            get { return (string)GetValue(CaptionProperty); }
            set { SetValue(CaptionProperty, value); }
        }

        public Brush ItemBrush
        {
            get { return (Brush)GetValue(ItemBrushProperty); }
            set { SetValue(ItemBrushProperty, value); }
        }
    }
}
