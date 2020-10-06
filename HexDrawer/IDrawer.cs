using System.Drawing;

namespace HexDrawer
{
    public interface IDrawer
    {
        void PaintControl(Graphics graphics, int controlWidth, int controlHeight);
        
        int GetPageCount(PrinterSettings printerSettings);
        
        void PrintPage(Graphics graphics, PrinterSettings printerSettings, int pageNumber);
    }
}