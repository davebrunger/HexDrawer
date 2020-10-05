using System.Collections.Immutable;
using System.Drawing;

namespace DrawingUtils
{
    public class Path
    {
        public ImmutableList<OneOf.OneOf<PointF, Line, Arc>> Segments { get; }

        public bool Closed { get; }

        private Path(bool closed, ImmutableList<OneOf.OneOf<PointF, Line, Arc>> segments)
        {
            Closed = closed;
            Segments = segments;
        }

        public Path(bool closed, params OneOf.OneOf<PointF, Line, Arc>[] segments) : this(closed, segments.ToImmutableList())
        {
        }

        public Path(params OneOf.OneOf<PointF, Line, Arc>[] segments) : this(false, segments)
        {
        }

        public Path AddPoint(PointF point)
        {
            return new Path(Closed, Segments.Add(OneOf.OneOf<PointF, Line, Arc>.FromT0(point)));
        }

        public Path AddPoint(float left, float top)
        {
            return AddPoint(new PointF(left, top));
        }

        public Path AddLine(Line line)
        {
            return new Path(Closed, Segments.Add(OneOf.OneOf<PointF, Line, Arc>.FromT1(line)));
        }

        public Path AddLine(PointF fromPoint, PointF toPoint)
        {
            return AddLine(new Line(fromPoint, toPoint));
        }

        public Path AddLine(float fromLeft, float fromTop, float toLeft, float toTop)
        {
            return AddLine(new PointF(fromLeft, fromTop), new PointF(toLeft, toTop));
        }

        public Path AddArc(Arc arc)
        {
            return new Path(Closed, Segments.Add(OneOf.OneOf<PointF, Line, Arc>.FromT2(arc)));
        }

        public Path AddArc(RectangleF boundingEllipse, int startAngle, int sweepAngle)
        {
            return AddArc(new Arc(boundingEllipse, startAngle, sweepAngle));
        }

        public Path AddArc(PointF location, SizeF size, int startAngle, int sweepAngle)
        {
            return AddArc(new RectangleF(location, size), startAngle, sweepAngle);
        }
        
        public Path AddArc(float left, float top, float width, float height, int startAngle, int sweepAngle)
        {
            return AddArc(new RectangleF(left, top, width, height), startAngle, sweepAngle);
        }
    }
}
