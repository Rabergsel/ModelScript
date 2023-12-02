using SkiaSharp;

namespace ModelScript.Graphs.Graph2D
{
    public class PointGraph : Graph2DBase
    {

        public int pointSize = 2;
        public SKColor color = SKColors.Red;

        public override void render(int width, int height, ref SKCanvas canvas)
        {

            evaluateBounds();
            evaluateCoords(width, height);

            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Stroke;
                skPaint.IsAntialias = true;
                skPaint.Color = color;
                skPaint.StrokeWidth = pointSize;
                skPaint.StrokeCap = SKStrokeCap.Round;

                foreach (var p in coords)
                {
                    canvas.DrawCircle(p.X, p.Y, pointSize, skPaint);
                }
            }



        }

    }
}
