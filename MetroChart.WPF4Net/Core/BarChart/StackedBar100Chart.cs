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
    public class StackedBar100Chart : ChartBase
    {
        /// <summary>
        /// Initializes the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        static StackedBar100Chart()        
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StackedBar100Chart), new FrameworkPropertyMetadata(typeof(StackedBar100Chart)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        public StackedBar100Chart()
        {
            this.DefaultStyleKey = typeof(StackedBar100Chart);

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