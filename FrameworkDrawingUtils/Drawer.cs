using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace FrameworkDrawingUtils
{
    public abstract class Drawer<T> : IDrawer where T : IDrawerOptions
    {
        protected readonly T options;

        protected Drawer(T options)
        {
            this.options = options;
        }

        public abstract int GetPageCount(PrinterSettings printerSettings);

        protected abstract void Paint(Graphics graphics, float widthInInches, float heightInInches, float dpiX, float dpiY,
            float xMarginInInches, float yMarginInInches, int? pageNumber = null);

        public void PaintControl(Graphics graphics, int controlWidth, int controlHeight)
        {
            graphics.Clear(SystemColors.Control);
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            Paint(graphics, controlWidth / graphics.DpiX, controlHeight / graphics.DpiY, graphics.DpiX, graphics.DpiY,
                options.MarginInInches, options.MarginInInches);
        }

        public void PrintPage(Graphics graphics, PrinterSettings printerSettings, int pageNumber)
        {
            graphics.SmoothingMode = SmoothingMode.HighQuality;
            var xMarginInInches = Math.Max(options.MarginInInches, printerSettings.HardMarginX / 100f);
            var yMarginInInches = Math.Max(options.MarginInInches, printerSettings.HardMarginY / 100f);
            Paint(graphics, printerSettings.PageBounds.Width / 100f, printerSettings.PageBounds.Height / 100f,
                100, 100, xMarginInInches, yMarginInInches);
        }
    }
}
