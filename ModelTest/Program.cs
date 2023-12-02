using ModelScript.Graphs.SimuGraphs;
using ModelScript.Graphs.Utilities.Gradients;
using ModelScript.Physics.Objects;
using ModelScript.Simulation;
using ModelScript.Physics.Particle;

Environment2D world = new Environment2D();

var emitter = new ModelScript.Physics.Particle.Emitter.Circle2DEmitter() { amount = 100, activations = 5, particle = new SquareDeflatingParticle(1f, 1f) };
//emitter.vector = new ModelScript.Maths.Numeric.Vectors.Vector3D(0f, 1f, 0);
emitter.position = new ModelScript.Maths.Numeric.Vectors.Vector3D(0, 0, 0);


world.emitters.Add(emitter);

var visu = new SimulationGraphFrame();
visu.addGraph(new ParticleGraph() { plane = "XY" });

visu.setHeight(500, 500);
world.visus.Add(visu);


var visu2 = new SimulationGraphFrame();
visu2.addGraph(new FieldGraph() { gradient = new BWGradient(128), matrixHeight = 5, matrixWidth = 5, attribute = "amplitude" });
visu2.setHeight(500, 500);
world.visus.Add(visu2);


var wall1 = new AlignedPlane(new ModelScript.Maths.Numeric.Vectors.Vector3D(5, -10, -10), new ModelScript.Maths.Numeric.Vectors.Vector3D(5, 10, 10));
var wall2 = new AlignedPlane(new ModelScript.Maths.Numeric.Vectors.Vector3D(-5, -10, -10), new ModelScript.Maths.Numeric.Vectors.Vector3D(-5, 10, 10));
var wall3 = new AlignedPlane(new ModelScript.Maths.Numeric.Vectors.Vector3D(-15, 25, -10), new ModelScript.Maths.Numeric.Vectors.Vector3D(15, 25, 10));

var square = new AlignedSquare(-50, -50, 100, 100);

world.objects.Add(wall1);
world.objects.Add(wall2);
world.objects.Add(wall3);
world.objects.Add(square);

world.run(100, 0.9f);

VideoStacker.makeVideo(world.images[0], 24);
VideoStacker.makeVideo(world.images[1], 24, "field.webm");



/*
foreach (var list in world.images)
{
    for (int i = 0; i < list.Count; i++)
    {
        var graph = list[i];
        using (SKData data = graph.Encode(SKEncodedImageFormat.Png, 100))
        using (MemoryStream mStream = new MemoryStream(data.ToArray()))
        {
            Bitmap bm = new Bitmap(mStream, false);
            bm.Save("testgraph"+ i +".png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
*/