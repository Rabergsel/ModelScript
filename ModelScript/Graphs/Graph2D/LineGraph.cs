using SkiaSharp;

namespace ModelScript.Graphs.Graph2D
{
    public class LineGraph : Graph2DBase
    {
        public override void render(int width, int height, ref SKCanvas canvas)
        {
            evaluateBounds();
            evaluateCoords(width, height);

            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Stroke;
                skPaint.IsAntialias = true;
                skPaint.Color = SKColors.Red;
                skPaint.StrokeWidth = 10;
                skPaint.StrokeCap = SKStrokeCap.Round;

                for (int i = 1; i < coords.Count; i++)
                {
                    canvas.DrawLine(coords[i].X, coords[i].Y, coords[i - 1].X, coords[i - 1].Y, skPaint);
                }
            }
        }
    }
}
