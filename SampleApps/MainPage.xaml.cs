using Newtonsoft.Json;
using SampleApps.Models;
using SampleApps.Pages;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Phone.UI.Input;
using Windows.Storage;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace SampleApps
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public RootObject data { get; set; }
        private Windows.Storage.StorageFolder localFolder = Windows.Storage.ApplicationData.Current.LocalFolder;

        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.

            HardwareButtons.BackPressed += HardwareButtons_BackPressed;

            // Check if ExtendedSplashscreen.xaml is on the backstack and remove   
            if (Frame.BackStack.Count() == 1)
            {
                Frame.BackStack.RemoveAt(Frame.BackStackDepth - 1);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HardwareButtons_BackPressed(object sender, BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    string url = "http://www.ticonsys.com/teletalk/api/?time=current_time&token=random_number&hash=md5(time + ttyl957 + token)";

                    data = new RootObject();

                    using (HttpClient client = new HttpClient())
                    {
                        using (HttpResponseMessage response = await client.GetAsync(url))
                        {
                            if (response.IsSuccessStatusCode)
                            {
                                string content = await response.Content.ReadAsStringAsync();

                                StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt", CreationCollisionOption.ReplaceExisting);

                                await FileIO.WriteTextAsync(sampleFile, content);
                            }
                        }
                    }
                }

                StorageFile storedFile = await localFolder.GetFileAsync("dataFile.txt");
                string storedContent = await FileIO.ReadTextAsync(storedFile);

                data = JsonConvert.DeserializeObject<RootObject>(storedContent);

                if (NetworkInterface.GetIsNetworkAvailable())
                {
                    flipView1.ItemsSource = data.images;
                }
                else
                {
                    var imageList = new List<Image>();
                    imageList.Add(new Image { id = "1", imageUrl = "Assets/teletalkgicon.png" });
                    flipView1.ItemsSource = imageList;
                }
            }
            catch(Exception ex)
            {

            }
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<ListViewValue> GetTaskViewList()
        {
            List<ListViewValue> taskList = new List<ListViewValue>();
            taskList.Add(new ListViewValue { id = 0, name = "About Teletalk", image = "Assets/info-24.png" });
            taskList.Add(new ListViewValue { id = 1, name = "Voice Package", image = "Assets/packages_icon.png" });
            taskList.Add(new ListViewValue { id = 2, name = "Internet/Data Packages", image = "Assets/internet_package_icon.png" });
            taskList.Add(new ListViewValue { id = 3, name = "FnF", image = "Assets/fnf_icon.png" });
            taskList.Add(new ListViewValue { id = 4, name = "Package Migration", image = "Assets/package_migration_icon.png" });
            taskList.Add(new ListViewValue { id = 5, name = "VAS", image = "Assets/vas_icon.png" });
            taskList.Add(new ListViewValue { id = 6, name = "Customer Services", image = "Assets/customar_care_icon.png" });
            taskList.Add(new ListViewValue { id = 8, name = "Help Line", image = "Assets/contact_icon.png" });
            taskList.Add(new ListViewValue { id = 7, name = "Others", image = "Assets/contact_icon.png" });

            return taskList;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void menuListView_Loaded(object sender, RoutedEventArgs e)
        {
            menuListView.ItemsSource = GetTaskViewList();
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void menuListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            ListViewValue selectedItem = (ListViewValue)e.ClickedItem;

            switch (selectedItem.id)
            {
                case 0:
                    Frame.Navigate(typeof(AboutPage), data);
                    break;
                case 1:
                    VoicePackageDialog voicePackageDialog = new VoicePackageDialog();
                    voicePackageDialog.data = data;
                    await voicePackageDialog.ShowAsync();
                    break;
                case 2:
                    InternetPackageDialog internetPackageDialog = new InternetPackageDialog();
                    internetPackageDialog.data = data;
                    await internetPackageDialog.ShowAsync();
                    break;
                case 3:
                    FnfDialog fnfDialog = new FnfDialog();
                    await fnfDialog.ShowAsync();
                    break;
                case 4:
                    Frame.Navigate(typeof(PackageMigrationPage), data);
                    break;
                case 5:
                    Frame.Navigate(typeof(VasPage), data);
                    break;
                case 6:
                    Frame.Navigate(typeof(CustomerServicePage), data);
                    break;
                case 7:
                    Frame.Navigate(typeof(UsefullContactPage), data);
                    break;
                case 8:
                    Windows.ApplicationModel.Calls.PhoneCallManager.ShowPhoneCallUI("121", "Help Line");
                    break;
                default:
                    break;
            }
        }

        private async void imgMenu_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MenuDialog menuDialog = new MenuDialog();
            menuDialog.data = data;
            await menuDialog.ShowAsync();
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
