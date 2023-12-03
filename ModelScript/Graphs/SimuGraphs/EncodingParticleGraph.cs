using ModelScript.Graphs.Graph2D;
using SkiaSharp;

namespace ModelScript.Graphs.SimuGraphs
{
    public class EncodingParticleGraph : SimulationGraphBase
    {
        private EncodingPointGraph pointGraph = new EncodingPointGraph();


        public string attribute = "";
        public string plane = "XY";

        public bool fixedValues = false;
        public float minVal = -1f;
        public float maxVal = 1f;

        public override void render(int width, int height, ref SKCanvas canvas)
        {
            pointGraph.values.Clear();
            pointGraph.fixedBounds = fixedValues;
            pointGraph.minVal = minVal;
            pointGraph.maxVal = maxVal;

            // Console.WriteLine("Number of particles in visu: " + particleList.Count);

            foreach (var p in particleList)
            {
                //  Console.WriteLine("Rendering: {0}|{1}|{2} with vector {3}|{4}|{5}", p.position.x, p.position.y, p.position.z, p.velocity.x, p.velocity.y, p.velocity.z);
                if (plane == "XY")
                {
                    if(attribute == "") pointGraph.addValue(p.position.x, p.position.y, 0);
                    else pointGraph.addValue(p.position.x, p.position.y, p.attributes[attribute]);
                }

                if (plane == "YZ")
                {
                    if(attribute == "") pointGraph.addValue(p.position.y, p.position.z, 0);
                    else pointGraph.addValue(p.position.y, p.position.z, p.attributes[attribute]);
                }

                if (plane == "XZ")
                {
                    if(attribute == "") pointGraph.addValue(p.position.x, p.position.z, 0);
                    else pointGraph.addValue(p.position.x, p.position.z, p.attributes[attribute]);

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
