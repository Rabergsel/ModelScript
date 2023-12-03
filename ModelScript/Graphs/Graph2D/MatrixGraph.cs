using ModelScript.Graphs.Utilities.Gradients;
using ModelScript.Maths.Numeric.Matrices;
using SkiaSharp;

namespace ModelScript.Graphs.Graph2D
{
    public class MatrixGraph : GraphBase
    {
        public Matrix values = new Matrix(2, 2);
        public GradientBase gradient;

        public void setMatrix(Matrix matrix)
        {
            values = matrix;
        }

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
                        var rgb = gradient.getClampedRGB(values.getValue(x, y), min, max);

                        skPaint.Style = SKPaintStyle.Fill;
                        skPaint.IsAntialias = true;
                        skPaint.Color = new SKColor((byte)rgb.Item1, (byte)rgb.Item2, (byte)rgb.Item3, (byte)rgb.Item4);
                        //Console.WriteLine("Value = {4}\t (x|y) = ({5}|{6})\t min = ({7}|{8}) \tColor = {0} | {1} | {2} | {3}", rgb.Item1, rgb.Item2, rgb.Item3, rgb.Item4, values.getValue(x, y), x, y, min, max);
                        skPaint.StrokeWidth = 10;
                        skPaint.StrokeCap = SKStrokeCap.Round;

                        canvas.DrawRect(x * fieldwidth, y * fieldheight, fieldwidth, fieldheight, skPaint);


                    }

                }
            }



        }

    }
}
