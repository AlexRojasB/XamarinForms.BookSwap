using BookSwap.Interfaces;
using BookSwap.iOS.Dependency;
using System.Drawing;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: Dependency(typeof(ViewLocationFetcher))]
namespace BookSwap.iOS.Dependency
{
    public class ViewLocationFetcher : IViewLocationFetcher
    {
        public PointF GetCoordinates(VisualElement view)
        {
            var renderer = Xamarin.Forms.Platform.iOS.Platform.GetRenderer(view);
            var nativeView = renderer.NativeView;

            var rect = nativeView.Superview.ConvertPointToView(nativeView.Frame.Location, null);
            return rect.ToSystemPointF();
        }
    }
}