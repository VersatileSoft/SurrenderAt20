﻿using Android.App;
using Android.Content;
using Android.Net;
using Android.OS;
using Android.Widget;
using LeagueOfNews.Core.Interface;

namespace LeagueOfNews.Forms.Droid.Services
{
    public class InternetConnectionService : IInternetConnectionService
    {
        public bool IsInternetAvailable()
        {
            ConnectivityManager cm = (ConnectivityManager)Application.Context.GetSystemService(Context.ConnectivityService);
            bool isConnected = cm.ActiveNetworkInfo == null ? false : cm.ActiveNetworkInfo.IsConnected;
            if (!isConnected)
            {
                try
                {
                    Looper.Prepare();
                    Toast.MakeText(Application.Context, "No internet connection", ToastLength.Short).Show();
                    Looper.Loop();
                }
                catch { }
            }

            return isConnected;
        }
    }
}