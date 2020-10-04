using System;
using System.Drawing;

namespace DrawingUtils
{
    public interface ITuckBoxPixelDimensions
    {
        float HeightInPixels { get; }

        float WidthInPixels { get; }

        float XDepthInPixels { get; }

        float YDepthInPixels { get; }

        float YTabInPixels { get; }

        float XTabInPixels { get; }

        float XMarginInPixels { get; }

        float YMarginInPixels { get; }

        float XCornerInPixels { get; }

        float YCornerInPixels { get; }

        CornersDefinition BuildCornersDefinition(params Corner[] roundedCorners);
    }
}