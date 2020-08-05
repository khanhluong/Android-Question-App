using System;
namespace Common.IViews
{
    public interface ISubRedditItemDetailView: IBaseView
    {
        void LoadingSiteBar(string url);
    }
}
