using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle.Emitter
{
    public class RailgunEmitter : EmitterBase
    {
        public Vector3D position = new Vector3D(0, 0, 0);
        public Vector3D vector = new Vector3D(0, 0, 0);

        int group = 0;

        public override List<ParticleBase> emit()
        {
            return new List<ParticleBase>()
            {
                new ParticleBase(group, position, vector)
            };
        }

    }
}
