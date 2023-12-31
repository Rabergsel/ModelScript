﻿using ModelScript.Graphs.Graph2D;
using SkiaSharp;

namespace ModelScript.Graphs.SimuGraphs
{
    public class ParticleGraph : SimulationGraphBase
    {
        private PointGraph pointGraph = new PointGraph();



        public string plane = "XY";

        public override void render(int width, int height, ref SKCanvas canvas)
        {
            pointGraph.values.Clear();

            // Console.WriteLine("Number of particles in visu: " + particleList.Count);

            foreach (var p in particleList)
            {
                //  Console.WriteLine("Rendering: {0}|{1}|{2} with vector {3}|{4}|{5}", p.position.x, p.position.y, p.position.z, p.velocity.x, p.velocity.y, p.velocity.z);
                if (plane == "XY")
                {
                    pointGraph.addValue(p.position.x, p.position.y);
                }

                if (plane == "YZ")
                {
                    pointGraph.addValue(p.position.y, p.position.z);
                }

                if (plane == "XZ")
                {
                    pointGraph.addValue(p.position.x, p.position.z);
                }
            }

            foreach (var o in objectList)
            {
                o.visualize(plane, ref canvas, width, height, pointGraph.minBounds, pointGraph.maxBounds);
            }

            pointGraph.render(width, height, ref canvas);

            canvas.DrawText(plane + "-Plane", 50, 50, new SKPaint()
            {
                TextSize = 10,
                Color = SKColors.Black,
                Style = SKPaintStyle.Stroke,
                StrokeWidth = 2
            });



        }


    }
}
