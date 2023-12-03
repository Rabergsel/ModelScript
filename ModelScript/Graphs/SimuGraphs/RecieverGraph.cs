using ModelScript.Physics.Particle.Reciever;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs.SimuGraphs
{
    public class RecieverGraph : SimulationGraphBase
    {

        public RecieverBase reciever;

        public int graphWidth = 100;
        public int graphHeight = 100;

        public int graphX = 0;
        public int graphY = 0;

        public override void render(int width, int height, ref SKCanvas canvas)
        {
            reciever.listen(time, particleList);


            SKImageInfo imageInfo = new SKImageInfo(graphWidth, graphHeight);
            using (SKSurface surface = SKSurface.Create(imageInfo))
            {
                SKCanvas recieverCanvas = surface.Canvas;
                reciever.visualization.render(graphWidth, graphHeight, ref recieverCanvas);
                recieverCanvas.Save();


                canvas.DrawImage(surface.Snapshot(), graphX, graphY);

            }
        }


    }
}
