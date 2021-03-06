﻿using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

        public void DrawPaths(IEnumerable<Path> paths)
        {
            foreach (var path in paths)
            {
                var graphicsPath = new GraphicsPath();

                foreach (var pathSection in path.Segments)
                {
                    pathSection.Switch(
                        p => graphicsPath.AddLine(p, p),
                        l => graphicsPath.AddLine(l.FromPoint, l.ToPoint),
                        a => graphicsPath.AddArc(a.BoundingEllipse, a.StartAngle, a.SweepAngle));
                }

                if (path.Closed || path.Image != null)
                {
                    graphicsPath.CloseFigure();
                }

                if (path.Image != null)
                {
                    var bitmap = new Bitmap(path.Image.Data);
                    var brush = new TextureBrush(bitmap, WrapMode.Clamp);
                    brush.ScaleTransform(path.Image.Rectangle.Width / bitmap.Width, path.Image.Rectangle.Height / bitmap.Height);
                    brush.TranslateTransform(path.Image.Rectangle.Left, path.Image.Rectangle.Top, MatrixOrder.Append);

                    graphics.FillPath(brush, graphicsPath);
                }

                graphics.DrawPath(pen, graphicsPath);
            }
        }

        public void DrawPaths(params Path[] paths)
        {
            DrawPaths(paths.AsEnumerable());
        }
    }
}
