using System.Drawing;

namespace DrawingUtils
{
    public class Line
    {
        public PointF FromPoint { get; }

        public PointF ToPoint { get; }

        public Line(PointF fromPoint, PointF toPoint)
        {
            FromPoint = fromPoint;
            ToPoint = toPoint;
        }
    }
}