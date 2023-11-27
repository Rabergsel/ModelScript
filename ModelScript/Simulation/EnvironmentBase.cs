using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelScript.Physics;
using ModelScript.Physics.Particle;
using ModelScript.Physics.Particle.Emitter;
using ModelScript.Graphs.SimuGraphs;

namespace ModelScript.Simulation
{
    public abstract class EnvironmentBase
    {

       float time;

        List<SimulationGraphFrame> visus = new List<SimulationGraphFrame>();

       internal List<ParticleBase> particles = new List<ParticleBase>();
       internal List<EmitterBase> emitters = new List<EmitterBase> ();
        public abstract void run(float timespan, float timestep);

        internal abstract void updateParticles(float time, float timestep);
        internal abstract void updateEmitters(float time, float timestep);


    }
}
