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

namespace PaintOnCanvas
{
    [Activity(Label = "PaintOnCanvas", MainLauncher = true, Icon = "@drawable/icon", Theme = "@android:style/Theme.NoTitleBar")]    
    public class Activity1 : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Create your application here
            SetContentView(new SampleView(this));
        }

        private class SampleView : View
        {
            private string tag = "PaintOnCanvas.SampleView";


            Dictionary<int, DrawableObject> dctObjects = new Dictionary<int, DrawableObject>();
            
            private Paint mPaint;
            private Bitmap mBmp;
            private Canvas canvasBitmap;
            private Circle mCircle;
            private int Width;
            private int Height;

            public SampleView(Context context)
                : base(context)
            {
                Log.Debug(tag, "Start view");
                Focusable = true;

                //foreach (var item in DataClass.Drawables) 
                //    item.Visible = false;

                mPaint = new Paint();
                mPaint.AntiAlias = true;

                IWindowManager wm = context.GetSystemService(WindowService).JavaCast<IWindowManager>();
                Display dsp = wm.DefaultDisplay;
                Width = dsp.Width;
                Height = dsp.Height;

                mBmp = Bitmap.CreateBitmap(Width, Height, Bitmap.Config.Argb8888);
                canvasBitmap = new Canvas(mBmp);
                canvasBitmap.DrawColor(Color.Black);

                Log.Debug(tag, String.Format("Client W:{0}, H:{1}", Width, Height));
            }

            protected override void OnDraw(Canvas canvas)
            {
                canvas.DrawColor(Color.Black);
                canvas.SaveLayerAlpha(0, 0, Width, Height, 0xFF, SaveFlags.All);

                //canvas.DrawBitmap(mBmp, 0, 0, mPaint);

                foreach (var obj in DataClass.Drawables)
                {                    
                    if (obj.Visible)
                        obj.Draw(canvas, mPaint);
                }

                canvas.Restore();
            }

            private Dictionary<int, DrawableObject> dctControlable = new Dictionary<int, DrawableObject>();

            public override bool OnTouchEvent(MotionEvent e)
            {
                MotionEvent.PointerCoords mepc = new MotionEvent.PointerCoords();

                int iEventPointerIndex = (int)(e.Action & MotionEventActions.PointerIdMask) >> (int)MotionEventActions.PointerIdShift;
                int iEventPointerId = e.GetPointerId(iEventPointerIndex);
                MotionEventActions action = e.Action & MotionEventActions.Mask;

                switch (action)
                {
                    case MotionEventActions.Down:
                    case MotionEventActions.PointerDown:
                        Log.Debug(tag, String.Format("Point Down"));
                        //DataClass.Drawables[iEventPointerId].Visible = true;
                        e.GetPointerCoords(iEventPointerIndex, mepc);
                        foreach (var item in DataClass.Drawables)
                        {
                            if (item.Collision(mepc.X, mepc.Y))
                            {
                                dctControlable.Add(iEventPointerId, item);
                                break;
                            }
                        }
                        break;
                    case MotionEventActions.Move:
                        var l = new List<string>();
                        for (int iPointerIndex = 0; iPointerIndex < e.PointerCount; iPointerIndex++)
                        {
                            int iPointerId = e.GetPointerId(iPointerIndex);
                            l.Add(String.Format("{0} => {1}", iPointerIndex, iPointerId));
                            try
                            {
                                e.GetPointerCoords(iPointerIndex, mepc);

                                dctControlable[iPointerId].X = mepc.X;
                                dctControlable[iPointerId].Y = mepc.Y;

                            }
                            catch
                            {
                                l.Add(String.Format("ex", iPointerIndex, iPointerId));
                            }
                        }

                        Log.Debug(tag, string.Format("{0}, {1}", iEventPointerIndex, string.Join(", ", l)));
                        break;
                    case MotionEventActions.Up:
                    case MotionEventActions.PointerUp:
                        Log.Debug(tag, String.Format("Point Up"));
                        //DataClass.Drawables[iEventPointerId].Visible = false;
                        dctControlable.Remove(iEventPointerId);
                        break;
                }

                this.Invalidate();
                return true;
            }
        }
    }
}

