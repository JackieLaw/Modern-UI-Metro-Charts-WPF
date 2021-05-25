using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using System.Windows.Navigation;
using System.Windows.Threading;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xml;

namespace Test.WPF4Net
{
    public class PortableHyperLinkButton : Button
    {
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(PortableHyperLinkButton),
                                        new PropertyMetadata(null));

        public static readonly DependencyProperty UrlProperty =
            DependencyProperty.Register("Url", typeof(string), typeof(PortableHyperLinkButton),
                                        new PropertyMetadata(null));

        public string Url
        {
            get { return (string)GetValue(UrlProperty); }
            set { SetValue(UrlProperty, value); }
        }

        public PortableHyperLinkButton()
        {
            this.Click += HyperLinkButton_Click;

            this.DefaultStyleKey = typeof(PortableHyperLinkButton);

        }

        static PortableHyperLinkButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PortableHyperLinkButton), new FrameworkPropertyMetadata(typeof(PortableHyperLinkButton)));

        }

        void HyperLinkButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Windows.System.Launcher.LaunchUriAsync(new Uri(Url));
                //HtmlPage.Window.Navigate(new Uri(Url), "_blank");
                Process.Start(Url);
            }
            catch (Exception)
            {
            }
        }
    }
}
