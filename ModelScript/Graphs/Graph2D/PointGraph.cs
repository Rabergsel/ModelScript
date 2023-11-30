using SkiaSharp;

namespace ModelScript.Graphs.Graph2D
{
    public class PointGraph : Graph2DBase
    {

        public bool drawGrid = true;


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

                foreach (var p in coords)
                {
                    canvas.DrawCircle(p.X, p.Y, 3, skPaint);
                }
            }

            if (drawGrid)
            {
                makeGrid(ref canvas, width, height);
            }
        }



    }
}
