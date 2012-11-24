using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;
using Android.Util;

namespace PaintOnCanvas
{
    class Circle : DrawableObject
    {
        string tag = "PaintOnCanvas.Circle";
        
        public float Radius { get; set; }

        public override void Draw(Canvas canvas, Paint paint)
        {
            paint.Color = Color;
            canvas.DrawCircle(X, Y, Radius, paint);
        }

        internal override bool Collision(float x, float y)
        {
            var dx = X - x;
            var x2 = dx * dx;
            var dy = Y - y;
            var y2 = dy * dy;
            var r2 = Radius * Radius;
            Log.Debug(tag, "{0} + {1} =? {2}", x2, y2, r2);
            return r2 >= (x2 + y2);
        }
    }

}
