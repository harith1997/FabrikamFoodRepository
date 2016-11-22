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
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using FabrikamFood.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(NativeAndroidMaps))]
namespace FabrikamFood.Droid
{
   
    public class NativeAndroidMaps : INativeAndroidMaps
    {
        public void startGoogleMaps()
        {
            var intent = new Intent(Forms.Context, typeof(GoogleMapsActivity));
            Forms.Context.StartActivity(intent);
        }
    }
}