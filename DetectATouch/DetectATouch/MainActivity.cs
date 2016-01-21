using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace DetectATouch
{
    [Activity(Label = "DetectATouch", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity, View.IOnTouchListener
    {
        private Button _myButton;
        private float _viewX;

        public bool OnTouch(View v, MotionEvent e)
        {
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    _viewX = e.GetX();
                    break;
                case MotionEventActions.Move:
                    var left = (int)(e.RawX - _viewX);
                    var right = (int)(left + v.Width);
                    v.Layout(left, v.Top, right, v.Bottom);
                    break;
            }
            return true;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            _myButton = FindViewById<Button>(Resource.Id.myView);
            _myButton.SetOnTouchListener(this);
        }
    }
}

