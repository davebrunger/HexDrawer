using System.Drawing;

namespace DrawingUtils
{
    public interface IPath
    {
        IPath AddArc(RectangleF boundingEllipse, float startAngle, float sweepAngle);
        
        IPath AddPoint(PointF point);

        void Draw();
    }
}
