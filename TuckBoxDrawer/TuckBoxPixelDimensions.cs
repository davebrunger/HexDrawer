namespace TuckBoxDrawer
{
    public class TuckBoxPixelDimensions
    {
        public float HeightInPixels { get; set; }

        public float WidthInPixels { get; set; }

        public float XDepthInPixels { get; set; }

        public float YDepthInPixels { get; set; }

        public float YTabInPixels { get; set; }

        public float XTabInPixels { get; set; }

        public float XMarginInPixels { get; set; }

        public float YMarginInPixels { get; set; }

        public float XCornerInPixels { get; set; }

        public float YCornerInPixels { get; set; }

        public CornersDefinition BuildCornersDefinition(params Corner[] roundedCorners)
        {
            return new CornersDefinition()
            {
                RadiusX = XCornerInPixels,
                RadiusY = YCornerInPixels,
                RoundedCorners = roundedCorners
            };
        }
    }
}