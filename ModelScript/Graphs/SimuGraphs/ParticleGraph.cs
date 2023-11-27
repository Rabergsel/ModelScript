using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelScript.Graphs.Graph2D;
using SkiaSharp;

namespace ModelScript.Graphs.SimuGraphs
{
    internal class ParticleGraph : SimulationGraphBase
    {
        PointGraph pointGraph = new PointGraph();

        public override void render(int width, int height, ref SKCanvas canvas)
        {
            pointGraph.values.Clear();
            
            foreach(var p in particleList)
            {
                pointGraph.addValue(p.position.x, p.position.y);
            }

            pointGraph.render(width, height, ref canvas);

        }


    }
}
