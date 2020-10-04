using System.Drawing;

namespace DrawingUtils
{
    public class RectangleDefinition
    {
        public CornersDefinition Corners { get; }

        public RectangleF Rectangle { get; }

        public bool Cutout { get; }

        public RectangleDefinition(RectangleF rectangle, CornersDefinition corners = null, bool cutout = false)
        {
            Corners = corners ?? CornersDefinition.Default;
            Rectangle = rectangle;
            Cutout = cutout;
        }
        public RectangleDefinition(float left, float top, float width, float height, CornersDefinition corners = null,
            bool cutout = false) : this(new RectangleF(left, top, width, height), corners, cutout)
        {
        }
    }
}
