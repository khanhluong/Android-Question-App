using System;
using Android.Webkit;

namespace Android_Question_App
{
    public class SubRedditWebViewClient: WebViewClient
    {
        // For API level 24 and later
        public override bool ShouldOverrideUrlLoading(WebView view, IWebResourceRequest request)
        {
            view.LoadUrl(request.Url.ToString());
            return false;
        }
    }
}
