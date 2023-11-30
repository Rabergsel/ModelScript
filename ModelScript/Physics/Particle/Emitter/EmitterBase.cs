using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle.Emitter
{
    public abstract class EmitterBase
    {
        Vector3D position;

        public abstract List<ParticleBase> emit();

    }
}
