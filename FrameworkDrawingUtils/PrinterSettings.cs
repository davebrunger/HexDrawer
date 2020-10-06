using System.Drawing;

namespace FrameworkDrawingUtils
{
    public class PrinterSettings
    {
        public Rectangle PageBounds { get; }
        
        public float HardMarginX { get; }
        
        public float HardMarginY { get; }

        public PrinterSettings(Rectangle pageBounds, float hardMarginX, float hardMarginY)
        {
            PageBounds = pageBounds;
            HardMarginX = hardMarginX;
            HardMarginY = hardMarginY;
        }
    }
}
