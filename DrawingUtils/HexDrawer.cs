using System;
using System.Drawing;

namespace DrawingUtils
{
    public class HexDrawer : IGridDrawer
    {
        public GridType GridType => GridType.Hex;

        public Color Colour { get; }

        public float PolygonsPerInch { get; }

        public float MarginInInches { get; }

        public HexDrawer(Color colour, float hexesPerInch, float marginInInches)
        {
            Colour = colour;
            PolygonsPerInch = hexesPerInch;
            MarginInInches = marginInInches;
        }

        private void DrawSquare(float x, float y, float halfHexHeight, float halfHexSide, bool drawTopEdge,
            bool drawTopLeftEdge, bool drawBottomLeftEdge, Action<float, float, float, float> drawLine)
        {
            drawLine(x + 2 * halfHexSide, y, x + 3 * halfHexSide, y + halfHexHeight);
            drawLine(x + 2 * halfHexSide, y + 2 * halfHexHeight, x + 3 * halfHexSide, y + halfHexHeight);
            drawLine(x, y + 2 * halfHexHeight, x + 2 * halfHexSide, y + 2 * halfHexHeight);
            if (drawTopEdge)
            {
                drawLine(x, y, x + 2 * halfHexSide, y);
            }

            if (drawTopLeftEdge)
            {
                drawLine(x, y, x - halfHexSide, y + halfHexHeight);
            }

            if (drawBottomLeftEdge)
            {
                drawLine(x, y + 2 * halfHexHeight, x - halfHexSide, y + halfHexHeight);
            }
        }

        public void DrawGrid(float widthInInches, float heightInInches, float dpiX, float dpiY,
            float hardXMarginInches, float hardYMarginInches, Action<float, float, float, float> drawLine)
        {
            var xMargin = Math.Max(MarginInInches, hardXMarginInches) * dpiX;
            var yMargin = Math.Max(MarginInInches, hardYMarginInches) * dpiY;
            var width = (int) (widthInInches * dpiX);
            var height = (int) (heightInInches * dpiY);

            var hexHeightInches = 1 / PolygonsPerInch;
            var halfHexHeightInches = hexHeightInches / 2;
            var hexHeight = hexHeightInches * dpiY;
            var halfHexHeight = halfHexHeightInches * dpiY;

            var halfHexSideInches = (float) (halfHexHeightInches * Math.Tan(Math.PI / 6));
            var halfHexSide = halfHexSideInches * dpiX;

            var hexesAcross = (int) ((width - 2 * xMargin - halfHexSide) / (halfHexSide * 3));
            if (hexesAcross % 2 == 0)
            {
                hexesAcross -= 1;
            }

            var hexesDown = (int) ((height - 2 * yMargin) / hexHeight);

            var totalHexWidth = hexesAcross * halfHexSide * 3 + halfHexSide;
            var totalHexHeight = hexesDown * hexHeight;

            var adjustedXMargin = (int) ((width - totalHexWidth) / 2);
            var adjustedYMargin = (int) ((height - totalHexHeight) / 2);


            for (var y = 0; y < hexesDown; y++)
            {
                // Draw Line Above
                if (y > 0)
                {
                    for (var x = 1; x < hexesAcross; x += 2)
                    {
                        DrawSquare(adjustedXMargin + x * 3 * halfHexSide + halfHexSide,
                            adjustedYMargin + y * hexHeight - halfHexHeight, halfHexHeight, halfHexSide, y == 1, false,
                            false, drawLine);
                    }
                }

                for (var x = 0; x < hexesAcross; x += 2)
                {
                    DrawSquare(adjustedXMargin + x * 3 * halfHexSide + halfHexSide,
                        adjustedYMargin + y * hexHeight, halfHexHeight, halfHexSide, y == 0, x == 0 || y == 0,
                        x == 0 || y == hexesDown - 1, drawLine);
                }
            }
        }
    }
}
