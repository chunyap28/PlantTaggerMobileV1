using Android.Graphics;
using PlantTaggerV1.Droid.CustomRenderers;
using PlantTaggerV1.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
 
[assembly: ExportRenderer(typeof(FontAwesomeLabel), typeof(FontAwesomeLabelRenderer))]

namespace PlantTaggerV1.Droid.CustomRenderers
{
#pragma warning disable CS0618 // Type or member is obsolete
    public class FontAwesomeLabelRenderer : LabelRenderer
#pragma warning restore CS0618 // Type or member is obsolete
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Typeface = Typeface.CreateFromAsset(Forms.Context.Assets,
                    FontAwesomeLabel.FontAwesomeName + ".otf");
            }
        }
    }
}
