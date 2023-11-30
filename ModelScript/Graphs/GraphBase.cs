using SkiaSharp;

namespace ModelScript.Graphs
{
    public abstract class GraphBase
    {
        public abstract void render(int width, int height, ref SKCanvas canvas);

    }
}
