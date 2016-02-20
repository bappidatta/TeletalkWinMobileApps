using SampleApps.Models;
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
    public sealed partial class UsefullContactPage : Page
    {
        private RootObject data;

        public UsefullContactPage()
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
            data = e.Parameter as RootObject;
        }

        private void usefullContactListView_Loaded(object sender, RoutedEventArgs e)
        {
            List<UsefulContactViewModel> usefullContactList = new List<UsefulContactViewModel>();

            foreach(var item in data.useful_contacts)
            {
                usefullContactList.Add(new UsefulContactViewModel 
                { 
                    ID = item.id, 
                    Title = item.title,
                    Text = !String.IsNullOrEmpty(item.dial_code) ? "Numer: " + item.dial_code :
                          !String.IsNullOrEmpty(item.msg_body) ? item.msg_body : 
                          !String.IsNullOrEmpty(item.other_text) ? item.other_text : "", 
                    Charge = item.charge,
                    DialCode = item.dial_code,
                    MessageBody = item.msg_body,
                    MessageSento = item.msg_sendto,

                    IsVisible  = !String.IsNullOrEmpty(item.other_text) ? "Collapsed" : "Visible",
                    SetWidth = !String.IsNullOrEmpty(item.other_text) ? "480" : "320",
                });
            }

            usefullContactListView.ItemsSource = usefullContactList;
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


        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            UsefulContactViewModel clickedItem = (UsefulContactViewModel)(sender as Button).DataContext;

            if (!String.IsNullOrEmpty(clickedItem.DialCode))
            {
                Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI(clickedItem.DialCode, "Voice Package");
            }
            else if (!String.IsNullOrEmpty(clickedItem.MessageBody))
            {
                SmsDialog smsDialog = new SmsDialog(clickedItem.MessageSento, clickedItem.MessageBody);
                await smsDialog.ShowAsync();
            }
        }
    }
}
