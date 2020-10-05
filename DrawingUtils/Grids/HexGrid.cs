using System.Collections.Generic;

namespace DrawingUtils.Grids
{
    public class HexGrid : IGrid
    {
        private readonly IGridPixelDimensions pixelDimensions;

        public GridType GridType => GridType.Hex;

        public HexGrid(IGridPixelDimensions pixelDimensions)
        {
            this.pixelDimensions = pixelDimensions;
        }

        private static Path DrawSquare(float x, float y, float halfHexHeight, float halfHexSide, bool drawTopEdge,
            bool drawTopLeftEdge, bool drawBottomLeftEdge)
        {
            var path = new Path();

            if (drawTopLeftEdge)
            {
                path = path.AddPoint(x - halfHexSide, y + halfHexHeight);
            }

            if (drawTopEdge || drawTopLeftEdge)
            {
                path = path.AddPoint(x, y);
            }

            path = path.AddPoint(x + 2 * halfHexSide, y);
            path = path.AddPoint(x + 3 * halfHexSide, y + halfHexHeight);
            path = path.AddPoint(x + 2 * halfHexSide, y + 2 * halfHexHeight);
            path = path.AddPoint(x, y + 2 * halfHexHeight);
            
            if (drawBottomLeftEdge)
            {
                path = path.AddPoint(x - halfHexSide, y + halfHexHeight);
            }

            return path;
        }

        public IEnumerable<Path> GetGrid()
        {
            var halfHexHeight = pixelDimensions.PolygonHeightInPixels / 2;
            var halfHexSide = pixelDimensions.PolygonWidthInPixels / 2;

            var hexesAcross =
                (int) ((pixelDimensions.GridWidthInPixels - 2 * pixelDimensions.XMarginInPixels - halfHexSide) /
                       (halfHexSide * 3));
            if (hexesAcross % 2 == 0)
            {
                hexesAcross -= 1;
            }

            var hexesDown = (int) ((pixelDimensions.GridHeightInPixels - 2 * pixelDimensions.YMarginInPixels) /
                                   pixelDimensions.PolygonHeightInPixels);

            var totalHexWidth = hexesAcross * halfHexSide * 3 + halfHexSide;
            var totalHexHeight = hexesDown * pixelDimensions.PolygonHeightInPixels;

            var adjustedXMargin = (int) ((pixelDimensions.GridWidthInPixels - totalHexWidth) / 2);
            var adjustedYMargin = (int) ((pixelDimensions.GridHeightInPixels - totalHexHeight) / 2);

            for (var y = 0; y < hexesDown; y++)
            {
                // Draw Line Above
                if (y > 0)
                {
                    for (var x = 1; x < hexesAcross; x += 2)
                    {
                        yield return DrawSquare(
                            adjustedXMargin + x * 3 * halfHexSide + halfHexSide,
                            adjustedYMargin + y * pixelDimensions.PolygonHeightInPixels - halfHexHeight,
                            halfHexHeight, halfHexSide, y == 1, false, false);
                    }
                }

                for (var x = 0; x < hexesAcross; x += 2)
                {
                    yield return DrawSquare(
                        adjustedXMargin + x * 3 * halfHexSide + halfHexSide,
                        adjustedYMargin + y * pixelDimensions.PolygonHeightInPixels,
                        halfHexHeight, halfHexSide, y == 0, x == 0 || y == 0, x == 0 || y == hexesDown - 1);
                }
            }
        }
    }
}
