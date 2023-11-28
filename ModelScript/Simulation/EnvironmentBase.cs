using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelScript.Physics;
using ModelScript.Physics.Particle;
using ModelScript.Physics.Particle.Emitter;
using ModelScript.Graphs.SimuGraphs;
using SkiaSharp;

namespace ModelScript.Simulation
{
    public abstract class EnvironmentBase
    {

       public float time;

       public List<SimulationGraphFrame> visus = new List<SimulationGraphFrame>();

       public List<ParticleBase> particles = new List<ParticleBase>();
       public List<EmitterBase> emitters = new List<EmitterBase> ();

        public abstract void run(float timespan, float timestep);

        internal abstract void updateParticles(float time, float timestep);
        internal abstract void updateEmitters(float time, float timestep);

        public List<List<SKImage>> images = new List<List<SKImage>>();

        internal void renderVisus()
        {
            for(int i = 0; i < visus.Count; i++)
            {
                if (images.Count <= i) images.Add(new List<SKImage>());
                visus[i].loadSimulation(time, particles, emitters);
                images[i].Add(visus[i].render());
            }
        }

    }
}
