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
using Android.Graphics;

namespace PaintOnCanvas
{
    class DataClass
    {
        private static List<DrawableObject> lstSources;
        private static List<DrawableObject> lstDrawables;

        public static List<DrawableObject> Sources { get { return lstSources; } private set { } }
        public static List<DrawableObject> Drawables { get { return lstDrawables; } private set { } }

        static DataClass()
        {
            lstSources = new List<DrawableObject>()
                {
                    new Circle { X =  50, Y = 50, Radius = 50, Visible = true, Color = Color.Red },
                    new Circle { X = 150, Y = 50, Radius = 50, Visible = true, Color = Color.Orange},
                    new Circle { X = 250, Y = 50, Radius = 50, Visible = true, Color = Color.Yellow},
                    new Circle { X = 350, Y = 50, Radius = 50, Visible = true, Color = Color.Green},
                    new Circle { X = 450, Y = 50, Radius = 50, Visible = true, Color = Color.LightBlue},
                    new Circle { X = 550, Y = 50, Radius = 50, Visible = true, Color = Color.Blue},
                    new Circle { X = 650, Y = 50, Radius = 50, Visible = true, Color = Color.Purple},
                    new Circle { X = 750, Y = 50, Radius = 50, Visible = true, Color = Color.Lime},
                    new Circle { X = 850, Y = 50, Radius = 50, Visible = true, Color = Color.LightGray},
                    new Circle { X = 950, Y = 50, Radius = 50, Visible = true, Color = Color.LightPink}
                };

            lstDrawables = new List<DrawableObject>()
                {
                };
        }

    }
}