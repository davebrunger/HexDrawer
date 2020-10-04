using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DrawingUtils.TuckBoxes;

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

        private static void DrawRectangles(Graphics graphics, IEnumerable<RectangleDefinition> rectangles, Pen pen)
        {
            foreach (var rectangle in rectangles)
            {
                var path = RectangleDrawer.DrawRectangle(rectangle);
                var graphicsPath = new GraphicsPath();

                foreach (var pathSection in path)
                {
                    pathSection.Switch(
                        p => graphicsPath.AddLine(p, p),
                        a => graphicsPath.AddArc(a.BoundingEllipse, a.StartAngle, a.SweepAngle));
                }

                graphicsPath.CloseFigure();
                graphics.DrawPath(pen, graphicsPath);
            }
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var pixelDimensions = new TuckBoxPixelDimensions(HeightInInches, WidthInInches, DepthInInches,
                MarginInInches, TabAsFractionOfDepth, CornerAsFractionOfTab, e.Graphics.DpiX, e.Graphics.DpiY);

            var tuckBox = new TuckBox(pixelDimensions);

            var rectangles = new List<RectangleDefinition>(tuckBox.GetFrontAndSides());
            rectangles.AddRange(tuckBox.GetAttachedBack());

            var pen = Pens.Black;
            
            DrawRectangles(e.Graphics, rectangles, pen);
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var pixelDimensions = new TuckBoxPixelDimensions(HeightInInches, WidthInInches, DepthInInches,
                MarginInInches, TabAsFractionOfDepth, CornerAsFractionOfTab, 100, 100);

            var tuckBox = new TuckBox(pixelDimensions);
            var rectangles = new List<RectangleDefinition>();

            switch (nextPage)
            {
                case 1:
                    rectangles.AddRange(tuckBox.GetFrontAndSides());
                    break;
                case 2:
                    rectangles.AddRange(tuckBox.GetSeparateBack());
                    break;
            }

            var pen = Pens.Black;

            DrawRectangles(e.Graphics, rectangles, pen);

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
