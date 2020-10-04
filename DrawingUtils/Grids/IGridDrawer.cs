using System;
using System.Drawing;

namespace DrawingUtils.Grids
{
    public interface IGridDrawer
    {
        GridType GridType { get; }

        Color Colour { get; }

        float PolygonsPerInch { get; }

        float MarginInInches { get; }

        void DrawGrid(float widthInInches, float heightInInches, float dpiX, float dpiY, float hardXMarginInches,
            float hardYMarginInches, Action<float, float, float, float> drawLine);
    }
}