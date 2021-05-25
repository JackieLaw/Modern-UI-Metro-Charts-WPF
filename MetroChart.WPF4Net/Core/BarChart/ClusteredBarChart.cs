namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Input;

    using System.Windows.Media;
    using System.Windows.Controls;


    /// <summary>
    /// Represents an Instance of the bar-chart
    /// </summary>
    public class ClusteredBarChart : ChartBase
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        static ClusteredBarChart()        
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClusteredBarChart), new FrameworkPropertyMetadata(typeof(ClusteredBarChart)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ClusteredColumnChart"/> class.
        /// </summary>
        public ClusteredBarChart()
        {
            this.DefaultStyleKey = typeof(ClusteredBarChart);

        }

        #endregion Constructors

        protected override double GridLinesMaxValue
        {
            get
            {
                return MaxDataPointValue;
            }
        }

        protected override void OnMaxDataPointValueChanged(double p)
        {
            UpdateGridLines();
        }

        public override bool IsUseNextBiggestMaxValue
        {
            get
            {
                return true;
            }
        }
    }
}