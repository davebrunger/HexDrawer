using System.Collections.Generic;

namespace DrawingUtils.Grids
{
    public interface IGrid
    {
        GridType GridType { get; }

        IEnumerable<Path> GetGrid();
    }
}