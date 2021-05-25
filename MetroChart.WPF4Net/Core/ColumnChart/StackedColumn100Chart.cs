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
    public class StackedColumn100Chart : ChartBase
    {
        /// <summary>
        /// Initializes the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        static StackedColumn100Chart()        
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StackedColumn100Chart), new FrameworkPropertyMetadata(typeof(StackedColumn100Chart)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        public StackedColumn100Chart()
        {
            this.DefaultStyleKey = typeof(StackedColumn100Chart);

        }

        protected override double GridLinesMaxValue
        {
            get
            {
                return 100.0;
            }
        }
    }
}