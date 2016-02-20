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
    public sealed partial class FnfDialog : ContentDialog
    {
        public FnfDialog()
        {
            this.InitializeComponent();
        }

        private async void AddFnf_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SmsDialog smsDialog = new SmsDialog("363", "Add 0155XXXXXXXX");
            await smsDialog.ShowAsync();
        }

        private async void DeleteFnf_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SmsDialog smsDialog = new SmsDialog("363", "del 0155XXXXXXXX");
            await smsDialog.ShowAsync();
        }

        private async void CheckFnf_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            SmsDialog smsDialog = new SmsDialog("363", "see 0155XXXXXXXX");
            await smsDialog.ShowAsync();
        }

        private void ChangeFnf_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI("1515", "Teletalk");
        }
    }
}
