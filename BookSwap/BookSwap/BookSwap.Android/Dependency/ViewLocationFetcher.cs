using System.Drawing;
using BookSwap.Droid.Dependency;
using BookSwap.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly:Dependency(typeof(ViewLocationFetcher))]
namespace BookSwap.Droid.Dependency
{
    public class ViewLocationFetcher : IViewLocationFetcher
    {
        public PointF GetCoordinates(VisualElement view)
        {
            var renderer = Platform.GetRenderer(view);
            var nativeView = renderer.View;
            var location = new int[2];
            var density = (float)Xamarin.Essentials.DeviceDisplay.MainDisplayInfo.Density;

            nativeView.GetLocationOnScreen(location);
            return new PointF(location[0] / density, location[1] / density);
        }
    }
}