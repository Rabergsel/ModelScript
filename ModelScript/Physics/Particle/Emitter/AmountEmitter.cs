using ModelScript.Maths.Numeric.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Physics.Particle.Emitter
{
    public class AmountEmitter : EmitterBase
    {

        int hasEmitted = 0;
        public int amount = 2;

        public Vector3D position = new Vector3D(0, 0, 0);
        public Vector3D vector = new Vector3D(0, 0, 0);

        int group = 0;

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
