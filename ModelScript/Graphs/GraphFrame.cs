using SkiaSharp;

namespace ModelScript.Graphs
{
    public class GraphFrame
    {
        List<GraphBase> graphs = new List<GraphBase>();

        private int height = 0;
        private int width = 0;

        private SKImageInfo imageInfo = new SKImageInfo(1, 1);

        public void addGraph(GraphBase graph)
        {
            graphs.Add(graph);
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

                return surface.Snapshot();
            }



        }


    }
}
