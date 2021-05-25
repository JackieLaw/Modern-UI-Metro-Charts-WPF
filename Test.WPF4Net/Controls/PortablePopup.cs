using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Controls.Primitives;


namespace Test.WPF4Net
{
    /// <summary>
    /// Layout aware page which can be used in SL, WinRT and WPF
    /// </summary>
    public class PortablePopup : ContentControl
    {
        private double CONSTPOPUPWIDTH = 400;

        public bool IsOpen
        {
            get { return (bool)GetValue(IsOpenProperty); }
            set { SetValue(IsOpenProperty, value); }
        }

        public static readonly DependencyProperty IsOpenProperty =
          DependencyProperty.Register("IsOpen",
          typeof(bool), typeof(PortablePopup), new PropertyMetadata(false, OnIsOpenChanged));

        public object HideOnPropertyChange
        {
            get { return (object)GetValue(HideOnPropertyChangeProperty); }
            set { SetValue(HideOnPropertyChangeProperty, value); }
        }

        public static readonly DependencyProperty HideOnPropertyChangeProperty =
          DependencyProperty.Register("HideOnPropertyChange",
          typeof(object), typeof(PortablePopup), new PropertyMetadata(false, OnPropertyChanged));

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            (d as PortablePopup).HidePopup();
        }

        private void HidePopup()
        {
            if (popup != null)
            {
                ClosePopup();
            }
        }

        private void ClosePopup()
        {
            this.SetValue(IsOpenProperty, false);
        }

        private static void OnIsOpenChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((e.NewValue as bool?) == true)
            {
                (d as PortablePopup).OnPopupOpened();
            }
            else
            {
                (d as PortablePopup).OnPopupClosed();
            }
        }

        private void OnPopupClosed()
        {
        }

        private void OnPopupOpened()
        {
        }


        public PortablePopup()
        {

            this.DefaultStyleKey = typeof(PortablePopup);
     
        }

        static PortablePopup()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PortablePopup), new FrameworkPropertyMetadata(typeof(PortablePopup)));

        }

        public override void OnApplyTemplate()
        {
            InternalOnApplyTemplate();
        }

        private ContentControl contentControl = null;
        private Popup popup = null;
        private Button closeButton = null;
        public void InternalOnApplyTemplate()
        {
            popup = this.GetTemplateChild("PART_Popup") as Popup;
            contentControl = this.GetTemplateChild("PART_Content") as ContentControl;
            closeButton = this.GetTemplateChild("PART_CloseButton") as Button;

            closeButton.Click += closeButton_Click;

            popup.Width = CONSTPOPUPWIDTH;
            popup.AllowsTransparency = true;
            popup.HorizontalOffset = -75;
            popup.Height = Application.Current.MainWindow.Height - 150;

            base.OnApplyTemplate();
        }

        void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.IsOpen = false;
        }
        
    }
}
