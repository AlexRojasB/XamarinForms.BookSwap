using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace BookSwap.Interfaces
{
    public interface IViewLocationFetcher
    {
        PointF GetCoordinates(global::Xamarin.Forms.VisualElement view);
    }
}
