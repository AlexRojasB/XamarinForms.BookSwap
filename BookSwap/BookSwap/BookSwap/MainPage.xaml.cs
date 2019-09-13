using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFUtils.Effects;

namespace BookSwap
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        SKPaint _accentPaint;
        SKPaint _accentDarkPaint;
        SKPaint _accentExtraDarkPaint;
        SKColor _accentColor;
        SKColor _accentDarkColor;
        SKColor _accentExtraDarkColor;
        public MainPage()
        {
            InitializeComponent();
            Color color = Color.FromHex("#FFF571");
            _accentColor = color.ToSKColor();
            _accentDarkColor = color.WithLuminosity(color.Luminosity - .07).ToSKColor();
            _accentExtraDarkColor = color.WithLuminosity(color.Luminosity - .15).ToSKColor();
            _accentPaint = new SKPaint() { Color = _accentColor  };
            _accentDarkPaint = new SKPaint() { Color = _accentDarkColor  };
            _accentExtraDarkPaint = new SKPaint() { Color = _accentExtraDarkColor};

            var eff = new ScrollReporterEffect();
            eff.ScrollChanged += Eff_ScrollChanged;
            BooksListView.Effects.Add(eff);
        }

        private void Eff_ScrollChanged(object sender, ScrollEventArgs arg)
        {
            Debug.WriteLine($"Scroll position {arg.Y}");
            MessagingCenter.Send(new ScrollMessage(), ScrollMessage.ScrollChanged, arg.Y);
        }

        private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Forms.SKPaintSurfaceEventArgs e)
        {
            SKImageInfo info = e.Info;
            SKSurface surface = e.Surface;
            SKCanvas canvas = surface.Canvas;

            canvas.Clear();
            canvas.DrawRect(info.Rect, _accentPaint);
            using(SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * 0.7f, 0);
                path.LineTo(info.Width * .2f, info.Height);
                path.LineTo(0, info.Height);
                path.Close();
                canvas.DrawPath(path, _accentDarkPaint);

            }

            using (SKPath path = new SKPath())
            {
                path.MoveTo(0, 0);
                path.LineTo(info.Width * 0.33f, 0);
                path.LineTo(0, info.Height * .6f);
                path.Close();
                canvas.DrawPath(path, _accentExtraDarkPaint);

            }
        }
    }
}
