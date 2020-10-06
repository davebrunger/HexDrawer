using System.Drawing;
using DrawingUtils.Grids;

namespace HexDrawer.Grids
{
    public class GridOptions : IDrawerOptions
    {
        public Color Colour { get; }
        
        public int PolygonsPerInch { get; }
        
        public float MarginInInches { get; }
        
        public GridType GridType { get; }

        public GridOptions(Color colour, int polygonsPerInch, float marginInInches, GridType gridType)
        {
            Colour = colour;
            PolygonsPerInch = polygonsPerInch;
            MarginInInches = marginInInches;
            GridType = gridType;
        }
    }
}
