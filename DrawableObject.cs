using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;

namespace PaintOnCanvas
{
    abstract class DrawableObject
    {
        public abstract void Draw(Canvas canvas, Paint paint);
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }

        protected bool mVisible = false;
        public bool Visible { get { return mVisible; } set { mVisible = value; } }
    }

    class Square : DrawableObject
    {
        public float Width { get; set; }

        public override void Draw(Canvas canvas, Paint paint)
        {
            paint.Color = Color;
            canvas.DrawRect(X - Width / 2, Y - Width / 2, X + Width / 2, Y + Width / 2, paint);
        }
    }


}
