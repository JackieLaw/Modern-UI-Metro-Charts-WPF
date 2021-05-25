﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows.Controls;
using System.Windows;
using System.Windows.Media.Animation;

namespace De.TorstenMandelkow.MetroChart
{
    public class FadingListView : ItemsControl
    {
        public static readonly DependencyProperty RealWidthProperty =
            DependencyProperty.Register("RealWidth", typeof(double), typeof(FadingListView),
            new PropertyMetadata(0.0));
        public static readonly DependencyProperty RealHeightProperty =
            DependencyProperty.Register("RealHeight", typeof(double), typeof(FadingListView),
            new PropertyMetadata(0.0));

        static FadingListView()
        {
            //DefaultStyleKeyProperty.OverrideMetadata(typeof(FadingListView), new FrameworkPropertyMetadata(typeof(FadingListView))); 

        }

        public FadingListView()
        {
            this.SizeChanged += FadingListView_SizeChanged;

            //this.DefaultStyleKey = typeof(FadingListView);

           
        }

        public double RealWidth
        {
            get
            {
                return (double)GetValue(RealWidthProperty);
            }
            set
            {
                SetValue(RealWidthProperty, value);
            }
        }

        public double RealHeight
        {
            get
            {
                return (double)GetValue(RealHeightProperty);
            }
            set
            {
                SetValue(RealHeightProperty, value);
            }
        }

        void FadingListView_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            RealWidth = this.ActualWidth;
            RealHeight = this.ActualHeight;
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            if (this.Items != null)
            {
                if (this.Items.Count < 100)
                {
                    int index = this.ItemContainerGenerator.IndexFromContainer(element);
                    var lb = (ContentPresenter)element;

                    TimeSpan waitTime = TimeSpan.FromMilliseconds(index * (500.0 / this.Items.Count));

                    lb.Opacity = 0.0;
                    DoubleAnimation anm = new DoubleAnimation();
                    anm.From = 0;
                    anm.To = 1;
                    anm.Duration = TimeSpan.FromMilliseconds(250);
                    anm.BeginTime = waitTime;

                    Storyboard storyda = new Storyboard();
                    storyda.Children.Add(anm);
                    Storyboard.SetTarget(storyda, lb);

                    Storyboard.SetTargetProperty(storyda, new PropertyPath(OpacityProperty));

                    storyda.Begin();
                }
            }

            base.PrepareContainerForItemOverride(element, item);
        }
    }
}