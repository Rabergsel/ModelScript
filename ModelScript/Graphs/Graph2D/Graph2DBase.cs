﻿using ModelScript.Graphs.Scaler;
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
        public ScalerBase scaler = new LinearScaler();

        private PointF minBounds = new PointF(float.MaxValue, float.MaxValue);
        private PointF maxBounds = new PointF(float.MinValue, float.MinValue);

        public List<Point> coords = new List<Point>();

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


    }
}
