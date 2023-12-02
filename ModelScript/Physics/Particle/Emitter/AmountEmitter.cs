using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle.Emitter
{
    public class AmountEmitter : EmitterBase
    {
        private int hasEmitted = 0;
        public int amount = 2;

        public Vector3D position = new Vector3D(0, 0, 0);
        public Vector3D vector = new Vector3D(0, 0, 0);
        private int group = 0;

        public override List<ParticleBase> emit()
        {
            if (hasEmitted < amount)
            {
                hasEmitted++;
                return new List<ParticleBase>()
            {
                new ParticleBase(group, position, vector)
            };
            }
            else
            {
                return new List<ParticleBase>();
            }
        }

    }
}
