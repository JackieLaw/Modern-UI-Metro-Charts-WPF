namespace De.TorstenMandelkow.MetroChart
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;  
    using System.Reflection;
    using System.Collections.Specialized;
    using System.Windows.Input;

    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    


    public class BarPiece : PieceBase
    {
        #region Fields

        private Border slice = null;

        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register("Percentage", typeof(double), typeof(BarPiece),
            new PropertyMetadata(0.0, new PropertyChangedCallback(OnPercentageChanged)));
        
        public static readonly DependencyProperty ColumnWidthProperty =
            DependencyProperty.Register("ColumnWidth", typeof(double), typeof(BarPiece),
            new PropertyMetadata(0.0));

        #endregion Fields

        #region Constructors

        static BarPiece()        
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BarPiece), new FrameworkPropertyMetadata(typeof(BarPiece)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnPiece"/> class.
        /// </summary>
        public BarPiece()
        {
            this.DefaultStyleKey = typeof(BarPiece);

            Loaded += ColumnPiece_Loaded;
        }

        #endregion Constructors

        #region Properties

        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public double ColumnWidth
        {
            get { return (double)GetValue(ColumnWidthProperty); }
            set { SetValue(ColumnWidthProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnPercentageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as BarPiece).DrawGeometry();
        }

        protected override void InternalOnApplyTemplate()
        {
            slice = this.GetTemplateChild("Slice") as Border;
            RegisterMouseEvents(slice);
        }

        void ColumnPiece_Loaded(object sender, RoutedEventArgs e)
        {
            DrawGeometry();
        }

        /// <summary>
        /// Draws the geometry.
        /// </summary>
        /// <param name="context">The context.</param>
        protected override void DrawGeometry(bool withAnimation = true)
        {    
            try
            {
                if (this.ClientWidth <= 0.0)
                {
                    return;
                }
                if (this.ClientHeight <= 0.0)
                {
                    return;
                }

                double startWidth = 0;
                if (slice.Width > 0)
                {
                    startWidth = slice.Width;
                }

                DoubleAnimation scaleAnimation = new DoubleAnimation();
                scaleAnimation.From = startWidth;
                scaleAnimation.To = this.ClientWidth * Percentage;
                scaleAnimation.Duration = TimeSpan.FromMilliseconds(500);
                scaleAnimation.EasingFunction = new QuarticEase() { EasingMode = EasingMode.EaseOut };
                Storyboard storyScaleX = new Storyboard();
                storyScaleX.Children.Add(scaleAnimation);
                
                Storyboard.SetTarget(storyScaleX, slice);

                //scaleAnimation.EnableDependentAnimation = true;
                //Storyboard.SetTargetProperty(storyScaleX, "Width");
                Storyboard.SetTargetProperty(storyScaleX, new PropertyPath("Width"));

                storyScaleX.Begin();
                         
                //SetValue(ColumnPiece.ColumnHeightProperty, this.ClientHeight * Percentage);
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Methods
    }
}