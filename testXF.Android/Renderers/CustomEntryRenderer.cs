using Xamarin.Forms;
using Android.Content;
using Android.Graphics;
using Android.Content.Res;
using Android.Support.V4.Content;
using Android.Graphics.Drawables;
using Xamarin.Forms.Platform.Android;
using testXF.Custom;
using testXF.Droid.Renderers;
using testXF.Controls;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Entry), typeof(CustomEntryRenderer), new[] { typeof(CustomVisual) })]

namespace testXF.Droid.Renderers
{

    public class CustomEntryRenderer : EntryRenderer
    {
        public CustomEntryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                Control.SetBackground(null);
            }
        }
    }
}