using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using DrawingUtils.Grids;
using FrameworkDrawingUtils;

namespace HexDrawer
{
    public partial class MainForm : Form
    {
        private readonly OptionsDialog optionsDialog = new OptionsDialog();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            DisplayPanel.Invalidate();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (PrintDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument.Print();
            }
        }

        private void DisplayPanel_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            DrawGrid(e.Graphics, DisplayPanel.Width / e.Graphics.DpiX, DisplayPanel.Height / e.Graphics.DpiY,
                e.Graphics.DpiX, e.Graphics.DpiY, optionsDialog.Options.MarginInInches,
                optionsDialog.Options.MarginInInches);
        }

        private void DrawGrid(Graphics graphics, float widthInInches, float heightInInches, float dpiX, float dpiY,
            float xMarginInInches, float yMarginInInches)
        {
            var pen = new Pen(optionsDialog.Options.Colour);

            IGridPixelDimensions pixelDimensions;
            IGrid grid;
            switch (optionsDialog.Options.GridType)
            {
                case GridType.Hex:
                    pixelDimensions = new HexGridPixelDimensions(xMarginInInches, yMarginInInches, widthInInches,
                        heightInInches, optionsDialog.Options.PolygonsPerInch, dpiX, dpiY);
                    grid = new HexGrid(pixelDimensions);
                    break;
                case GridType.Square:
                    pixelDimensions = new SquareGridPixelDimensions(xMarginInInches, yMarginInInches, widthInInches,
                        heightInInches, optionsDialog.Options.PolygonsPerInch, dpiX, dpiY);
                    grid = new SquareGrid(pixelDimensions);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            var pathDrawer = new PathDrawer(graphics, pen);
            pathDrawer.DrawPaths(grid.GetGrid());
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;

            var xMarginInInches = Math.Max(optionsDialog.Options.MarginInInches, e.PageSettings.HardMarginX / 100f);
            var yMarginInInches = Math.Max(optionsDialog.Options.MarginInInches, e.PageSettings.HardMarginY / 100f);

            DrawGrid(e.Graphics, e.PageBounds.Width / 100f, e.PageBounds.Height / 100f,
                100, 100, xMarginInInches, yMarginInInches);

            e.HasMorePages = false;
        }

        private void ChangeOptionsButton_Click(object sender, EventArgs e)
        {
            if (optionsDialog.ShowDialog() == DialogResult.OK)
            {
                DisplayPanel.Invalidate();
            }
        }
    }
}
