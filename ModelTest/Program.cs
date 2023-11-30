﻿using ModelScript.Graphs.SimuGraphs;
using ModelScript.Simulation;
using ModelScript.Physics.Objects;

Environment2D world = new Environment2D();

var emitter = new ModelScript.Physics.Particle.Emitter.RailgunEmitter();
emitter.vector = new ModelScript.Maths.Numeric.Vectors.Vector3D(1, 0, 0);

world.emitters.Add(emitter);

var visu = new SimulationGraphFrame();
visu.addGraph(new ParticleGraph() { plane = "XY" });
visu.setHeight(500, 500);
world.visus.Add(visu);

var wall = new AlignedPlane(new ModelScript.Maths.Numeric.Vectors.Vector3D(5, -10, -10), new ModelScript.Maths.Numeric.Vectors.Vector3D(5, 10, 10));
world.objects.Add(wall);

world.run(10, 0.1f);

VideoStacker.makeVideo(world.images[0]);


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