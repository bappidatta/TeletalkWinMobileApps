using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage.Pickers.Provider;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SampleApps.Pages
{
    public sealed partial class InternetPackageDialog : ContentDialog
    {
        Frame rootFrame = Window.Current.Content as Frame;
        public RootObject data { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public InternetPackageDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreeGPrepaidInternet_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(InternetPackagePage), data.g3_prepaid_internet_packages);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ThreeGPostpaidInternet_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(InternetPackagePage), data.g3_postpaid_internet_packages);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoGPrepaidInternet_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(InternetPackagePage), data.g2_prepaid_internet_packages);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TwoGPostpaidInternet_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(InternetPackagePage), data.g2_postpaid_internet_packages);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorporatePrepaidInternet_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(InternetPackagePage), data.teletalk_corporate_prepaid);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CorporatePostpaidInternet_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(InternetPackagePage), data.teletalk_corporate_postpaid);
        }
    }
}
