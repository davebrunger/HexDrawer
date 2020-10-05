using System;
using System.Drawing;
using DrawingUtils;
using DrawingUtils.TuckBoxes;

namespace TuckBoxDrawer
{
    public class TuckBoxPixelDimensions : ITuckBoxPixelDimensions
    {
        public float HeightInPixels { get; }

        public float WidthInPixels { get; }

        public float XDepthInPixels { get; }

        public float YDepthInPixels { get; }

        public float YTabInPixels { get; }

        public float XTabInPixels { get; }

        public float XMarginInPixels { get; }

        public float YMarginInPixels { get; }

        public float XCornerInPixels { get; }

        public float YCornerInPixels { get; }

        public TuckBoxPixelDimensions(float heightInInches, float widthInInches, float depthInInches,
            float xMarginInInches, float yMarginInInches, float tabAsFractionOfDepth, float cornerAsFractionOfTab,
            float dpiX, float dpiY)
        {
            HeightInPixels = heightInInches * dpiY;
            WidthInPixels = widthInInches * dpiX;
            XDepthInPixels = depthInInches * dpiX;
            YDepthInPixels = depthInInches * dpiY;

            XMarginInPixels = xMarginInInches * dpiX;
            YMarginInPixels = yMarginInInches * dpiY;

            var tabInInches = Math.Min(depthInInches, widthInInches / 2) * tabAsFractionOfDepth;

            XTabInPixels = tabInInches * dpiX;
            YTabInPixels = tabInInches * dpiY;
            XCornerInPixels = tabInInches * dpiX * cornerAsFractionOfTab;
            YCornerInPixels = tabInInches * dpiY * cornerAsFractionOfTab;
        }

        public CornersDefinition BuildCornersDefinition(params Corner[] roundedCorners)
        {
            return new CornersDefinition(new SizeF(XCornerInPixels, YCornerInPixels), roundedCorners);
        }
    }
}