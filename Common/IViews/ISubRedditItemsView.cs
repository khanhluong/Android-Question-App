using System;
using System.Collections.Generic;
using Android_Question_App.Model;

namespace Common.IViews
{
    public interface ISubRedditItemsView
    {
        void GotoSubReditItemDetailView(List<SubReddit> listSubReddit);
    }
}
