﻿

#pragma checksum "D:\Development\Practice\SampleApps\SampleApps\MainPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "A45962076BABD426E4CFBBD5DC792447"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleApps
{
    partial class MainPage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 9 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.Page_Loaded;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 36 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgMenu_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 76 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgTeletalk_Tapped;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 80 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgFacebook_Tapped;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 84 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgYoutube_Tapped;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 44 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.menuListView_Loaded;
                 #line default
                 #line hidden
                #line 46 "..\..\MainPage.xaml"
                ((global::Windows.UI.Xaml.Controls.ListViewBase)(target)).ItemClick += this.menuListView_ItemClick;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}

