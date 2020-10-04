using System;
using System.Drawing;

namespace DrawingUtils
{
    public class RectangleDrawer
    {
        private readonly Func<IPath> pathFactory;

        public RectangleDrawer(Func<IPath> pathFactory)
        {
            this.pathFactory = pathFactory;
        }

        public void DrawRectangle(RectangleDefinition rectangle)
        {
            var diameterX = rectangle.Corners.Radius.Width * 2;
            var diameterY = rectangle.Corners.Radius.Height * 2;
            var size = new SizeF(diameterX, diameterY);
            var path = pathFactory();

            path = rectangle.Corners.RoundedCorners.Contains(Corner.TopLeft)
                ? path.AddArc(new RectangleF(rectangle.Rectangle.Location, size), 180, 90)
                : path.AddPoint(rectangle.Rectangle.Location);

            if (rectangle.Cutout)
            {
                var centre = rectangle.Rectangle.Left + rectangle.Rectangle.Width / 2;
                var arc = new RectangleF(
                    new PointF(centre - rectangle.Corners.Radius.Width, rectangle.Rectangle.Top - rectangle.Corners.Radius.Height), size);
                path = path.AddArc(arc, 180, -180);
            }

            path = rectangle.Corners.RoundedCorners.Contains(Corner.TopRight)
                ? path.AddArc(new RectangleF(new PointF(rectangle.Rectangle.Right - diameterX, rectangle.Rectangle.Top), size), 270, 90)
                : path.AddPoint(new PointF(rectangle.Rectangle.Right, rectangle.Rectangle.Top));

            path = rectangle.Corners.RoundedCorners.Contains(Corner.BottomRight)
                ? path.AddArc(
                    new RectangleF(new PointF(rectangle.Rectangle.Right - diameterX, rectangle.Rectangle.Bottom - diameterY), size), 0, 90)
                : path.AddPoint(new PointF(rectangle.Rectangle.Right, rectangle.Rectangle.Bottom));

            path = rectangle.Corners.RoundedCorners.Contains(Corner.BottomLeft)
                ? path.AddArc(new RectangleF(new PointF(rectangle.Rectangle.Left, rectangle.Rectangle.Bottom - diameterY), size), 90, 90)
                : path.AddPoint(new PointF(rectangle.Rectangle.Left, rectangle.Rectangle.Bottom));

            path.Draw();
        }
    }
}
