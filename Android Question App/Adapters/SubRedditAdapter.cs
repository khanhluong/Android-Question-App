using System;
using System.Collections.Generic;
using System.Net;
using Android.Content;
using Android.Graphics;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android_Question_App.Model;
using Com.Nostra13.Universalimageloader.Core;
using Common.Model;
using Common.Presenters;

namespace Android_Question_App.Adapters
{
    public class SubRedditAdapter : RecyclerView.Adapter
    {

        public event EventHandler ItemClick;
        private readonly SubRedditItemDetailViewPresenter viewModel;
        private OnItemClickListener onItemClickListener;

        List<Child> mListSubRedditChildren;
        ImageLoader imageLoader;

        public SubRedditAdapter(Context context, List<Child> mListSubRedditChildren, OnItemClickListener onItemClickListener)
        {
            this.mListSubRedditChildren = mListSubRedditChildren;
            this.onItemClickListener = onItemClickListener;
            ImageLoader.Instance.Init(ImageLoaderConfiguration.CreateDefault(context));
        }

        public override int ItemCount => mListSubRedditChildren.Count;

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            SubRedditViewHolder vh = holder as SubRedditViewHolder;
            vh.Name.Text = mListSubRedditChildren[position].data.display_name_prefixed;

            String imageSubRedditUrl = mListSubRedditChildren[position].data.icon_img;
            if (!String.IsNullOrEmpty(imageSubRedditUrl))
            {
                imageLoader = ImageLoader.Instance;
                imageLoader.DisplayImage(imageSubRedditUrl, vh.ImageViewSubReddit);
            }

            vh.ItemView.Click+= (sender, e) => onClickListener(position, mListSubRedditChildren[position].data.display_name_prefixed);
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

        public Bitmap GetImageBitmapFromUrl(string url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }


    }


    public class SubRedditViewHolder : RecyclerView.ViewHolder
    {
        public TextView Name { get; private set; }
        public ImageView ImageViewSubReddit { get; private set; }
        public new View ItemView { get; private set; }

        public SubRedditViewHolder(View itemView) : base(itemView)
        {
            Name = itemView.FindViewById<TextView>(Resource.Id.TvSubRedditName);
            ImageViewSubReddit = itemView.FindViewById<ImageView>(Resource.Id.imvSubReddit);
            ItemView = itemView;

        }





    }


}
