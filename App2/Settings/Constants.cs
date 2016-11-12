using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2.Settings
{
    public static class Constants
    {
        public const string SenderID = "SenderID"; // Google API Project Number
        public const string ListenConnectionString = "Endpoint=sb://xamathondemo.servicebus.windows.net/;SharedAccessKeyName=DefaultListenSharedAccessSignature;SharedAccessKey=WriteKey=";
        public const string NotificationHubName = "Xamathon";
    }
}