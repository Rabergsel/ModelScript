using ModelScript.Graphs.Scaler;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs.Graph2D
{
    public abstract class Graph2DBase : GraphBase
    {
        public List<PointF> values = new List<PointF>();
        ScalerBase scaler = new LinearScaler();

        private PointF minBounds = new PointF(float.MaxValue, float.MaxValue);
        private PointF maxBounds = new PointF(float.MinValue, float.MinValue);

        public List<Point> coords = new List<Point>();

        public  void addValue(float x, float y)
        {
            values.Add(new PointF(x, y));
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

            }
        }


    }
}
