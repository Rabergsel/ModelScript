using ModelScript;
using ModelScript.Graphs;
using ModelScript.Graphs.Graph2D;
using SkiaSharp;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

var frame = new GraphFrame();

frame.setHeight(1000, 1000);

var matrixgraph = new MatrixGraph(new ModelScript.Maths.Numeric.Matrices.Matrix(
    new float[3, 3]
    {
        {0, 1, 0 },
        {1, 0.5f, 1},
        {0, 0, 0}
    }),

    new ModelScript.Graphs.Utilities.Gradients.BWGradient()
    );

frame.addGraph(matrixgraph);


var graph = frame.render();

using (SKData data = graph.Encode(SKEncodedImageFormat.Png, 100))
using (MemoryStream mStream = new MemoryStream(data.ToArray()))
{
    Bitmap bm = new Bitmap(mStream, false);
    bm.Save("testgraph.png", System.Drawing.Imaging.ImageFormat.Png);
}