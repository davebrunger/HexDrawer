using System;
using System.Windows.Forms;
using DrawingUtils.Grids;

namespace HexDrawer
{
    public partial class OptionsDialog : Form
    {
        public HexDrawerOptions Options { get; private set; }

        public OptionsDialog()
        {
            InitializeComponent();
            GridStyleDropDown.Items.Add(GridType.Hex);
            GridStyleDropDown.Items.Add(GridType.Square);
            GridStyleDropDown.SelectedIndex = 0;
            Options = new HexDrawerOptions(ColourPanel.BackColor, (int) HexesPerInchUpDown.Value,
                (float) MarginUpDown.Value, GridType.Hex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (GridStyleDropDown.SelectedIndex == 0)
            {
                Options = new HexDrawerOptions(ColourPanel.BackColor, (int) HexesPerInchUpDown.Value,
                    (float) MarginUpDown.Value, GridType.Hex);
            }
            else
            {
                Options = new HexDrawerOptions(ColourPanel.BackColor, (int) HexesPerInchUpDown.Value,
                    (float) MarginUpDown.Value, GridType.Square);
            }
        }

        private void OptionsDialog_Shown(object sender, EventArgs e)
        {
            ColourPanel.BackColor = Options.Colour;
            HexesPerInchUpDown.Value = (decimal) Options.PolygonsPerInch;
            MarginUpDown.Value = (decimal) Options.MarginInInches;
            switch (Options.GridType)
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
    }
}
