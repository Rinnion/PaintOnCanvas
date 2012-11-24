using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;

namespace PaintOnCanvas
{
    class Circle : DrawableObject
    {
        public float Radius { get; set; }

        public override void Draw(Canvas canvas, Paint paint)
        {
            paint.Color = Color;
            canvas.DrawCircle(X, Y, Radius, paint);
        }
    }

}
