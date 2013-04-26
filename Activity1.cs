using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using Android.Util;
using System.Collections.Generic;
using System.Text;
using Android.Net.Wifi.P2p;

namespace PaintOnCanvas
{
    [Activity( Label = "PaintOnCanvas", 
               MainLauncher = true, 
               Icon = "@drawable/icon", 
               Theme = "@android:style/Theme.NoTitleBar",
               ConfigurationChanges = Android.Content.PM.ConfigChanges.Orientation)]
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(new SampleView(this));
        }

    }
}

