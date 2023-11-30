using ModelScript.Physics.Objects;
using ModelScript.Physics.Particle;
using ModelScript.Physics.Particle.Emitter;
using SkiaSharp;

namespace ModelScript.Graphs.SimuGraphs
{
    public class SimulationGraphFrame
    {
        List<SimulationGraphBase> graphs = new List<SimulationGraphBase>();

        private int height = 1000;
        private int width = 1000;

        private float t = 0;

        private SKImageInfo imageInfo = new SKImageInfo(1, 1);

        public void addGraph(SimulationGraphBase graph)
        {
            graphs.Add(graph);
        }

        public void loadSimulation(float t, List<ParticleBase> particles, List<EmitterBase> emitters, List<ObjectBase> objects)
        {
            this.t = t;
            foreach (var graph in graphs)
            {
                graph.loadSimulationState(particles, emitters, objects);
            }
        }

        public void setHeight(int width, int height)
        {
            this.width = width;
            this.height = height;

            imageInfo.Width = width;
            imageInfo.Height = height;
        }
        public SKImage render()
        {
            using (SKSurface surface = SKSurface.Create(imageInfo))
            {
                SKCanvas canvas = surface.Canvas;

                foreach (GraphBase graph in graphs)
                {
                    graph.render(width, height, ref canvas);
                }

                canvas.DrawText("t = " + t, 20, 20, new SKPaint() { Color = SKColors.Black, TextSize = 20, Style = SKPaintStyle.Stroke, StrokeWidth = 2 });

                canvas.Save();

               

                return surface.Snapshot();
            }



        }
    }
}
