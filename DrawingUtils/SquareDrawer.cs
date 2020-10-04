using System;
using System.Drawing;

namespace DrawingUtils
{
    public class SquareDrawer : IGridDrawer
    {
        public GridType GridType => GridType.Square;

        public Color Colour { get; }

        public float PolygonsPerInch { get; }

        public float MarginInInches { get; }

        public SquareDrawer(Color colour, float hexesPerInch, float marginInInches)
        {
            Colour = colour;
            PolygonsPerInch = hexesPerInch;
            MarginInInches = marginInInches;
        }

        private void DrawSquare(float x, float y, float squareHeight, float squareWidth, bool drawTopEdge,
            bool drawLeftEdge, Action<float, float, float, float> drawLine)
        {
            drawLine(x, y + squareHeight, x + squareWidth, y + squareHeight);
            drawLine(x + squareWidth, y, x + squareWidth, y + squareHeight);
            if (drawTopEdge)
            {
                drawLine(x, y, x + squareWidth, y);
            }

            if (drawLeftEdge)
            {
                drawLine(x, y, x, y + squareHeight);
            }
        }

        public void DrawGrid(float widthInInches, float heightInInches, float dpiX, float dpiY,
            float hardXMarginInches, float hardYMarginInches, Action<float, float, float, float> drawLine)
        {
            var xMargin = Math.Max(MarginInInches, hardXMarginInches) * dpiX;
            var yMargin = Math.Max(MarginInInches, hardYMarginInches) * dpiY;
            var width = (int) (widthInInches * dpiX);
            var height = (int) (heightInInches * dpiY);

            var squareHeightInches = 1 / PolygonsPerInch;
            var squareWidth = squareHeightInches * dpiX;
            var squareHeight = squareHeightInches * dpiY;

            var squaresAcross = (int) ((width - 2 * xMargin) / squareWidth);
            var squaresDown = (int) ((height - 2 * yMargin) / squareHeight);

            var totalHexWidth = squaresAcross * squareWidth;
            var totalHexHeight = squaresDown * squareHeight;

            var adjustedXMargin = (int) ((width - totalHexWidth) / 2);
            var adjustedYMargin = (int) ((height - totalHexHeight) / 2);


            for (var y = 0; y < squaresDown; y++)
            {
                for (var x = 0; x < squaresAcross; x++)
                {
                    DrawSquare(adjustedXMargin + x * squareWidth, adjustedYMargin + y * squareHeight, squareHeight,
                        squareWidth, y == 0, x == 0, drawLine);
                }
            }
        }
    }
}
