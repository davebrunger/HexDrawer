using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace TuckBoxDrawer
{
    public partial class MainForm : Form
    {
        private const float OneInchInCms = 2.54f;

        private const float HeightInCms = 9.6f;
        private const float WidthInCms = 6.8f;
        private const float DepthInCms = 5.0f;

        private const float HeightInInches = HeightInCms / OneInchInCms;
        private const float WidthInInches = WidthInCms / OneInchInCms;
        private const float DepthInInches = DepthInCms / OneInchInCms;

        private const float TabAsFractionOfDepth = 0.9f;
        private const float CornerAsFractionOfTab = 0.5f;

        private const float MarginInInches = 0.5f;

        private int nextPage = 1;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            DisplayPanel.Invalidate();
        }

        private static void DrawTop(Graphics graphics, Pen pen, TuckBoxPixelDimensions pixelDimensions)
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels;
            var tabTop = pixelDimensions.YMarginInPixels;
            var boxTop = tabTop + pixelDimensions.YTabInPixels;
            DrawRectangle(graphics, pen, left, tabTop, pixelDimensions.WidthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.TopLeft, Corner.TopRight));
            DrawRectangle(graphics, pen, left, boxTop, pixelDimensions.WidthInPixels, pixelDimensions.YDepthInPixels);
        }

        private static void DrawLeftSide(Graphics graphics, Pen pen, TuckBoxPixelDimensions pixelDimensions)
        {
            var left = pixelDimensions.XMarginInPixels;
            var topTabTop = pixelDimensions.YMarginInPixels + pixelDimensions.YDepthInPixels;
            var boxTop = topTabTop + pixelDimensions.YTabInPixels;
            var bottomTabTop = boxTop + pixelDimensions.HeightInPixels;
            DrawRectangle(graphics, pen, left, topTabTop, pixelDimensions.XDepthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.TopLeft));
            DrawRectangle(graphics, pen, left, boxTop, pixelDimensions.XDepthInPixels, pixelDimensions.HeightInPixels);
            DrawRectangle(graphics, pen, left, bottomTabTop, pixelDimensions.XDepthInPixels,
                pixelDimensions.YTabInPixels, pixelDimensions.BuildCornersDefinition(Corner.BottomLeft));
        }

        private static void DrawFront(Graphics graphics, Pen pen, TuckBoxPixelDimensions pixelDimensions)
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels;
            var top = pixelDimensions.YMarginInPixels + pixelDimensions.YTabInPixels + pixelDimensions.XDepthInPixels;
            DrawRectangle(graphics, pen, left, top, pixelDimensions.WidthInPixels, pixelDimensions.HeightInPixels);
        }

        private static void DrawBottom(Graphics graphics, Pen pen, TuckBoxPixelDimensions pixelDimensions)
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels;
            var boxTop = pixelDimensions.YMarginInPixels + pixelDimensions.YTabInPixels +
                         pixelDimensions.XDepthInPixels + pixelDimensions.HeightInPixels;
            var tabTop = boxTop + pixelDimensions.YDepthInPixels;
            DrawRectangle(graphics, pen, left, boxTop, pixelDimensions.WidthInPixels, pixelDimensions.YDepthInPixels);
            DrawRectangle(graphics, pen, left, tabTop, pixelDimensions.WidthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.BottomLeft, Corner.BottomRight));
        }

        private static void DrawRightSide(Graphics graphics, Pen pen, TuckBoxPixelDimensions pixelDimensions)
        {
            var left = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels + pixelDimensions.WidthInPixels;
            var topTabTop = pixelDimensions.YMarginInPixels + pixelDimensions.YDepthInPixels;
            var boxTop = topTabTop + pixelDimensions.YTabInPixels;
            var bottomTabTop = boxTop + pixelDimensions.HeightInPixels;
            DrawRectangle(graphics, pen, left, topTabTop, pixelDimensions.XDepthInPixels, pixelDimensions.YTabInPixels,
                pixelDimensions.BuildCornersDefinition(Corner.TopRight));
            DrawRectangle(graphics, pen, left, boxTop, pixelDimensions.XDepthInPixels, pixelDimensions.HeightInPixels);
            DrawRectangle(graphics, pen, left, bottomTabTop, pixelDimensions.XDepthInPixels,
                pixelDimensions.YTabInPixels, pixelDimensions.BuildCornersDefinition(Corner.BottomRight));
        }

        private static void DrawBack(Graphics graphics, Pen pen, TuckBoxPixelDimensions pixelDimensions)
        {
            var boxLeft = pixelDimensions.XMarginInPixels + pixelDimensions.XDepthInPixels +
                          pixelDimensions.WidthInPixels + pixelDimensions.XDepthInPixels;
            var tabLeft = boxLeft + pixelDimensions.WidthInPixels;
            var top = pixelDimensions.YMarginInPixels + pixelDimensions.YTabInPixels + pixelDimensions.XDepthInPixels;
            DrawBackPanel(graphics, pen, boxLeft, top, pixelDimensions.WidthInPixels, pixelDimensions.HeightInPixels,
                pixelDimensions.XCornerInPixels, pixelDimensions.YCornerInPixels);
            DrawRectangle(graphics, pen, tabLeft, top, pixelDimensions.XTabInPixels, pixelDimensions.HeightInPixels);
        }

        private static void DrawBackOnly(Graphics graphics, Pen pen, TuckBoxPixelDimensions pixelDimensions)
        {
            var leftTabLeft = pixelDimensions.XMarginInPixels;
            var boxLeft = leftTabLeft + pixelDimensions.XTabInPixels;
            var rightTabLeft = boxLeft + pixelDimensions.WidthInPixels;
            var top = pixelDimensions.YMarginInPixels;
            DrawRectangle(graphics, pen, leftTabLeft, top, pixelDimensions.XTabInPixels,
                pixelDimensions.HeightInPixels);
            DrawBackPanel(graphics, pen, boxLeft, top, pixelDimensions.WidthInPixels, pixelDimensions.HeightInPixels,
                pixelDimensions.XCornerInPixels, pixelDimensions.YCornerInPixels);
            DrawRectangle(graphics, pen, rightTabLeft, top, pixelDimensions.XTabInPixels,
                pixelDimensions.HeightInPixels);
        }

        public static void DrawRectangle(Graphics graphics, Pen pen, float x, float y, float width, float height,
            CornersDefinition corners = null)
        {
            // ReSharper disable once ConvertIfStatementToNullCoalescingAssignment
            if (corners == null)
            {
                corners = CornersDefinition.Default;
            }

            var path = RoundedRect(new RectangleF(x, y, width, height), corners);
            graphics.DrawPath(pen, path);
        }

        public static GraphicsPath RoundedRect(RectangleF bounds, CornersDefinition corners)
        {
            var diameterX = corners.RadiusX * 2;
            var diameterY = corners.RadiusY * 2;
            var size = new SizeF(diameterX, diameterY);
            var path = new GraphicsPath();

            if (corners.RoundedCorners.Contains(Corner.TopLeft))
            {
                var arc = new RectangleF(bounds.Location, size);
                path.AddArc(arc, 180, 90);
            }
            else
            {
                path.AddLine(bounds.Location, bounds.Location);
            }

            if (corners.RoundedCorners.Contains(Corner.TopRight))
            {
                var arc = new RectangleF(new PointF(bounds.Right - diameterX, bounds.Top), size);
                path.AddArc(arc, 270, 90);
            }
            else
            {
                var point = new PointF(bounds.Right, bounds.Top);
                path.AddLine(point, point);
            }

            if (corners.RoundedCorners.Contains(Corner.BottomRight))
            {
                var arc = new RectangleF(new PointF(bounds.Right - diameterX, bounds.Bottom - diameterY), size);
                path.AddArc(arc, 0, 90);
            }
            else
            {
                var point = new PointF(bounds.Right, bounds.Bottom);
                path.AddLine(point, point);
            }

            if (corners.RoundedCorners.Contains(Corner.BottomLeft))
            {
                var arc = new RectangleF(new PointF(bounds.Left, bounds.Bottom - diameterY), size);
                path.AddArc(arc, 90, 90);
            }
            else
            {
                var point = new PointF(bounds.Left, bounds.Bottom);
                path.AddLine(point, point);
            }

            path.CloseFigure();
            return path;
        }

        public static void DrawBackPanel(Graphics graphics, Pen pen, float x, float y, float width, float height,
            float radiusX, float radiusY)
        {
            var path = BackPanel(new RectangleF(x, y, width, height), radiusX, radiusY);
            graphics.DrawPath(pen, path);
        }

        public static GraphicsPath BackPanel(RectangleF bounds, float radiusX, float radiusY)
        {
            var diameterX = radiusX * 2;
            var diameterY = radiusY * 2;
            var size = new SizeF(diameterX, diameterY);
            var path = new GraphicsPath();

            path.AddLine(bounds.Location, bounds.Location);
            var topRight = new PointF(bounds.Right, bounds.Top);

            var centre = bounds.Left + bounds.Width / 2;

            var arc = new RectangleF(new PointF(centre - radiusX, bounds.Top - radiusY), size);
            path.AddArc(arc, 180, -180);

            path.AddLine(topRight, topRight);
            var bottomRight = new PointF(bounds.Right, bounds.Bottom);
            path.AddLine(bottomRight, bottomRight);
            var bottomLeft = new PointF(bounds.Left, bounds.Bottom);
            path.AddLine(bottomLeft, bottomLeft);

            path.CloseFigure();
            return path;
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);
            DrawTuckBox(e.Graphics, e.Graphics.DpiX, e.Graphics.DpiY);
        }

        private static void DrawTuckBoxFront(Graphics graphics, float dpiX, float dpiY)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            var pen = Pens.Black;

            var tabInInches = Math.Min(DepthInInches, WidthInInches / 2) * TabAsFractionOfDepth;

            var pixelDimensions = new TuckBoxPixelDimensions
            {
                HeightInPixels = HeightInInches * dpiY,
                WidthInPixels = WidthInInches * dpiX,
                XDepthInPixels = DepthInInches * dpiX,
                YDepthInPixels = DepthInInches * dpiY,

                XMarginInPixels = MarginInInches * dpiX,
                YMarginInPixels = MarginInInches * dpiY,

                XTabInPixels = tabInInches * dpiX,
                YTabInPixels = tabInInches * dpiY,
                XCornerInPixels = tabInInches * dpiX * CornerAsFractionOfTab,
                YCornerInPixels = tabInInches * dpiY * CornerAsFractionOfTab,
            };


            DrawTop(graphics, pen, pixelDimensions);
            DrawLeftSide(graphics, pen, pixelDimensions);
            DrawFront(graphics, pen, pixelDimensions);
            DrawBottom(graphics, pen, pixelDimensions);
            DrawRightSide(graphics, pen, pixelDimensions);
        }

        private static void DrawTuckBoxBack(Graphics graphics, float dpiX, float dpiY)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;

            var pen = Pens.Black;

            var tabInInches = Math.Min(DepthInInches, WidthInInches / 2) * TabAsFractionOfDepth;

            var pixelDimensions = new TuckBoxPixelDimensions
            {
                HeightInPixels = HeightInInches * dpiY,
                WidthInPixels = WidthInInches * dpiX,
                XDepthInPixels = DepthInInches * dpiX,
                YDepthInPixels = DepthInInches * dpiY,

                XMarginInPixels = MarginInInches * dpiX,
                YMarginInPixels = MarginInInches * dpiY,

                XTabInPixels = tabInInches * dpiX,
                YTabInPixels = tabInInches * dpiY,
                XCornerInPixels = tabInInches * dpiX * CornerAsFractionOfTab,
                YCornerInPixels = tabInInches * dpiY * CornerAsFractionOfTab,
            };

            DrawBackOnly(graphics, pen, pixelDimensions);
        }

        private static void DrawTuckBox(Graphics graphics, float dpiX, float dpiY)
        {
            DrawTuckBoxFront(graphics, dpiX, dpiY);

            graphics.SmoothingMode = SmoothingMode.HighQuality;

            var pen = Pens.Black;

            var tabInInches = Math.Min(DepthInInches, WidthInInches / 2) * TabAsFractionOfDepth;

            var pixelDimensions = new TuckBoxPixelDimensions
            {
                HeightInPixels = HeightInInches * dpiY,
                WidthInPixels = WidthInInches * dpiX,
                XDepthInPixels = DepthInInches * dpiX,
                YDepthInPixels = DepthInInches * dpiY,

                XMarginInPixels = MarginInInches * dpiX,
                YMarginInPixels = MarginInInches * dpiY,

                XTabInPixels = tabInInches * dpiX,
                YTabInPixels = tabInInches * dpiY,
                XCornerInPixels = tabInInches * dpiX * CornerAsFractionOfTab,
                YCornerInPixels = tabInInches * dpiY * CornerAsFractionOfTab,
            };

            DrawBack(graphics, pen, pixelDimensions);
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            switch (nextPage)
            {
                case 1:
                    DrawTuckBoxFront(e.Graphics, 100, 100);
                    break;
                case 2:
                    DrawTuckBoxBack(e.Graphics, 100, 100);
                    break;
            }

            nextPage += 1;
            if (nextPage == 3)
            {
                e.HasMorePages = false;
                nextPage = 1;
            }
            else
            {
                e.HasMorePages = true;
            }
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (PrintDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument.Print();
            }
        }
    }
}
