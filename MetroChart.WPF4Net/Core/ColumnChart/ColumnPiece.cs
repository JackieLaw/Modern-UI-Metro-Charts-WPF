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
    

    public class ColumnPiece : PieceBase
    {
        #region Fields

        private Border slice = null;

        public static readonly DependencyProperty PercentageProperty =
            DependencyProperty.Register("Percentage", typeof(double), typeof(ColumnPiece),
            new PropertyMetadata(0.0, new PropertyChangedCallback(OnPercentageChanged)));
        
        public static readonly DependencyProperty ColumnHeightProperty =
            DependencyProperty.Register("ColumnHeight", typeof(double), typeof(ColumnPiece),
            new PropertyMetadata(0.0));
        
        #endregion Fields

        #region Constructors

        static ColumnPiece()        
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ColumnPiece), new FrameworkPropertyMetadata(typeof(ColumnPiece)));

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnPiece"/> class.
        /// </summary>
        public ColumnPiece()
        {
            this.DefaultStyleKey = typeof(ColumnPiece);
            Loaded += ColumnPiece_Loaded;
        }

        #endregion Constructors

        #region Properties

        public double Percentage
        {
            get { return (double)GetValue(PercentageProperty); }
            set { SetValue(PercentageProperty, value); }
        }

        public double ColumnHeight
        {
            get { return (double)GetValue(ColumnHeightProperty); }
            set { SetValue(ColumnHeightProperty, value); }
        }
 
        #endregion Properties

        #region Methods

        private static void OnPercentageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as ColumnPiece).DrawGeometry();
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

                double startHeight = 0;
                if (slice.Height > 0)
                {
                    startHeight = slice.Height;
                }

                DoubleAnimation scaleAnimation = new DoubleAnimation();
                scaleAnimation.From = startHeight;
                scaleAnimation.To = this.ClientHeight * Percentage;
                scaleAnimation.Duration = TimeSpan.FromMilliseconds(withAnimation ? 500: 0);
                scaleAnimation.EasingFunction = new QuarticEase() { EasingMode = EasingMode.EaseOut };
                Storyboard storyScaleX = new Storyboard();
                storyScaleX.Children.Add(scaleAnimation);

                Storyboard.SetTarget(storyScaleX, slice);

                //scaleAnimation.EnableDependentAnimation = true;
                //Storyboard.SetTargetProperty(storyScaleX, "Height");

                Storyboard.SetTargetProperty(storyScaleX, new PropertyPath("Height"));

                storyScaleX.Begin();
   
            }
            catch (Exception ex)
            {
            }
        }

        #endregion Methods
    }
}