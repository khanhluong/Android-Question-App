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
using Common.IViews;
using Common.Presenters;

namespace Android_Question_App
{
    [Activity(Label = "SidebarActivity")]
    public class SidebarActivity : AppCompatActivity, ISubRedditItemDetailView
    {
        public const string SIDEBAR_URL = "sidebarHtml";
        private WebView mSiteBarWebView;
        private SubRedditItemDetailViewPresenter mSubRedditItemDetailViewPresenter;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_sidebar);

            mSubRedditItemDetailViewPresenter = new SubRedditItemDetailViewPresenter(this);
            mSiteBarWebView = (WebView) FindViewById(Resource.Id.webViewSiteBar);
            var sidebarHtml = Intent.Extras.GetString(SIDEBAR_URL);
            mSubRedditItemDetailViewPresenter.HandleLoadingSideBar(sidebarHtml);
        }


        /*
         * Handle webview goback when user press back button
         */
        public override void OnBackPressed()
        {
            if (mSiteBarWebView.Visibility == ViewStates.Visible)
            {
                if (mSiteBarWebView.CanGoBack())
                {
                    mSiteBarWebView.GoBack();
                }
                else
                {
                    base.OnBackPressed();
                }
                return;
            }
            else
            {
                base.OnBackPressed();
            }
        }

        public void LoadingSiteBar(string url)
        {
            mSiteBarWebView.Settings.JavaScriptEnabled = true;
            mSiteBarWebView.Settings.UserAgentString = "Mozilla/5.0 (Linux; Android 4.4; Nexus 5 Build/_BuildID_) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36";
            mSiteBarWebView.SetWebViewClient(new SubRedditWebViewClient());
            mSiteBarWebView.SetWebChromeClient(new WebChromeClient());
            mSiteBarWebView.LoadUrl(url);
        }
    }
}