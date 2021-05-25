namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Windows;

    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows;

    public class DoughnutChart : PieChart
    {
        protected override double GridLinesMaxValue
        {
            get
            {
                return 0.0;
            }
        }
    }
}