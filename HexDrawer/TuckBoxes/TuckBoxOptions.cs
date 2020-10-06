using FrameworkDrawingUtils;

namespace HexDrawer.TuckBoxes
{
    public class TuckBoxOptions : IDrawerOptions
    {
        public float MarginInInches { get; }
        
        public float HeightInInches { get; }
        
        public float WidthInInches { get; }
        
        public float DepthInInches { get; }

        public TuckBoxOptions(float marginInInches, float heightInInches, float widthInInches, float depthInInches)
        {
            MarginInInches = marginInInches;
            HeightInInches = heightInInches;
            WidthInInches = widthInInches;
            DepthInInches = depthInInches;
        }
    }
}
