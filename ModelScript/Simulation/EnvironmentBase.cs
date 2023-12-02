using ModelScript.Graphs.SimuGraphs;
using ModelScript.Physics.Objects;
using ModelScript.Physics.Particle;
using ModelScript.Physics.Particle.Emitter;
using SkiaSharp;

using FFMpegCore;
using FFMpegCore.Pipes;

namespace ModelScript.Simulation
{
    public abstract class EnvironmentBase
    {

        public float time;

        public List<SimulationGraphFrame> visus = new List<SimulationGraphFrame>();

        public List<ParticleBase> particles = new List<ParticleBase>();
        public List<EmitterBase> emitters = new List<EmitterBase>();
        public List<ObjectBase> objects = new List<ObjectBase>();

        public abstract void run(float timespan, float timestep);

        internal abstract void updateParticles(float time, float timestep);
        internal abstract void updateEmitters(float time, float timestep);

        public List<List<SKImage>> images = new List<List<SKImage>>();

        internal void renderVisus()
        {
            for (int i = 0; i < visus.Count; i++)
            {
                if (images.Count <= i) images.Add(new List<SKImage>());
                visus[i].loadSimulation(time, particles, emitters, objects);
                var render = visus[i].render();
                images[i].Add(render);

                visus[i].clearSimulation();

            }
        }

    }
}
