using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AppShopping.Helpers.Connect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

[assembly: Dependency(typeof(AppShopping.Droid.Libraries.Helpers.Connect.WifiConnector))]
namespace AppShopping.Droid.Libraries.Helpers.Connect
{
    public class WifiConnector : IWifiConnector
    {
        public void ConnectToWifi(string ssid, string password)
        {
            throw new NotImplementedException();
        }
    }
}