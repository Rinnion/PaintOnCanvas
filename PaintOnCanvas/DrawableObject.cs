using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.Graphics;

namespace PaintOnCanvas
{
    public interface IDrawableObject
    {
        void Draw(Canvas canvas, Paint paint);
        float X{get;set;}
        float Y{get;set;}
        Color Color{get;set;}
        bool Visible{get;set;}
        bool Collision(float x, float y);
    }
    
    abstract class DrawableObject:IDrawableObject
    {
        public abstract void Draw(Canvas canvas, Paint paint);
        public float X { get; set; }
        public float Y { get; set; }
        public Color Color { get; set; }

        protected bool mVisible = false;
        public bool Visible { get { return mVisible; } set { mVisible = value; } }

        public abstract bool Collision(float x, float y);

        public DrawableObject(){}
        public DrawableObject(DrawableObject original)
        {
            X=original.X;
            Y=original.Y;
            Color=original.Color; 
            mVisible=Visible;
        }
    }

    class Square : DrawableObject
    {
        public float Width { get; set; }

        public override void Draw(Canvas canvas, Paint paint)
        {
            paint.Color = Color;
            canvas.DrawRect(X - Width / 2, Y - Width / 2, X + Width / 2, Y + Width / 2, paint);
        }

        public override bool Collision(float x, float y)
        {
            throw new NotImplementedException();
        }
    }


}
