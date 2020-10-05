using System.Drawing;
using System.Drawing.Drawing2D;
using DrawingUtils;

namespace FrameworkDrawingUtils
{
    public class PathDrawer
    {
        private readonly Graphics graphics;

        private readonly Pen pen;

        public PathDrawer(Graphics graphics, Pen pen)
        {
            this.graphics = graphics;
            this.pen = pen;
        }

        public void DrawPath(Path path)
        {
            var graphicsPath = new GraphicsPath();

            foreach (var pathSection in path.Segments)
            {
                pathSection.Switch(
                    p => graphicsPath.AddLine(p, p),
                    l => graphicsPath.AddLine(l.FromPoint, l.ToPoint),
                    a => graphicsPath.AddArc(a.BoundingEllipse, a.StartAngle, a.SweepAngle));
            }

            if (path.Closed)
            {
                graphicsPath.CloseFigure();
            }

            graphics.DrawPath(pen, graphicsPath);

        }
    }
}
