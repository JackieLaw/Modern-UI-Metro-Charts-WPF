namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;


    /// <summary>
    /// Represents an Instance of the bar-chart
    /// </summary>
    public class StackedBarChart : ChartBase
    {
        /// <summary>
        /// Initializes the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        static StackedBarChart()        
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StackedBarChart), new FrameworkPropertyMetadata(typeof(StackedBarChart)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        public StackedBarChart()
        {
            this.DefaultStyleKey = typeof(StackedBarChart);

        }

        protected override double GridLinesMaxValue
        {
            get
            {
                return MaxDataPointGroupSum;
            }
        }

        protected override void OnMaxDataPointGroupSumChanged(double p)
        {
            UpdateGridLines();
        }
    }
}