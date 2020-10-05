using System.Drawing;
using DrawingUtils.Grids;

namespace HexDrawer
{
    public class HexDrawerOptions
    {
        public Color Colour { get; }
        
        public int PolygonsPerInch { get; }
        
        public float MarginInInches { get; }
        
        public GridType GridType { get; }

        public HexDrawerOptions(Color colour, int polygonsPerInch, float marginInInches, GridType gridType)
        {
            Colour = colour;
            PolygonsPerInch = polygonsPerInch;
            MarginInInches = marginInInches;
            GridType = gridType;
        }
    }
}
