
using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Objects
{
    public abstract class ObjectBase
    {
        public abstract void reflectParticle(ref Particle.ParticleBase particle);
        public abstract bool isColliding(Vector3D vector);

    }
}
