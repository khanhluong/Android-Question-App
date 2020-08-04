using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Android.Util;
using Android_Question_App.Model;
using Common.Interface;
using Common.IViews;
using Common.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Refit;

namespace Common.Presenters
{
    public class SubRedditItemsViewPresenter: BaseViewPresenter
    {
        private readonly ISubRedditItemsView subRedditItemsView;
        IRedditApi redditApi;


        public SubRedditItemsViewPresenter(ISubRedditItemsView subRedditItemsView)
        {
            this.subRedditItemsView = subRedditItemsView;
            redditApi = RestService.For<IRedditApi>("https://reddit.com");
        }


        //public void LoadSubRedditItem(String searchValue)
        //{
        //    List<SubReddit> listSubReddit = new List<SubReddit>();
        //    Task.Factory.StartNew(() =>
        //    {
        //        var json = new WebClient().DownloadString("http://www.reddit.com/subreddits/search.json?q=" + searchValue);
        //        var subreddits = JsonConvert.DeserializeObject<JObject>(json);
        //        foreach (var subreddit in subreddits["data"]["children"] as JArray)
        //        {
        //            var name = subreddit["data"]["display_name_prefixed"].ToString();
        //            var imgName = subreddit["data"]["icon_img"].ToString();
        //            SubReddit subReddit = new SubReddit(name, imgName);
        //            listSubReddit.Add(subReddit);
        //        }

        //    }).ContinueWith(task =>
        //    {
        //        subRedditItemsView.GotoSubReditItemDetailView(listSubReddit);
        //    }, TaskScheduler.FromCurrentSynchronizationContext());
            
        //}


        /**
         * Using refit to call api and load data to view
         * @searchValue: user input value
         */
        public async void LoadSubRedditItem2Async(String searchValue)
        {

            try
            {
                SubRedditResponse subRedditResponse = await redditApi.GetSubReddit(searchValue);
                Log.Debug("SubRedditResponse", subRedditResponse.datas.children[0].data.icon_img);
                List<Child> listSubRedditChildren = subRedditResponse.datas.children;

                //display
                subRedditItemsView.GotoSubReditItemDetailView(listSubRedditChildren);

            }
            catch (Exception ex)
            {
                Log.Debug("SubRedditResponse ex ", ex.Message);
            }

        }
    }

}
