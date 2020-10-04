using System.Collections.Generic;

namespace DrawingUtils.TuckBoxes
{
    public class TuckBox
    {
        private readonly ITuckBoxPixelDimensions pixelDimensions;

        public TuckBox(ITuckBoxPixelDimensions pixelDimensions)
        {
            this.pixelDimensions = pixelDimensions;
        }

        private IEnumerable<RectangleDefinition> GetTop()
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels;
            var tabTop = pixelDimensions.YMarginInPixels;
            var boxTop = tabTop + pixelDimensions.YTabInPixels;
            yield return new RectangleDefinition(left, tabTop, pixelDimensions.WidthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.TopLeft, Corner.TopRight));
            yield return new RectangleDefinition(left, boxTop, pixelDimensions.WidthInPixels, pixelDimensions.YDepthInPixels);
        }

        private IEnumerable<RectangleDefinition> GetLeftSide()
        {
            var left = pixelDimensions.XMarginInPixels;
            var topTabTop = pixelDimensions.YMarginInPixels + pixelDimensions.YDepthInPixels;
            var boxTop = topTabTop + pixelDimensions.YTabInPixels;
            var bottomTabTop = boxTop + pixelDimensions.HeightInPixels;
            yield return new RectangleDefinition(left, topTabTop, pixelDimensions.XDepthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.TopLeft));
            yield return new RectangleDefinition(left, boxTop, pixelDimensions.XDepthInPixels, pixelDimensions.HeightInPixels);
            yield return new RectangleDefinition(left, bottomTabTop, pixelDimensions.XDepthInPixels,
                pixelDimensions.YTabInPixels, pixelDimensions.BuildCornersDefinition(Corner.BottomLeft));
        }

        private IEnumerable<RectangleDefinition> GetFront()
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels;
            var top = pixelDimensions.YMarginInPixels + pixelDimensions.YTabInPixels + pixelDimensions.XDepthInPixels;
            yield return new RectangleDefinition(left, top, pixelDimensions.WidthInPixels, pixelDimensions.HeightInPixels);
        }

        private IEnumerable<RectangleDefinition> GetBottom()
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels;
            var boxTop = pixelDimensions.YMarginInPixels + pixelDimensions.YTabInPixels +
                         pixelDimensions.XDepthInPixels + pixelDimensions.HeightInPixels;
            var tabTop = boxTop + pixelDimensions.YDepthInPixels;
            yield return new RectangleDefinition(left, boxTop, pixelDimensions.WidthInPixels, pixelDimensions.YDepthInPixels);
            yield return new RectangleDefinition(left, tabTop, pixelDimensions.WidthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.BottomLeft, Corner.BottomRight));
        }

        private IEnumerable<RectangleDefinition> GetRightSide()
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels + pixelDimensions.WidthInPixels;
            var topTabTop = pixelDimensions.YMarginInPixels + pixelDimensions.YDepthInPixels;
            var boxTop = topTabTop + pixelDimensions.YTabInPixels;
            var bottomTabTop = boxTop + pixelDimensions.HeightInPixels;
            yield return new RectangleDefinition(left, topTabTop, pixelDimensions.XDepthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.TopRight));
            yield return new RectangleDefinition(left, boxTop, pixelDimensions.XDepthInPixels, pixelDimensions.HeightInPixels);
            yield return new RectangleDefinition(left, bottomTabTop, pixelDimensions.XDepthInPixels,
                pixelDimensions.YTabInPixels, pixelDimensions.BuildCornersDefinition(Corner.BottomRight));
        }

        public IEnumerable<RectangleDefinition> GetAttachedBack()
        {
            var boxLeft = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels +
                          pixelDimensions.WidthInPixels + pixelDimensions.XDepthInPixels;
            var tabLeft = boxLeft + pixelDimensions.WidthInPixels;
            var top = pixelDimensions.YMarginInPixels + pixelDimensions.YTabInPixels + pixelDimensions.XDepthInPixels;
            yield return new RectangleDefinition(boxLeft, top, pixelDimensions.WidthInPixels, pixelDimensions.HeightInPixels,
                pixelDimensions.BuildCornersDefinition(), true);
            yield return new RectangleDefinition(tabLeft, top, pixelDimensions.XTabInPixels, pixelDimensions.HeightInPixels);
        }

        public IEnumerable<RectangleDefinition> GetSeparateBack()
        {
            var leftTabLeft = pixelDimensions.XMarginInPixels;
            var boxLeft = leftTabLeft + pixelDimensions.XTabInPixels;
            var rightTabLeft = boxLeft + pixelDimensions.WidthInPixels;
            var top = pixelDimensions.YMarginInPixels;
            yield return new RectangleDefinition(leftTabLeft, top, pixelDimensions.XTabInPixels,
                pixelDimensions.HeightInPixels);
            yield return new RectangleDefinition(boxLeft, top, pixelDimensions.WidthInPixels, pixelDimensions.HeightInPixels,
                pixelDimensions.BuildCornersDefinition(), true);
            yield return new RectangleDefinition(rightTabLeft, top, pixelDimensions.XTabInPixels,
                pixelDimensions.HeightInPixels);
        }

        public IEnumerable<RectangleDefinition> GetFrontAndSides()
        {
            var rectangles = new List<RectangleDefinition>();
            rectangles.AddRange(GetTop());
            rectangles.AddRange(GetLeftSide());
            rectangles.AddRange(GetFront());
            rectangles.AddRange(GetBottom());
            rectangles.AddRange(GetRightSide());
            return rectangles;
        }
    }
}
