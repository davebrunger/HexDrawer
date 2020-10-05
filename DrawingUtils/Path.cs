using System.Collections.Immutable;
using System.Drawing;
using System.IO;

namespace DrawingUtils
{
    public class Path
    {
        public ImmutableList<OneOf.OneOf<PointF, Line, Arc>> Segments { get; }

        public bool Closed { get; }

        public Image Image { get; }

        private Path(bool closed, ImmutableList<OneOf.OneOf<PointF, Line, Arc>> segments, Image image)
        {
            Closed = closed;
            Segments = segments;
            Image = image;
        }

        public Path(bool closed, params OneOf.OneOf<PointF, Line, Arc>[] segments) : this(closed, segments.ToImmutableList(), null)
        {
        }

        public Path(params OneOf.OneOf<PointF, Line, Arc>[] segments) : this(false, segments)
        {
        }

        public Path AddPoint(PointF point)
        {
            return new Path(Closed, Segments.Add(OneOf.OneOf<PointF, Line, Arc>.FromT0(point)), Image);
        }

        public Path AddPoint(float left, float top)
        {
            return AddPoint(new PointF(left, top));
        }

        public Path AddLine(Line line)
        {
            return new Path(Closed, Segments.Add(OneOf.OneOf<PointF, Line, Arc>.FromT1(line)), Image);
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
            return new Path(Closed, Segments.Add(OneOf.OneOf<PointF, Line, Arc>.FromT2(arc)), Image);
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

        public Path AddImage(Image image)
        {
            return new Path(Closed, Segments, image);
        }

        public Path AddImage(Stream data, RectangleF rectangle)
        {
            return new Path(Closed, Segments, new Image(data, rectangle));
        }
    }
}
