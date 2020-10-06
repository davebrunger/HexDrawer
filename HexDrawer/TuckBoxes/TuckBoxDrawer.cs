using System;
using System.Collections.Generic;
using System.Drawing;
using DrawingUtils;
using DrawingUtils.TuckBoxes;
using FrameworkDrawingUtils;

namespace HexDrawer.TuckBoxes
{
    public class TuckBoxDrawer : Drawer<TuckBoxOptions>
    {
        private const float TabAsFractionOfDepth = 0.9f;
        private const float CornerAsFractionOfTab = 0.5f;

        public TuckBoxDrawer(TuckBoxOptions options) : base(options)
        {
        }

        public override int GetPageCount(PrinterSettings printerSettings) => 2;

        protected override void Paint(Graphics graphics, float widthInInches, float heightInInches, float dpiX,
            float dpiY, float xMarginInInches, float yMarginInInches, int? pageNumber = null)
        {
            using (var image = GetType().Assembly.GetManifestResourceStream("HexDrawer.Images.GreenGoblin.png"))
            {
                var pixelDimensions = new TuckBoxPixelDimensions(options.HeightInInches, options.WidthInInches,
                    options.DepthInInches, xMarginInInches, yMarginInInches, TabAsFractionOfDepth, CornerAsFractionOfTab,
                    100, 100);

                var tuckBox = new TuckBox(pixelDimensions, image);
                var pen = Pens.Black;
                var pathDrawer = new PathDrawer(graphics, pen);
                var paths = new List<Path>();

                switch (pageNumber)
                {
                    case null:
                        paths.AddRange(tuckBox.GetFrontAndSides());
                        paths.AddRange(tuckBox.GetAttachedBack());
                        break;
                    case 1:
                        paths.AddRange(tuckBox.GetFrontAndSides());
                        break;
                    case 2:
                        paths.AddRange(tuckBox.GetSeparateBack());
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(pageNumber));
                }

                foreach (var path in paths)
                {
                    pathDrawer.DrawPaths(path);
                }
            }
        }
    }
}
