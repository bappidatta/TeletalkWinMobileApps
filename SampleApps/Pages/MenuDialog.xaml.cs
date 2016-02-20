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
    public sealed partial class MenuDialog : ContentDialog
    {
        public RootObject data { get; set; }
        Frame rootFrame = Window.Current.Content as Frame;

        public MenuDialog()
        {
            this.InitializeComponent();
        }

        private List<ListViewValue> GetTaskViewList()
        {
            List<ListViewValue> taskList = new List<ListViewValue>();
            taskList.Add(new ListViewValue { id = 1, name = "Voice Package", image = "/Assets/packages_icon.png" });
            taskList.Add(new ListViewValue { id = 2, name = "Internet/Data Packages", image = "/Assets/internet_package_icon.png" });
            taskList.Add(new ListViewValue { id = 3, name = "FnF", image = "/Assets/fnf_icon.png" });
            taskList.Add(new ListViewValue { id = 4, name = "Package Migration", image = "/Assets/package_migration_icon.png" });
            taskList.Add(new ListViewValue { id = 5, name = "VAS", image = "/Assets/vas_icon.png" });
            taskList.Add(new ListViewValue { id = 6, name = "Customer Services", image = "/Assets/customar_care_icon.png" });
            taskList.Add(new ListViewValue { id = 7, name = "Others", image = "/Assets/contact_icon.png" });

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
                case 1:
                    this.Hide();
                    VoicePackageDialog voicePackageDialog = new VoicePackageDialog();
                    voicePackageDialog.data = data;
                    await voicePackageDialog.ShowAsync();
                    break;
                case 2:
                    this.Hide();
                    InternetPackageDialog internetPackageDialog = new InternetPackageDialog();
                    internetPackageDialog.data = data;
                    await internetPackageDialog.ShowAsync();
                    break;
                case 3:
                    this.Hide();
                    FnfDialog fnfDialog = new FnfDialog();
                    await fnfDialog.ShowAsync();
                    break;
                case 4:
                    this.Hide();
                    rootFrame.Navigate(typeof(PackageMigrationPage), data);
                    break;
                case 5:
                    this.Hide();
                    rootFrame.Navigate(typeof(VasPage), data);
                    break;
                case 6:
                    this.Hide();
                    rootFrame.Navigate(typeof(CustomerServicePage), data);
                    break;
                case 7:
                    this.Hide();
                    rootFrame.Navigate(typeof(UsefullContactPage), data);
                    break;
                default:
                    break;
            }
        }
    }
}
