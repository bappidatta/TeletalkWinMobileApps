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
    public sealed partial class SmsDialog : ContentDialog
    {
        public SmsDialog(string body, string recipients)
        {
            this.InitializeComponent();

            txtCode.Text   = body;
            txtSender.Text = recipients;
        }

        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            Windows.ApplicationModel.Chat.ChatMessage msg = new Windows.ApplicationModel.Chat.ChatMessage();
            msg.Body = txtCode.Text;
            msg.Recipients.Add(txtSender.Text);
            await Windows.ApplicationModel.Chat.ChatMessageManager.ShowComposeSmsMessageAsync(msg);
        }
    }
}
