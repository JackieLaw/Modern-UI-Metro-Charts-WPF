namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Text;
    using System.Windows;

       
    public class PieChart : ChartBase
    {
        #region Constructors

        /// <summary>
        /// Initializes the <see cref="PieChart"/> class.
        /// </summary>
        static PieChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PieChart), new FrameworkPropertyMetadata(typeof(PieChart)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PieChart"/> class.
        /// </summary>
        public PieChart()
        {
            this.DefaultStyleKey = typeof(PieChart);

            
        }

        #endregion Constructors

        protected override double GridLinesMaxValue
        {
            get
            {
                return 0.0;
            }
        }

        protected virtual bool IsDoughtnutEnabled
        {
            get
            {
                return false;
            }
        }

        public double PieMinimalSize
        {
            get { return (double)GetValue(PieMinimalSizeProperty); }
            set { SetValue(PieMinimalSizeProperty, value); }
        }

        public static readonly DependencyProperty PieMinimalSizeProperty =
          DependencyProperty.Register("PieMinimalSize",
          typeof(double), typeof(PieChart), new PropertyMetadata(250.0));

        public static readonly DependencyProperty InnerRadiusRatioProperty =
            DependencyProperty.Register("InnerRadiusRatio", typeof(double), typeof(PieChart),
            new PropertyMetadata(0.0));

        public double InnerRadiusRatio
        {
            get { return (double)GetValue(InnerRadiusRatioProperty); }
            set { SetValue(InnerRadiusRatioProperty, value); }
        }

        
    }
}