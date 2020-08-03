using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Webkit;
using Android.Widget;

namespace Android_Question_App
{
    [Activity(Label = "SidebarActivity")]
    public class SidebarActivity : AppCompatActivity
    {
        private WebView mSiteBarWebView;
        private Android.Support.V7.Widget.Toolbar mToolbar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_sidebar);

            mSiteBarWebView = (WebView) FindViewById(Resource.Id.webViewSiteBar);
            mSiteBarWebView.Settings.JavaScriptEnabled = true;
            mSiteBarWebView.Settings.UserAgentString = "Mozilla/5.0 (Linux; Android 4.4; Nexus 5 Build/_BuildID_) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36";
           
            var sidebarHtml = Intent.Extras.GetString("sidebarHtml");
            mSiteBarWebView.SetWebViewClient(new SubRedditWebViewClient());
            mSiteBarWebView.SetWebChromeClient(new WebChromeClient());
            //mSiteBarWebView.LoadData(sidebarHtml, "text/html", "utf-8");
            mSiteBarWebView.LoadUrl(sidebarHtml);
        }
    }
}