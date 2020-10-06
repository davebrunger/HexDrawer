using System;
using System.Windows.Forms;
using DrawingUtils.Grids;
using HexDrawer.Grids;
using HexDrawer.TuckBoxes;
using OneOf;

namespace HexDrawer
{
    public partial class OptionsDialog : Form
    {
        public OneOf<GridOptions, TuckBoxOptions> Options { get; private set; }

        public OptionsDialog()
        {
            InitializeComponent();
            TabControl.SelectedTab = GridPage;
            GridStyleDropDown.Items.Add(GridType.Hex);
            GridStyleDropDown.Items.Add(GridType.Square);
            GridStyleDropDown.SelectedIndex = 0;
            Options = new GridOptions(ColourPanel.BackColor, (int) HexesPerInchUpDown.Value,
                (float) MarginUpDown.Value, GridType.Hex);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (TabControl.SelectedTab == GridPage)
            {

                if (GridStyleDropDown.SelectedIndex == 0)
                {
                    Options = new GridOptions(ColourPanel.BackColor, (int) HexesPerInchUpDown.Value,
                        (float) MarginUpDown.Value, GridType.Hex);
                }
                else
                {
                    Options = new GridOptions(ColourPanel.BackColor, (int) HexesPerInchUpDown.Value,
                        (float) MarginUpDown.Value, GridType.Square);
                }
            }
            else if (TabControl.SelectedTab == TuckBoxPage)
            {
                Options = new TuckBoxOptions((float) MarginUpDown.Value, (float) TuckBoxHeightUpDown.Value,
                    (float) TuckBoxWidthUpDown.Value, (float) TuckBoxDepthUpDown.Value);
            }
        }

        private void OptionsDialog_Shown(object sender, EventArgs e)
        {
            Options.Switch(g =>
                {
                    TabControl.SelectedTab = GridPage;
                    ColourPanel.BackColor = g.Colour;
                    HexesPerInchUpDown.Value = g.PolygonsPerInch;
                    MarginUpDown.Value = (decimal) g.MarginInInches;
                    switch (g.GridType)
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
                },
                t =>
                {
                    TabControl.SelectedTab = TuckBoxPage;
                    MarginUpDown.Value = (decimal)t.MarginInInches;
                    TuckBoxHeightUpDown.Value = (decimal)t.HeightInInches;
                    TuckBoxWidthUpDown.Value = (decimal)t.WidthInInches;
                    TuckBoxDepthUpDown.Value = (decimal)t.DepthInInches;
                });
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
