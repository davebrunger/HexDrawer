namespace DrawingUtils.Grids
{
    public interface IGridPixelDimensions
    {
        float GridHeightInPixels { get; }

        float GridWidthInPixels { get; }
        
        float PolygonHeightInPixels { get; }

        float PolygonWidthInPixels { get; }

        float XMarginInPixels { get; }

        float YMarginInPixels { get; }
    }
}
