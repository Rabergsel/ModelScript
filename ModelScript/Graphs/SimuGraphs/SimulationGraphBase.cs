using ModelScript.Physics.Objects;
using ModelScript.Physics.Particle;
using ModelScript.Physics.Particle.Emitter;
namespace ModelScript.Graphs.SimuGraphs
{
    public abstract class SimulationGraphBase : GraphBase
    {
        internal List<ParticleBase> particleList;
        internal List<EmitterBase> emitterList;
        internal List<ObjectBase> objectList;

        public void loadSimulationState(List<ParticleBase> particles, List<EmitterBase> emitters, List<ObjectBase> objects)
        {
            particleList = particles;
            emitterList = emitters;
            objectList = objects;
        }

    }
}
