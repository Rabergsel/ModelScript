using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle.Emitter
{
    public abstract class EmitterBase
    {
        private Vector3D position;

        public abstract List<ParticleBase> emit();

    }
}
