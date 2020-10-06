using System;
using System.Windows.Forms;
using FrameworkDrawingUtils;
using HexDrawer.Grids;
using HexDrawer.TuckBoxes;

namespace HexDrawer
{
    public partial class MainForm : Form
    {
        private readonly OptionsDialog optionsDialog = new OptionsDialog();

        private int nextPage = 1;

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
            var drawer = optionsDialog.Options.Match<IDrawer>(g => new GridDrawer(g), t => new TuckBoxDrawer(t));
            drawer.PaintControl(e.Graphics, DisplayPanel.Width, DisplayPanel.Height);

        }

        private void PrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var printerSettings =
                new PrinterSettings(e.PageBounds, e.PageSettings.HardMarginX, e.PageSettings.HardMarginY);

            var drawer = optionsDialog.Options.Match<IDrawer>(g => new GridDrawer(g), t => new TuckBoxDrawer(t));
            drawer.PrintPage(e.Graphics, printerSettings, 1);

            nextPage += 1;
            if (nextPage > drawer.GetPageCount(printerSettings))
            {
                nextPage = 1;
                e.HasMorePages = false;
            }
            else
            {
                e.HasMorePages = true;
            }
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
