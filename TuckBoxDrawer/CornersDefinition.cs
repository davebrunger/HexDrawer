namespace TuckBoxDrawer
{
    public class CornersDefinition
    {
        public float RadiusX { get; set; }

        public float RadiusY { get; set; }

        public Corner[] RoundedCorners { get; set; }

        public static CornersDefinition Default { get; } = new CornersDefinition
        {
            RadiusX = 0,
            RadiusY = 0,
            RoundedCorners = new Corner[0]
        };
    }
}
