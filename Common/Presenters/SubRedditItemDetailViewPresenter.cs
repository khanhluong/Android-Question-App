using System;
using System.Collections.ObjectModel;
using Common.IViews;

namespace Common.Presenters
{
    public class SubRedditItemDetailViewPresenter
    {

        ISubRedditItemDetailView subRedditItemDetailView;

        public SubRedditItemDetailViewPresenter(ISubRedditItemDetailView subRedditItemDetailView)
        {
            this.subRedditItemDetailView = subRedditItemDetailView;
        }

        public void HandleLoadingSideBar(string url)
        {
            subRedditItemDetailView.LoadingSiteBar(url);
        }


    }
}
