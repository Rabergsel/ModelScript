using ModelScript.Maths.Numeric.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Physics.Particle.Emitter
{
     public abstract class EmitterBase
    {
        Vector3D position;

        public abstract List<ParticleBase> emit();

    }
}
