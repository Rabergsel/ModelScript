using ModelScript.Graphs.Scaler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SkiaSharp;

namespace ModelScript.Graphs.Graph2D
{
    public abstract class Graph2DBase : GraphBase
    {
        public List<PointF> values = new List<PointF>();
        public ScalerBase scaler = new LinearScaler();

        private PointF minBounds = new PointF(float.MaxValue, float.MaxValue);
        private PointF maxBounds = new PointF(float.MinValue, float.MinValue);

        public List<Point> coords = new List<Point>();

        public SKColor originColor = SKColors.Red;

        public  void addValue(float x, float y)
        {
            values.Add(new PointF(x, y));
        //    Console.WriteLine("Graph2DBase.addValue(): Added {0}|{1}", x, y);
        }

        public void addValue(PointF pointF)
        {
            values.Add(pointF);
        }

        internal void evaluateBounds()
        {
            foreach(var p in values)
            {
                if (p.X < minBounds.X) minBounds.X = p.X;
                if (p.X > maxBounds.X) maxBounds.X = p.X;

                if (p.Y < minBounds.Y) minBounds.Y = p.Y;
                if (p.Y > maxBounds.Y) maxBounds.Y = p.Y;

            }

            if(minBounds.X == maxBounds.X)
            {
                minBounds.X -= 1;
                maxBounds.X += 1;
            }
            if (minBounds.Y == maxBounds.Y)
            {
                minBounds.Y -= 1;
                maxBounds.Y += 1;
            }

            //Console.WriteLine("Graph2DBase.evaluateBounds(): Min = {0}\tMax = {1}", minBounds.X, minBounds.Y);
        }

        internal void evaluateCoords(int width, int height)
        {
            foreach(var p in values)
            {
                Point point = new Point();

                var x = scaler.scale(p.X, minBounds.X, maxBounds.X);
                var y = 1 - scaler.scale(p.Y, minBounds.Y, maxBounds.Y);

                point.X = (int)(x * width);
                point.Y = (int)(y * height);

                coords.Add(point);
             //   Console.WriteLine("Graph2DBase.evaluateCoords(): Mapped ({0}|{1}) to ({2}|{3})", p.X, p.Y, point.X, point.Y);

            }
        }

        internal void makeGrid(ref SKCanvas canvas, int width, int height)
        {

            //Draw Origin Line
            using (SKPaint skPaint = new SKPaint())
            {
                skPaint.Style = SKPaintStyle.Stroke;
                skPaint.IsAntialias = true;
                skPaint.Color = originColor;
                skPaint.StrokeWidth = 2;
                skPaint.StrokeCap = SKStrokeCap.Round;

                var origin_X = width * scaler.scale(0, minBounds.X, maxBounds.X);
                var origin_Y = height* scaler.scale(0, minBounds.Y, maxBounds.Y);
                if (origin_X > 0 & origin_Y > 0)
                {
                    Console.WriteLine("DrawLine: {0}|{1} to {2}|{3}", 0, origin_Y, width, origin_Y);
                    Console.WriteLine("DrawLine: {0}|{1} to {2}|{3}", origin_X, 0, origin_X, height);

                    canvas.DrawLine(0, origin_Y, width, origin_Y, skPaint);
                    canvas.DrawLine(origin_X, 0, origin_X, height, skPaint);
                }
            }

        }


    }
}
