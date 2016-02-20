using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
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
    public sealed partial class VasPage : Page
    {
        private RootObject data;

        public VasPage()
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

        private void vasListView_Loaded(object sender, RoutedEventArgs e)
        {
            List<Child> childs = new List<Child>();

            foreach(Va item in data.vas)
            {
                foreach (Child child in item.child)
                {
                    childs.Add(child);
                }
            }

            vasListView.ItemsSource = childs;
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

        private void parentBorder_Tapped(object sender, TappedRoutedEventArgs e)
        {
            StackPanel vasStackPanel = (StackPanel)VisualTreeHelper.GetParent(sender as Border);

            if (vasStackPanel.Children[2].Visibility == Windows.UI.Xaml.Visibility.Collapsed)
            {
                vasStackPanel.Children[2].Visibility = Windows.UI.Xaml.Visibility.Visible;
            }
            else
            {
                vasStackPanel.Children[2].Visibility = Windows.UI.Xaml.Visibility.Collapsed;
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

        private async void btnChild_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Child2 clickedItem = (Child2)(sender as TextBlock).DataContext;

            if(clickedItem.name.Contains("http"))
            {
                Regex urlRx = new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*", RegexOptions.IgnoreCase);
                Match match = urlRx.Match(clickedItem.name);

                await Launcher.LaunchUriAsync(new Uri(match.Value));
            }
        }
    }
}
