using System;
using System.Drawing;
using DrawingUtils.Grids;
using FrameworkDrawingUtils;

namespace HexDrawer.Grids
{
    public class GridDrawer : Drawer<GridOptions>
    {
        public GridDrawer(GridOptions options) : base(options)
        {
        }

        public override int GetPageCount(PrinterSettings _) => 1;

        protected override void Paint(Graphics graphics, float widthInInches, float heightInInches, float dpiX, float dpiY,
            float xMarginInInches, float yMarginInInches, int? pageNumber = null)
        {
            var pen = new Pen(options.Colour);

            IGridPixelDimensions pixelDimensions;
            IGrid grid;
            switch (options.GridType)
            {
                case GridType.Hex:
                    pixelDimensions = new HexGridPixelDimensions(xMarginInInches, yMarginInInches, widthInInches,
                        heightInInches, options.PolygonsPerInch, dpiX, dpiY);
                    grid = new HexGrid(pixelDimensions);
                    break;
                case GridType.Square:
                    pixelDimensions = new SquareGridPixelDimensions(xMarginInInches, yMarginInInches, widthInInches,
                        heightInInches, options.PolygonsPerInch, dpiX, dpiY);
                    grid = new SquareGrid(pixelDimensions);
                    break;
                default:
                    throw new IndexOutOfRangeException();
            }

            var pathDrawer = new PathDrawer(graphics, pen);
            pathDrawer.DrawPaths(grid.GetGrid());
        }
    }
}
