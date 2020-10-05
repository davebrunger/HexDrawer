using System.Drawing;
using System.IO;

namespace DrawingUtils.TuckBoxes
{
    public class RectangleDefinition
    {
        public CornersDefinition Corners { get; }

        public RectangleF Rectangle { get; }

        public bool Cutout { get; }

        public Stream Image { get; }

        public RectangleDefinition(RectangleF rectangle, CornersDefinition corners = null, Stream image = null, bool cutout = false)
        {
            Corners = corners ?? CornersDefinition.Default;
            Rectangle = rectangle;
            Cutout = cutout;
            Image = image;
        }

        public RectangleDefinition(float left, float top, float width, float height, CornersDefinition corners = null,
            Stream image = null, bool cutout = false) : this(new RectangleF(left, top, width, height), corners, image, cutout)
        {
        }

        public Path GetPath()
        {
            var diameterX = Corners.Radius.Width * 2;
            var diameterY = Corners.Radius.Height * 2;

            var size = new SizeF(diameterX, diameterY);

            var path = new Path(true);

            if (Image != null)
            {
                path = path.AddImage(Image, Rectangle);
            }

            path = Corners.RoundedCorners.Contains(Corner.TopLeft)
                ? path.AddArc(Rectangle.Location, size, 180, 90)
                : path.AddPoint(Rectangle.Location);

            if (Cutout)
            {
                path = path.AddArc(
                    Rectangle.Left + Rectangle.Width / 2 - Corners.Radius.Width, Rectangle.Top - Corners.Radius.Height,
                    diameterX, diameterY, 180, -180);
            }

            path = Corners.RoundedCorners.Contains(Corner.TopRight)
                ? path.AddArc(
                    Rectangle.Right - diameterX, Rectangle.Top, diameterX, diameterY, 270, 90)
                : path.AddPoint(Rectangle.Right, Rectangle.Top);

            path = Corners.RoundedCorners.Contains(Corner.BottomRight)
                ? path.AddArc(Rectangle.Right - diameterX, Rectangle.Bottom - diameterY, diameterX, diameterY, 0, 90)
                : path.AddPoint(Rectangle.Right, Rectangle.Bottom);

            path = Corners.RoundedCorners.Contains(Corner.BottomLeft)
                ? path.AddArc(Rectangle.Left, Rectangle.Bottom - diameterY, diameterX, diameterY, 90, 90)
                : path.AddPoint(Rectangle.Left, Rectangle.Bottom);

            return path;
        }
    }
}
