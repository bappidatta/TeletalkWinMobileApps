using SampleApps.Models;
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
            List<VasViewModel> vasList = new List<VasViewModel>();
            VasViewModel vasVM;
            List<ChildViewModel> childList;
            string _url = string.Empty;
            string _name = string.Empty;
            string _buttonText = string.Empty;
            string _isVisible = string.Empty;

            foreach(Va item in data.vas)
            {
                foreach (Child parent in item.child)
                {
                    vasVM = new VasViewModel();
                    vasVM.name = parent.name;

                    childList = new List<ChildViewModel>();

                    foreach (var child in parent.child)
                    {
                        _url = this.GetUrl(child.name);

                        if(_url != string.Empty)
                        {
                            _name = child.name.Replace(_url, "");
                            _buttonText = parent.name == "Mobile TV" ? "To Visit" : "For Details";
                            _isVisible = "Visible";
                        }
                        else
                        {
                            _name = child.name;
                            _buttonText = string.Empty;
                            _isVisible = "Collapsed";
                        }
                        
                        childList.Add(new ChildViewModel() { name = _name, url = _url, buttonText = _buttonText, isVisible = _isVisible });
                    }

                    vasVM.child = childList;
                    vasList.Add(vasVM);
                }
            }

            vasListView.ItemsSource = vasList;
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
        
        private string GetUrl(string text)
        {
            if (text.Contains("http"))
            {
                Regex urlRx = new Regex(@"((https?|ftp|file)\://|www.)[A-Za-z0-9\.\-]+(/[A-Za-z0-9\?\&\=;\+!'\(\)\*\-\._~%]*)*", RegexOptions.IgnoreCase);
                Match match = urlRx.Match(text);

                return match.Value;
            }
            else
            {
                return string.Empty;
            }
        }

        private async void btnVas_Click(object sender, RoutedEventArgs e)
        {
            ChildViewModel clickedItem = (ChildViewModel)(sender as Button).DataContext;

            await Launcher.LaunchUriAsync(new Uri(clickedItem.url));
        }
    }
}
