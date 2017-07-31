using Android.App;
using Android.Widget;
using Android.OS;
using Android.Webkit;
using Android.Views;
using System.Net;
using Plugin.Connectivity;
using Com.Tapadoo.Alerter;
using Android.Support.V7.App;
using Android.Graphics;

namespace WebsiteWrapperApp
{
    [Activity(Label = "WebsiteWrapperApp", MainLauncher = true, Icon = "@drawable/AppIcon", Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class MainActivity : AppCompatActivity, Android.Views.View.IOnClickListener
    {
        private WebView myWebView;
        private LinearLayout noInternetMessage;
        private bool needsReload = false;
        private bool initialNotConnected = false;
        public static TextView loading;

        protected override void OnCreate(Bundle bundle)
        {
            
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            noInternetMessage = FindViewById<LinearLayout>(Resource.Id.NoInternetDisplay);
            loading = FindViewById<TextView>(Resource.Id.textView4);

            //Sets up WebView
            myWebView = FindViewById<WebView>(Resource.Id.webView);
            myWebView.SetWebViewClient(new HelloWebViewClient());
            myWebView.Settings.JavaScriptEnabled = true;
            myWebView.LoadUrl("http://www.bing.com/ ");

            //Sets initial screen based on connectivity
            if (CheckInternetConnection() == true)
            {
                if (needsReload)
                {
                    myWebView.Visibility = ViewStates.Visible;
                    noInternetMessage.Visibility = ViewStates.Gone;
                    needsReload = false;
                }
            }
            else
            {
                myWebView.Visibility = ViewStates.Gone;
                noInternetMessage.Visibility = ViewStates.Visible;
                needsReload = true;
                initialNotConnected = true;
            }
            CrossConnectivity.Current.ConnectivityTypeChanged += Current_ConnectivityTypeChanged;
        }

        //Responds to a change in network connection
        private void Current_ConnectivityTypeChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityTypeChangedEventArgs e)
        {
            CheckDisplayForInternet();
        }

        //Toggles the visiblilty of the loading bar to visible
        public static void ShowLoadingBar()
        {
            if (loading.Visibility == ViewStates.Gone)
            {
                loading.Visibility = ViewStates.Visible;
            }
        }

        //Toggles the visiblilty of the loading bar to invisible
        public static void HideLoadingBar()
        {
            if (loading.Visibility == ViewStates.Visible)
            {
                loading.Visibility = ViewStates.Gone;
            }
        }

        //Sends notifications on internet connectivity if network changes
        public void CheckDisplayForInternet()
        {
            if (CheckInternetConnection() == true)
            {
                if (needsReload)
                {
                    if (initialNotConnected)
                    {
                        myWebView.Visibility = ViewStates.Visible;
                        noInternetMessage.Visibility = ViewStates.Gone;
                    }

                    Alerter.Create(this).SetTitle("Connected")
                    .SetText("You are now connected to the internet.")
                    .SetIcon(Resource.Drawable.wifiTower)
                    .SetBackgroundColor(Resource.Color.background_material_dark)
                    .Show();

                    myWebView.Reload();
                    needsReload = false;
                }
            }
            else
            {
                Alerter.Create(this).SetTitle("Not Connected")
                .SetText("Please connect to the internet.")
                .SetIcon(Resource.Drawable.wifiTower)
                .SetBackgroundColor(Resource.Color.background_material_dark)
                .Show();
                needsReload = true;
            }

        }

        //Sends a quick request to google to test if connected to the internet
        public bool CheckInternetConnection()
        {
            string CheckUrl = "http://google.com";

            try
            {
                HttpWebRequest iNetRequest = (HttpWebRequest)WebRequest.Create(CheckUrl);
                iNetRequest.Timeout = 10000;
                WebResponse iNetResponse = iNetRequest.GetResponse();
                iNetResponse.Close();
                return true;
            }
            catch (WebException ex)
            {
                return false;
            }
        }

        //Operates the back button in WebView
        public override bool OnKeyDown(Keycode keyCode, KeyEvent e)
        {
            if (keyCode == Keycode.Back && myWebView.CanGoBack())
            {
                myWebView.GoBack();
                return true;
            }
            return base.OnKeyDown(keyCode, e);
        }

        public void OnClick(View v) { }
    }

    //Needed for WebView
    public class HelloWebViewClient : WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }

        public override void OnPageStarted(WebView view, string url, Bitmap favicon)
        {
            MainActivity.ShowLoadingBar();
        }

        public override void OnPageFinished(WebView view, string url)
        {
            MainActivity.HideLoadingBar();
        }
    }
}

