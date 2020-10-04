using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace HexDrawer
{
    public partial class MainForm : Form
    {
        private readonly OptionsDialog optionsDialog = new OptionsDialog();

        public MainForm()
        {
            InitializeComponent();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(SystemColors.Control);
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var pen = new Pen(optionsDialog.GridDrawer.Colour);
            optionsDialog.GridDrawer.DrawGrid(panel2.Width / e.Graphics.DpiX,
                panel2.Height / e.Graphics.DpiY, e.Graphics.DpiX, e.Graphics.DpiY,
                optionsDialog.GridDrawer.MarginInInches, optionsDialog.GridDrawer.MarginInInches, (x1, y1, x2, y2) =>
                {
                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                });
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            panel2.Invalidate();
        }

        private void PrintButton_Click(object sender, EventArgs e)
        {
            if (PrintDialog.ShowDialog() == DialogResult.OK)
            {
                PrintDocument.Print();
            }
        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            var pen = new Pen(optionsDialog.GridDrawer.Colour);
            optionsDialog.GridDrawer.DrawGrid(e.PageBounds.Width / 100f, e.PageBounds.Height / 100f, 100,
                100, e.PageSettings.HardMarginX / 100f, e.PageSettings.HardMarginY / 100f, (x1, y1, x2, y2) =>
                {
                    e.Graphics.DrawLine(pen, x1, y1, x2, y2);
                });

            e.HasMorePages = false;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void ChangeOptionsButton_Click(object sender, EventArgs e)
        {
            if (optionsDialog.ShowDialog() == DialogResult.OK)
            {
                panel2.Invalidate();
            }
        }
    }
}
