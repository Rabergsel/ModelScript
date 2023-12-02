using ModelScript.Maths.Numeric.Vectors;
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

        public Vector3D minPoint = new Vector3D(float.MaxValue, float.MaxValue, float.MaxValue);
        public Vector3D maxPoint = new Vector3D(float.MinValue, float.MinValue, float.MinValue);

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

        public void evaluateParticleBoundaries()
        {
            foreach(var p in particleList)
            {
                if (p.position.x < minPoint.x) minPoint.x = p.position.x;
                if (p.position.y < minPoint.y) minPoint.y = p.position.y;
                if (p.position.z < minPoint.z) minPoint.z = p.position.z;

                if (p.position.x > maxPoint.x) maxPoint.x = p.position.x;
                if (p.position.y > maxPoint.y) maxPoint.y = p.position.y;
                if (p.position.z > maxPoint.z) maxPoint.z = p.position.z;
            }
        }





    }
}
