using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace SampleApps.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class VoicePackagePage : Page
    {
        private object data;
        public VoicePackagePage()
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
            data = e.Parameter;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void voicePackageListView_Loaded(object sender, RoutedEventArgs e)
        {
            voicePackageListView.ItemsSource = data;
        }

        private void imgBack_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        private void imgHome_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
                
        private async void btnSend_Click(object sender, RoutedEventArgs e)
        {
            string recipients = string.Empty;
            string body = string.Empty;

            var clickedItem = (sender as Button).DataContext;

            if (clickedItem.GetType() == typeof(G3Packages))
            {
                body = ((G3Packages)clickedItem).send_to;
                recipients = ((G3Packages)clickedItem).code;
            }
            else if (clickedItem.GetType() == typeof(PrepaidPackage))
            {
                body = ((PrepaidPackage)clickedItem).send_to;
                recipients = ((PrepaidPackage)clickedItem).code;
            }
            else if (clickedItem.GetType() == typeof(PostpaidPackage))
            {
                body = ((PostpaidPackage)clickedItem).send_to;
                recipients = ((PostpaidPackage)clickedItem).code;
            }
            else if (clickedItem.GetType() == typeof(TeletalkCorporate))
            {
                body = ((TeletalkCorporate)clickedItem).send_to;
                recipients = ((TeletalkCorporate)clickedItem).code;
            }

            if (recipients == "empty")
            {
                Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(body, "Voice Package");
            }
            else
            {
                SmsDialog smsDialog = new SmsDialog(body, recipients);
                await smsDialog.ShowAsync();
            }
        }

        private async void imgTeletalk_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("http://www.teletalk.com.bd/"));
        }

        private async void imgFacebook_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://www.facebook.com/yourTELETALK/"));
        }

        private async void imgYoutube_Tapped(object sender, TappedRoutedEventArgs e)
        {
            await Launcher.LaunchUriAsync(new Uri("https://www.youtube.com/channel/UCSnD9nJ3w4WqU0V6LG7b6Vg"));
        }
    }
}
