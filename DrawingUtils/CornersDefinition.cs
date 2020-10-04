using System.Collections.Immutable;
using System.Drawing;

namespace DrawingUtils
{
    public class CornersDefinition
    {
        public SizeF Radius { get; }

        public ImmutableList<Corner> RoundedCorners { get; }

        public CornersDefinition(SizeF radius, params Corner[] roundedCorners)
        {
            Radius = radius;
            RoundedCorners = roundedCorners.ToImmutableList();
        }

        public static CornersDefinition Default { get; } = new CornersDefinition(SizeF.Empty);
    }
}
