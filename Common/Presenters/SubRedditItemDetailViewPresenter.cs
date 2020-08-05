using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Common.IViews;

namespace Common.Presenters
{
    public class SubRedditItemDetailViewPresenter: BaseViewPresenter<ISubRedditItemDetailView>
    {

        ISubRedditItemDetailView subRedditItemDetailView;

        public SubRedditItemDetailViewPresenter(ISubRedditItemDetailView subRedditItemDetailView): base(subRedditItemDetailView)
        {
            this.subRedditItemDetailView = subRedditItemDetailView;
        }

        public void HandleLoadingSideBar(string url)
        {
            subRedditItemDetailView.LoadingSiteBar(url);
        }

        public override void Init()
        {
           
        }
    }
}
