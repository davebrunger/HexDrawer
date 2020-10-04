using System.Collections.Generic;
using System.Drawing;
using PathSection = OneOf.OneOf<System.Drawing.PointF, DrawingUtils.TuckBoxes.Arc>;

namespace DrawingUtils.TuckBoxes
{
    public static class RectangleDrawer
    {
        private static PathSection Arc(float left, float top, SizeF size, int startAngle, int sweepAngle)
        {
            return PathSection.FromT1(new Arc(new RectangleF(new PointF(left, top), size), startAngle, sweepAngle));
        }

        private static PathSection Point(float left, float top)
        {
            return PathSection.FromT0(new PointF(left, top));
        }

        public static IEnumerable<PathSection> DrawRectangle(RectangleDefinition rectangle)
        {
            var diameterX = rectangle.Corners.Radius.Width * 2;
            var diameterY = rectangle.Corners.Radius.Height * 2;
            var size = new SizeF(diameterX, diameterY);

            if (rectangle.Corners.RoundedCorners.Contains(Corner.TopLeft))
            {
                yield return Arc(rectangle.Rectangle.Left, rectangle.Rectangle.Top, size, 180, 90);
            }
            else
            {
                yield return Point(rectangle.Rectangle.Left, rectangle.Rectangle.Top);
            }

            if (rectangle.Cutout)
            {
                var centre = rectangle.Rectangle.Left + rectangle.Rectangle.Width / 2;
                yield return Arc(centre - rectangle.Corners.Radius.Width,
                    rectangle.Rectangle.Top - rectangle.Corners.Radius.Height, size, 180, -180);
            }

            if (rectangle.Corners.RoundedCorners.Contains(Corner.TopRight))
            {
                yield return Arc(rectangle.Rectangle.Right - diameterX, rectangle.Rectangle.Top, size, 270, 90);
            }
            else
            {
                yield return Point(rectangle.Rectangle.Right, rectangle.Rectangle.Top);
            }

            if (rectangle.Corners.RoundedCorners.Contains(Corner.BottomRight))
            {
                yield return Arc(rectangle.Rectangle.Right - diameterX, rectangle.Rectangle.Bottom - diameterY, size, 0, 90);
            }
            else
            {
                yield return Point(rectangle.Rectangle.Right, rectangle.Rectangle.Bottom);
            }

            if (rectangle.Corners.RoundedCorners.Contains(Corner.BottomLeft))
            {
                yield return Arc(rectangle.Rectangle.Left, rectangle.Rectangle.Bottom - diameterY, size, 90, 90);
            }
            else
            {
                yield return Point(rectangle.Rectangle.Left, rectangle.Rectangle.Bottom);
            }
        }
    }
}
