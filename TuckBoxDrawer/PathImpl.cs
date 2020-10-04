using System.Drawing;
using System.Drawing.Drawing2D;
using DrawingUtils;

namespace TuckBoxDrawer
{
    public class PathImpl : IPath
    {
        private readonly Graphics graphics;
        private readonly GraphicsPath path;
        private readonly Pen pen;

        private PathImpl(Graphics graphics, GraphicsPath path, Pen pen)
        {
            this.graphics = graphics;
            this.path = path;
            this.pen = pen;
        }

        public PathImpl(Graphics graphics, Pen pen) : this(graphics, new GraphicsPath(), pen)
        {
        }

        public IPath AddArc(RectangleF boundingEllipse, float startAngle, float sweepAngle)
        {
            path.AddArc(boundingEllipse, startAngle, sweepAngle);
            return new PathImpl(graphics, path, pen);
        }

        public IPath AddPoint(PointF point)
        {
            path.AddLine(point, point);
            return new PathImpl(graphics, path, pen);
        }

        public void Draw()
        {
            path.CloseFigure();
            graphics.DrawPath(pen, path);
        }
    }
}