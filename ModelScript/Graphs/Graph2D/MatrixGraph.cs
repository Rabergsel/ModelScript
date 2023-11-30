using ModelScript.Graphs.Utilities.Gradients;
using ModelScript.Maths.Numeric.Matrices;
using SkiaSharp;

namespace ModelScript.Graphs.Graph2D
{
    public class MatrixGraph : GraphBase
    {

        Matrix values;
        GradientBase gradient;

        public MatrixGraph(Matrix values, GradientBase gradient)
        {
            this.values = values;
            this.gradient = gradient;
        }

        public override void render(int width, int height, ref SKCanvas canvas)
        {

            float min = float.MaxValue;
            float max = float.MinValue;


            for (int x = 0; x < values.width; x++)
            {
                for (int y = 0; y < values.height; y++)
                {
                    var value = values.getValue(x, y);

                    if (value < min) { min = value; }
                    if (value > max) { max = value; }

                }
            }
            float fieldheight = height / values.height;
            float fieldwidth = width / values.width;

            for (int x = 0; x < values.width; x++)
            {
                for (int y = 0; y < values.height; y++)
                {
                    using (SKPaint skPaint = new SKPaint())
                    {
                        var rgb = gradient.getRGB(values.getValue(x, y));

                        skPaint.Style = SKPaintStyle.Fill;
                        skPaint.IsAntialias = true;
                        skPaint.Color = new SKColor((byte)rgb.Item1, (byte)rgb.Item2, (byte)rgb.Item3);
                        skPaint.StrokeWidth = 10;
                        skPaint.StrokeCap = SKStrokeCap.Round;



                        canvas.DrawRect(x * fieldwidth, y * fieldheight, fieldwidth, fieldheight, skPaint);


                    }

                }
            }



        }

    }
}
