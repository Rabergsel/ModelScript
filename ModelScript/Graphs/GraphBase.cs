using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs
{
    public abstract class GraphBase
    {
        public abstract void render(int width, int height, ref SKCanvas canvas);

    }
}
