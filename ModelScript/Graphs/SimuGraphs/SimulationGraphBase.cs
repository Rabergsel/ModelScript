using ModelScript.Physics.Objects;
using ModelScript.Physics.Particle;
using ModelScript.Physics.Particle.Emitter;
namespace ModelScript.Graphs.SimuGraphs
{
    public abstract class SimulationGraphBase : GraphBase
    {
        internal List<ParticleBase> particleList = new List<ParticleBase>();
        internal List<EmitterBase> emitterList = new List<EmitterBase>();
        internal List<ObjectBase> objectList = new List<ObjectBase>();

        public void loadSimulationState(List<ParticleBase> particles, List<EmitterBase> emitters, List<ObjectBase> objects)
        {
            particleList.AddRange(particles.ToArray());
            emitterList.AddRange(emitters.ToArray());
            objectList.AddRange(objects.ToArray());
        }

        public void clearSimulationState()
        {
            objectList.Clear();
            particleList.Clear();
            emitterList.Clear();

        }

    }
}
