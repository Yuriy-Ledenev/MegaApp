using System;
using System.Collections.Generic;
using System.Text;
using Android.Widget;
namespace MegaApp
{
    internal static class Message
    {
        public static void ShowShort(string message) => Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        public static void ShowLong(string message) => Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
    }
}
