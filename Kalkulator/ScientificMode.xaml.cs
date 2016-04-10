using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Kalkulator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ScientificMode : Page
    {
        public ScientificMode()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            console.Text = e.Parameter.ToString();
        }

        private void buttonScientific_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage), console.Text);
            
        }

        private void button_sin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Sin(double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_cos_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Cos(double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_neg_Click(object sender, RoutedEventArgs e)
        {
            if(console.Text!="0")
            {
                if(console.Text[0]=='-')
                {
                    console.Text = console.Text.Remove(0, 1);
                }
                else
                {
                    console.Text = console.Text.Insert(0, "-");
                }
            }
        }

        private void button_tg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Tan(double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_ctg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = (1 / Math.Tan(double.Parse(console.Text))).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_abs_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Abs(double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_squared_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Pow(double.Parse(console.Text), 2).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_root_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Sqrt(double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button__percent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = (double.Parse(console.Text) / 100).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_exp_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Exp(double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_log_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = Math.Log(double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }

        private void button_inv_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                console.Text = (1 / double.Parse(console.Text)).ToString();
            }
            catch
            {
                console.Text = "0";
            }
        }
    }
}
