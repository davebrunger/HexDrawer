using System.Drawing;

namespace DrawingUtils.TuckBoxes
{
    public class Arc
    {
        public RectangleF BoundingEllipse { get; }
        
        public float StartAngle { get; }
        
        public float SweepAngle { get; }

        public Arc(RectangleF boundingEllipse, float startAngle, float sweepAngle)
        {
            BoundingEllipse = boundingEllipse;
            StartAngle = startAngle;
            SweepAngle = sweepAngle;
        }
    }
}
