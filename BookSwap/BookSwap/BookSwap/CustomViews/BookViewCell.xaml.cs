using BookSwap.Interfaces;
using BookSwap.Models;
using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BookSwap.CustomViews
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookViewCell : ViewCell
    {
        SKPaint _accentPaint;
        SKPaint _accentDarkPaint;
        SKPaint _accentExtraDarkPaint;
        SKColor _accentColor;
        SKColor _accentDarkColor;
        SKColor _accentExtraDarkColor;
        double _scrollValue;
        IViewLocationFetcher _viewLocatorService;
        public BookViewCell()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<ScrollMessage, double>(this, ScrollMessage.ScrollChanged, (sender, scrollInfo) =>
            {
                _scrollValue = scrollInfo;
                if (CellBackgroundCanvas != null)
                {
                    CellBackgroundCanvas.InvalidateSurface();
                }
            });
            _viewLocatorService = DependencyService.Get<IViewLocationFetcher>();

        }

        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            if (this.BindingContext != null)
            {
                Color color = Color.FromHex(((Book)BindingContext).AccentColor);
                _accentColor = color.ToSKColor();
                _accentDarkColor = color.WithLuminosity(color.Luminosity - .07).ToSKColor();
                _accentExtraDarkColor = color.WithLuminosity(color.Luminosity - .15).ToSKColor();
                _accentPaint = new SKPaint() { Color = _accentColor };
                _accentDarkPaint = new SKPaint() { Color = _accentDarkColor };
                _accentExtraDarkPaint = new SKPaint() { Color = _accentExtraDarkColor };
            }
        }

        private void CellBackgroundCanvas_PaintSurface(object sender, SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();

            var thisCellPosition = _viewLocatorService.GetCoordinates(this.View);

            canvas.DrawRect(info.Rect, _accentPaint);
            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width - thisCellPosition.Y, 0);
                //path.LineTo(info.Width * .2f, info.Height);
                path.LineTo(0, info.Height *.8f);
                path.Close();
                canvas.DrawPath(path, _accentDarkPaint);

            }

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width - (thisCellPosition.Y * 2), 0);
                path.LineTo(0, info.Height * .6f);
                path.Close();
                canvas.DrawPath(path, _accentExtraDarkPaint);

            }
        }
    }
}