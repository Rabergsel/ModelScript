using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelScript.Graphs.Scaler;
using System.Drawing;

using SkiaSharp;

namespace ModelScript.Graphs.Graph2D
{
    public class EncodingPointGraph : Graph2DBase
    {
        public int pointSize = 2;
        public SKColor color = SKColors.Red;

        public Utilities.Gradients.GradientBase pointColorGradient  = new Utilities.Gradients.GRGradient(255);

        public bool fixedBounds = false;
        public float minVal = -1f;
        public float maxVal = 1f;

        List<float> pointValues = new List<float>();

        public void addValue(float x, float y, float value)
        {
            addValue(x, y);
            pointValues.Add(value);
        }

        public void addValue(PointF point, float value)
        {
            addValue(point);
            pointValues.Add(value);
        }

        private Tuple<float, float> pointValueBoundaries()
        {

            if(fixedBounds)
            {
                return new Tuple<float, float>(minVal, maxVal);
            }

            var min = float.MaxValue;
            var max = float.MinValue;

            foreach(var value in pointValues)
            {
                if (value < min) min = value;
                if (value > max) max = value;
            }

            var tuple = new Tuple<float, float>(min, max);
            return tuple;

        }

        public override void render(int width, int height, ref SKCanvas canvas)
        {

            evaluateBounds();
            evaluateCoords(width, height);

            var boundaries = pointValueBoundaries();

            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Stroke;
                skPaint.IsAntialias = true;
                
                skPaint.StrokeWidth = pointSize;
                skPaint.StrokeCap = SKStrokeCap.Round;

                for(int i = 0; i < coords.Count; i++)
                {
                    var p = coords[i];
                    var c = pointColorGradient.getClampedRGB(pointValues[i], boundaries.Item1, boundaries.Item2);
                    //Console.WriteLine("Value = {0}", pointValues[i]);
                    skPaint.Color = new SKColor((byte)c.Item1, (byte)c.Item2, (byte)c.Item3, (byte)c.Item4);
                    canvas.DrawCircle(p.X, p.Y, pointSize, skPaint);
                }
            }



        }
    }
}
