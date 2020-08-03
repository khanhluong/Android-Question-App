using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Android_Question_App.Model;
using Common.IViews;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Common.Presenters
{
    public class SubRedditItemsViewPresenter: BaseViewPresenter
    {
        private readonly ISubRedditItemsView subRedditItemsView;


        public SubRedditItemsViewPresenter(ISubRedditItemsView subRedditItemsView)
        {
            this.subRedditItemsView = subRedditItemsView;
        }


        public void LoadSubRedditItem(String searchValue)
        {
            List<SubReddit> listSubReddit = new List<SubReddit>();
            Task.Factory.StartNew(() =>
            {
                var json = new WebClient().DownloadString("http://www.reddit.com/subreddits/search.json?q=" + searchValue);
                var subreddits = JsonConvert.DeserializeObject<JObject>(json);
                foreach (var subreddit in subreddits["data"]["children"] as JArray)
                {
                    var name = subreddit["data"]["display_name_prefixed"].ToString();
                    SubReddit subReddit = new SubReddit(name);
                    listSubReddit.Add(subReddit);
                }

            }).ContinueWith(task =>
            {
                subRedditItemsView.GotoSubReditItemDetailView(listSubReddit);
            }, TaskScheduler.FromCurrentSynchronizationContext());
            
        }
    }

}
