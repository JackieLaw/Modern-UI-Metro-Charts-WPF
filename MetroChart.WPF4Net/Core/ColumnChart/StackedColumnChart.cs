﻿namespace De.TorstenMandelkow.MetroChart
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
    public class StackedColumnChart : ChartBase
    {
        /// <summary>
        /// Initializes the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        static StackedColumnChart()        
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StackedColumnChart), new FrameworkPropertyMetadata(typeof(StackedColumnChart)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        public StackedColumnChart()
        {
            this.DefaultStyleKey = typeof(StackedColumnChart);
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