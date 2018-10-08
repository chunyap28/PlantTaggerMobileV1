using Android.Content;
using PlantTaggerV1.Views;
using PlantTaggerV1.Droid;
using SlideOverKit.Droid;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(MainPage), typeof(RightSideMenuRenderer))]
namespace PlantTaggerV1.Droid
{
    public class RightSideMenuRenderer : PageRenderer, ISlideOverKitPageRendererDroid
    {
        public Action<ElementChangedEventArgs<Page>> OnElementChangedEvent { get; set; }

        public Action<bool, int, int, int, int> OnLayoutEvent { get; set; }

        public Action<int, int, int, int> OnSizeChangedEvent { get; set; }

        public RightSideMenuRenderer(Context context) : base(context)
        {
            new SlideOverKitDroidHandler().Init(this, context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);
            if (OnElementChangedEvent != null)
                OnElementChangedEvent(e);
        }

        protected override void OnLayout(bool changed, int l, int t, int r, int b)
        {
            base.OnLayout(changed, l, t, r, b);
            if (OnLayoutEvent != null)
                OnLayoutEvent(changed, l, t, r, b);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            if (OnSizeChangedEvent != null)
                OnSizeChangedEvent(w, h, oldw, oldh);
        }
    }
}