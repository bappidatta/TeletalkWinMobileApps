﻿

#pragma checksum "E:\Development\Project\SampleApps\SampleApps\Pages\VoicePackagePage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "06DBA91F63CC8C05F8B4D1A0728634E8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SampleApps.Pages
{
    partial class VoicePackagePage : global::Windows.UI.Xaml.Controls.Page, global::Windows.UI.Xaml.Markup.IComponentConnector
    {
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 4.0.0.0")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
 
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 1:
                #line 32 "..\..\Pages\VoicePackagePage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgBack_Tapped;
                 #line default
                 #line hidden
                break;
            case 2:
                #line 37 "..\..\Pages\VoicePackagePage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgHome_Tapped;
                 #line default
                 #line hidden
                break;
            case 3:
                #line 224 "..\..\Pages\VoicePackagePage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgTeletalk_Tapped;
                 #line default
                 #line hidden
                break;
            case 4:
                #line 228 "..\..\Pages\VoicePackagePage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgFacebook_Tapped;
                 #line default
                 #line hidden
                break;
            case 5:
                #line 231 "..\..\Pages\VoicePackagePage.xaml"
                ((global::Windows.UI.Xaml.UIElement)(target)).Tapped += this.imgYoutube_Tapped;
                 #line default
                 #line hidden
                break;
            case 6:
                #line 66 "..\..\Pages\VoicePackagePage.xaml"
                ((global::Windows.UI.Xaml.FrameworkElement)(target)).Loaded += this.voicePackageListView_Loaded;
                 #line default
                 #line hidden
                break;
            case 7:
                #line 207 "..\..\Pages\VoicePackagePage.xaml"
                ((global::Windows.UI.Xaml.Controls.Primitives.ButtonBase)(target)).Click += this.btnSend_Click;
                 #line default
                 #line hidden
                break;
            }
            this._contentLoaded = true;
        }
    }
}


