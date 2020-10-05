using System.Drawing;
using System.IO;

namespace DrawingUtils
{
    public class Image
    {
        public Stream Data { get; }

        public RectangleF Rectangle { get; }

        public Image(Stream data, RectangleF rectangle)
        {
            Data = data;
            Rectangle = rectangle;
        }
    }
}
