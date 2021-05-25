using System;
using System.Collections;
namespace De.TorstenMandelkow.MetroChart
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Text;
    using System.Collections.Specialized;

    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows;

    public class ChartSeries : ItemsControl
    { 
        public static readonly DependencyProperty DisplayMemberProperty =
            DependencyProperty.Register("DisplayMember",
            typeof(string),
            typeof(ChartSeries),
            new PropertyMetadata(null));
        public static readonly DependencyProperty ValueMemberProperty =
            DependencyProperty.Register("ValueMember",
            typeof(string),
            typeof(ChartSeries),
            new PropertyMetadata(null));
        public static readonly DependencyProperty SeriesTitleProperty =
            DependencyProperty.Register("SeriesTitle",
            typeof(string),
            typeof(ChartSeries),
            new PropertyMetadata(null));
        
        public ChartSeries()
        {   
        }

        public string SeriesTitle
        {
            get
            {
                return (string)GetValue(SeriesTitleProperty);
            }
            set
            {
                SetValue(SeriesTitleProperty, value);
            }
        }

        public string DisplayMember
        {
            get
            {
                return (string)GetValue(DisplayMemberProperty);
            }
            set
            {
                SetValue(DisplayMemberProperty, value);
            }
        }

        public string ValueMember
        {
            get
            {
                return (string)GetValue(ValueMemberProperty);
            }
            set
            {
                SetValue(ValueMemberProperty, value);
            }
        }
    }
}
