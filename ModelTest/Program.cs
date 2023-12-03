using ModelScript.Graphs.Graph2D;
using ModelScript.Graphs.SimuGraphs;
using ModelScript.Graphs.Utilities.Gradients;
using ModelScript.Physics.Objects;
using ModelScript.Physics.Particle.Reciever;
using ModelScript.Simulation;

Environment2D world = new Environment2D();
world.maxDistance = 20f;

var emitter = new ModelScript.Physics.Particle.Emitter.Circle2DEmitter() { amount = 30, activations = 100, maxNoise = 0.15f };
//emitter.vector = new ModelScript.Maths.Numeric.Vectors.Vector3D(0f, 1f, 0);
emitter.position = new ModelScript.Maths.Numeric.Vectors.Vector3D(0, 0, 0);

var calc = new ModelScript.Simulation.Calculators.SonicAmplitudeCalculator() { frequency = 0.2f };
world.calculators.Add(calc);

world.emitters.Add(emitter);

var visu = new SimulationGraphFrame();
visu.addGraph(new EncodingParticleGraph() { plane = "XY", attribute = "sonicEnergy", fixedValues = true, minVal = -1f, maxVal = 1f });
//visu.addGraph(new FieldGraph() { gradient = new BWGradient(128), matrixHeight = 50, matrixWidth = 50, attribute = "sonicEnergy" });
visu.addGraph(new RecieverGraph()
{
    reciever = new SphericalReciever()
    {
        attribute = "sonicEnergy",
        position = new ModelScript.Maths.Numeric.Vectors.Vector3D(0, 0, 0),
        visualization = new LineGraph(),
        logarithmic = false

    },
    graphX = 0,
    graphY = 400
});

visu.setHeight(400, 400);
world.visus.Add(visu);





var wall1 = new AlignedPlane(new ModelScript.Maths.Numeric.Vectors.Vector3D(5, -10, -10), new ModelScript.Maths.Numeric.Vectors.Vector3D(5, 10, 10));
var wall2 = new AlignedPlane(new ModelScript.Maths.Numeric.Vectors.Vector3D(-5, -10, -10), new ModelScript.Maths.Numeric.Vectors.Vector3D(-5, 10, 10));
var square = new AlignedSquare(-15, -15, 30, 30);

world.objects.Add(wall1);
world.objects.Add(wall2);
world.objects.Add(square);

world.run(100, 0.3333f);

VideoStacker.makeVideo(world.images[0], 30);



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