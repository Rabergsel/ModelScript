﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Objects
{
    public abstract class ObjectBase
    {
        public abstract void reflectParticle(ref Particle.ParticleBase particle);
        public abstract bool isColliding(Vector3D vector);

    }
}
