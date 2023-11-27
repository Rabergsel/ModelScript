using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelScript.Physics.Particle;
using ModelScript.Physics.Particle.Emitter;
namespace ModelScript.Graphs.SimuGraphs
{
    public abstract class SimulationGraphBase : GraphBase
    {
        internal List<ParticleBase> particleList;
        internal List<EmitterBase> emitterList;

        public  void loadSimulationState(List<ParticleBase> particles, List<EmitterBase> emitters)
        {
            particleList = particles;
            emitterList = emitters;
        }

    }
}
