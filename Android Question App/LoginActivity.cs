using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Views.InputMethods;
using Android.Widget;
using Android_Question_App.Adapters;
using Android_Question_App.Model;
using Common.IViews;
using Common.Presenters;


namespace Android_Question_App
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class LoginActivity : AppCompatActivity, ISubRedditItemsView, OnItemClickListener
    {
        private RecyclerView mRecyclerViewSubReddit;
        private SubRedditAdapter mSubRedditAdapter;
        private RecyclerView.LayoutManager mLayoutManager;
        private Android.Support.V7.Widget.Toolbar mToolbar;
        private SubRedditItemsViewPresenter mSubRedditItemsViewPresenter;
        private TextInputEditText mTextInputEditTextSearch;
        private Android.Support.V7.Widget.SearchView mSearchViewRedditKeyword;


        [Obsolete]
        private ProgressDialog mProgressDialog;

        [Obsolete]
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            mToolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(mToolbar);
            mRecyclerViewSubReddit = FindViewById<RecyclerView>(Resource.Id.rvSubReddit);
            mTextInputEditTextSearch = FindViewById<TextInputEditText>(Resource.Id.textInput1);
            //mSearchViewRedditKeyword = FindViewById<Android.Support.V7.Widget.SearchView>(Resource.Id.sVSubRedditKeyword); 


            mSubRedditItemsViewPresenter = new SubRedditItemsViewPresenter(this);

            mProgressDialog = new ProgressDialog(this);
            mProgressDialog.SetMessage("Contacting server. Please wait...");
            mProgressDialog.SetCancelable(true);


            //init adapter
            mLayoutManager = new LinearLayoutManager(this);
            mRecyclerViewSubReddit.SetLayoutManager(mLayoutManager);

            Button searchButton = FindViewById<Button>(Resource.Id.search_button);
            searchButton.Click += SearchButton_Click;

        }

        [Obsolete]
        private void SearchButton_Click(object sender, EventArgs e)
        {
            string keyword = mTextInputEditTextSearch.Text;

            if (String.IsNullOrEmpty(keyword))
            {
                Toast.MakeText(this, "Please input value", ToastLength.Long).Show();
            }
            else
            {
                mProgressDialog.Show();
                mSubRedditItemsViewPresenter.LoadSubRedditItem(keyword);
            }
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        [Obsolete]
        public void GotoSubReditItemDetailView(List<SubReddit> listSubReddit)
        {
            mSubRedditAdapter = new SubRedditAdapter(listSubReddit, this);
            mRecyclerViewSubReddit.SetAdapter(mSubRedditAdapter);
            // hide keyboard

            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(mTextInputEditTextSearch.WindowToken, 0);
            mProgressDialog.Dismiss();
        }

        public void OnItemClick(int position, string redditSubName)
        {
            var sidebarHtml = "https://www.reddit.com/" + redditSubName + "/about/sidebar";

            Log.Debug("sidebarHtml", "sidebarHtml " + sidebarHtml);

            var intent = new Intent(this, typeof(SidebarActivity));
            intent.PutExtra("sidebarHtml", sidebarHtml);
            this.StartActivity(intent);
        }

    }
}
