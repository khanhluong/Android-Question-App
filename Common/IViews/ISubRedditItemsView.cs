﻿using System;
using System.Collections.Generic;
using Android_Question_App.Model;
using Common.Model;

namespace Common.IViews
{
    public interface ISubRedditItemsView: IBaseView
    {
        void GotoSubReditItemDetailView(List<Child> listSubRedditChildren);
        void LoadingSubRedditError(String err);
    }
}
