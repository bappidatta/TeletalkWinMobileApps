using SampleApps.Models;
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
    public sealed partial class VoicePackageDialog : ContentDialog
    {
        Frame rootFrame = Window.Current.Content as Frame;
        public RootObject data { get; set; }
        public VoicePackageDialog()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn3gPackage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(VoicePackagePage), data.g3_packages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrepaidPackage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(VoicePackagePage), data.prepaid_packages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPostpaidPackage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(VoicePackagePage), data.postpaid_packages);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCorporatePackage_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            rootFrame.Navigate(typeof(VoicePackagePage), data.teletalk_corporate);
        }
    }
}
