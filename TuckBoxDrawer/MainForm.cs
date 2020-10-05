using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DrawingUtils;
using DrawingUtils.TuckBoxes;
using FrameworkDrawingUtils;

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

        private static void DrawPaths(Graphics graphics, IEnumerable<Path> paths, Pen pen)
        {
            var pathDrawer = new PathDrawer(graphics, pen);

            foreach (var path in paths)
            {
                pathDrawer.DrawPaths(path);
            }
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var pixelDimensions = new TuckBoxPixelDimensions(HeightInInches, WidthInInches, DepthInInches,
                MarginInInches, MarginInInches, TabAsFractionOfDepth, CornerAsFractionOfTab, e.Graphics.DpiX,
                e.Graphics.DpiY);

            using (var image = GetType().Assembly.GetManifestResourceStream("TuckBoxDrawer.Images.GreenGoblin.png"))
            {
                var tuckBox = new TuckBox(pixelDimensions, image);

                var paths = new List<Path>(tuckBox.GetFrontAndSides());
                paths.AddRange(tuckBox.GetAttachedBack());

                var pen = Pens.Black;

                DrawPaths(e.Graphics, paths, pen);
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var xMarginInInches = Math.Max(MarginInInches, e.PageSettings.HardMarginX / 100f);
            var yMarginInInches = Math.Max(MarginInInches, e.PageSettings.HardMarginY / 100f);

            var pixelDimensions = new TuckBoxPixelDimensions(HeightInInches, WidthInInches, DepthInInches,
                xMarginInInches, yMarginInInches, TabAsFractionOfDepth, CornerAsFractionOfTab, 100, 100);

            using (var image = GetType().Assembly.GetManifestResourceStream("TuckBoxDrawer.Images.GreenGoblin.png"))
            {
                var tuckBox = new TuckBox(pixelDimensions, image);
                var paths = new List<Path>();

                switch (nextPage)
                {
                    case 1:
                        paths.AddRange(tuckBox.GetFrontAndSides());
                        break;
                    case 2:
                        paths.AddRange(tuckBox.GetSeparateBack());
                        break;
                }

                var pen = Pens.Black;

                DrawPaths(e.Graphics, paths, pen);
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
