namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Windows;

   
    public class RadialGaugeChart : ChartBase
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="PieChart"/> class.
        /// </summary>
        static RadialGaugeChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(RadialGaugeChart), new FrameworkPropertyMetadata(typeof(RadialGaugeChart)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PieChart"/> class.
        /// </summary>
        public RadialGaugeChart()
        {
            this.DefaultStyleKey = typeof(RadialGaugeChart);

        }

        #endregion Constructors

        protected override double GridLinesMaxValue
        {
            get
            {
                return 0.0;
            }
        }
    }
}