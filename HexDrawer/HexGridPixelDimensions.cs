using System;
using DrawingUtils.Grids;

namespace HexDrawer
{
    public class HexGridPixelDimensions : IGridPixelDimensions
    {
        public float GridHeightInPixels { get; }

        public float GridWidthInPixels { get; }

        public float PolygonHeightInPixels { get; }

        public float PolygonWidthInPixels { get; }

        public float XMarginInPixels { get; }

        public float YMarginInPixels { get; }

        public HexGridPixelDimensions(float xMarginInInches, float yMarginInInches, float widthInInches,
            float heightInInches, int polygonsPerInch, float dpiX, float dpiY)
        {
            XMarginInPixels = xMarginInInches * dpiX;
            YMarginInPixels = yMarginInInches * dpiY;
            GridWidthInPixels = widthInInches * dpiX;
            GridHeightInPixels = heightInInches * dpiY;

            var hexHeightInches = 1.0f / polygonsPerInch;
            var halfHexHeightInches = hexHeightInches / 2;
            PolygonHeightInPixels = hexHeightInches * dpiY;

            var halfHexSideInches = (float) (halfHexHeightInches * Math.Tan(Math.PI / 6));
            PolygonWidthInPixels = halfHexSideInches * dpiX * 2;
        }
    }
}
