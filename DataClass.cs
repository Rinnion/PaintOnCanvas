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
        private static List<DrawableObject> lstObjects;
        
        public static List<DrawableObject> Drawables { get { return lstObjects; } private set { } }

        static DataClass()
        {
            lstObjects = new List<DrawableObject>()
                {
                    new Circle { X = 100, Y = 100, Radius = 50, Color = Color.Red },
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.Orange},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.Yellow},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.Green},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.LightBlue},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.Blue},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.Purple},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.Lime},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.LightGray},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.LightPink},
                    new Circle { X = 150, Y = 150, Radius = 50, Color = Color.Black}
                };
        }
    }
}