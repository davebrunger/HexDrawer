using System;
using System.Windows.Forms;
using DrawingUtils;

namespace HexDrawer
{
    public partial class OptionsDialog : Form
    {
        public IGridDrawer GridDrawer { get; private set; }

        public OptionsDialog()
        {
            InitializeComponent();
            GridStyleDropDown.Items.Add(GridType.Hex);
            GridStyleDropDown.Items.Add(GridType.Square);
            GridStyleDropDown.SelectedIndex = 0;
            GridDrawer = new DrawingUtils.HexDrawer(ColourPanel.BackColor, (float) HexesPerInchUpDown.Value,
                (float) MarginUpDown.Value);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (GridStyleDropDown.SelectedIndex == 0)
            {
                GridDrawer = new DrawingUtils.HexDrawer(ColourPanel.BackColor, (float) HexesPerInchUpDown.Value,
                    (float) MarginUpDown.Value);
            }
            else
            {
                GridDrawer = new SquareDrawer(ColourPanel.BackColor, (float)HexesPerInchUpDown.Value,
                    (float)MarginUpDown.Value);
            }
        }

        private void OptionsDialog_Shown(object sender, EventArgs e)
        {
            ColourPanel.BackColor = GridDrawer.Colour;
            HexesPerInchUpDown.Value = (decimal) GridDrawer.PolygonsPerInch;
            MarginUpDown.Value = (decimal) GridDrawer.MarginInInches;
            switch (GridDrawer.GridType)
            {
                case GridType.Hex:
                    GridStyleDropDown.SelectedIndex = 0;
                    break;
                case GridType.Square:
                    GridStyleDropDown.SelectedIndex = 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void ChangeColourButton_Click(object sender, EventArgs e)
        {
            ColourDialog.Color = ColourPanel.BackColor;
            if (ColourDialog.ShowDialog() == DialogResult.OK)
            {
                ColourPanel.BackColor = ColourDialog.Color;
            }
        }

        private void OptionsDialog_Load(object sender, EventArgs e)
        {

        }
    }
}
