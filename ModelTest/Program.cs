using ModelScript;
using ModelScript.Graphs;
using ModelScript.Graphs.Graph2D;
using SkiaSharp;
using static System.Net.Mime.MediaTypeNames;
using System.Drawing;

var frame = new GraphFrame();

frame.setHeight(1000, 1000);

var pointGraph = new LineGraph();
for(float x = 0; x < 5; x+=0.00001f)
{
    pointGraph.addValue(x, x * x - 1);
}
frame.addGraph(pointGraph);
var graph = frame.render();

using (SKData data = graph.Encode(SKEncodedImageFormat.Png, 100))
using (MemoryStream mStream = new MemoryStream(data.ToArray()))
{
    Bitmap bm = new Bitmap(mStream, false);
    bm.Save("testgraph.png", System.Drawing.Imaging.ImageFormat.Png);
}