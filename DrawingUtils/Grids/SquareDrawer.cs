using System;
using System.Collections.Generic;
using System.Drawing;

namespace DrawingUtils.Grids
{
    public class SquareGrid : IGrid
    {
        private readonly IGridPixelDimensions pixelDimensions;

        public GridType GridType => GridType.Square;

        public SquareGrid(IGridPixelDimensions pixelDimensions)
        {
            this.pixelDimensions = pixelDimensions;
        }

        private Path DrawSquare(float x, float y, bool drawTopEdge, bool drawLeftEdge)
        {
            var path = new Path();

            if (drawLeftEdge)
            {
                path = path.AddPoint(x, y);
            }

            path = path.AddPoint(x, y + pixelDimensions.PolygonHeightInPixels);
            path = path.AddPoint(x + pixelDimensions.PolygonWidthInPixels, y + pixelDimensions.PolygonHeightInPixels);
            path = path.AddPoint(x + pixelDimensions.PolygonWidthInPixels, y);

            if (drawTopEdge)
            {
                path = path.AddPoint(x, y);
            }

            return path;
        }

        public IEnumerable<Path> GetGrid()
        {
            var squaresAcross = (int) ((pixelDimensions.GridWidthInPixels - 2 * pixelDimensions.XMarginInPixels) /
                                       pixelDimensions.PolygonWidthInPixels);
            var squaresDown = (int) ((pixelDimensions.GridHeightInPixels - 2 * pixelDimensions.XMarginInPixels) /
                                     pixelDimensions.PolygonHeightInPixels);

            var totalHexWidth = squaresAcross * pixelDimensions.PolygonWidthInPixels;
            var totalHexHeight = squaresDown * pixelDimensions.PolygonHeightInPixels;

            var adjustedXMargin = (int) ((pixelDimensions.GridWidthInPixels - totalHexWidth) / 2);
            var adjustedYMargin = (int) ((pixelDimensions.GridHeightInPixels - totalHexHeight) / 2);


            for (var y = 0; y < squaresDown; y++)
            {
                for (var x = 0; x < squaresAcross; x++)
                {
                    yield return DrawSquare(adjustedXMargin + x * pixelDimensions.PolygonWidthInPixels,
                        adjustedYMargin + y * pixelDimensions.PolygonHeightInPixels, y == 0, x == 0);
                }
            }
        }
    }
}
