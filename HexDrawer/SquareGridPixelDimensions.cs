using System;
using DrawingUtils.Grids;

namespace HexDrawer
{
    public class SquareGridPixelDimensions : IGridPixelDimensions
    {
        public float GridHeightInPixels { get; }

        public float GridWidthInPixels { get; }

        public float PolygonHeightInPixels { get; }

        public float PolygonWidthInPixels { get; }

        public float XMarginInPixels { get; }

        public float YMarginInPixels { get; }

        public SquareGridPixelDimensions(float xMarginInInches, float yMarginInInches, float widthInInches,
            float heightInInches, int polygonsPerInch, float dpiX, float dpiY)
        {
            XMarginInPixels = xMarginInInches * dpiX;
            YMarginInPixels = yMarginInInches * dpiY;
            GridWidthInPixels = widthInInches * dpiX;
            GridHeightInPixels = heightInInches * dpiY;

            var squareHeightInches = 1.0f / polygonsPerInch;

            PolygonWidthInPixels = squareHeightInches * dpiX;
            PolygonHeightInPixels = squareHeightInches * dpiY;
        }
    }
}
