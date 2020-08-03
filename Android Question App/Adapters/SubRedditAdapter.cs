using System;
using System.Collections.Generic;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android_Question_App.Model;
using Common.Presenters;

namespace Android_Question_App.Adapters
{
    public class SubRedditAdapter : RecyclerView.Adapter
    {

        public event EventHandler ItemClick;
        private readonly SubRedditItemDetailViewPresenter viewModel;
        private OnItemClickListener onItemClickListener;

        List<SubReddit> mListSubReddit;

        public SubRedditAdapter(List<SubReddit> mListSubReddit, OnItemClickListener onItemClickListener)
        {
            this.mListSubReddit = mListSubReddit;
            this.onItemClickListener = onItemClickListener;
        }

        public override int ItemCount => mListSubReddit.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            SubRedditViewHolder vh = holder as SubRedditViewHolder;
            vh.Name.Text = mListSubReddit[position].Name;
            vh.Name.Click += (sender, e) => onClickListener(position, mListSubReddit[position].Name);
        }

        private void onClickListener(int position, string redditSubName)
        {
            onItemClickListener.OnItemClick(position, redditSubName);
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            View itemView = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.reddit_item, parent, false);

            SubRedditViewHolder subRedditViewHolder = new SubRedditViewHolder(itemView);

            return subRedditViewHolder;
        }
    }


    public class SubRedditViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public ImageView ImageViewSubReddit { get; private set; }

        public SubRedditViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.TvSubRedditName);
            //ImageViewSubReddit = itemView.FindViewById<ImageView>(Resource.Id.ImvSubReddit);

        }

        
    }
}
