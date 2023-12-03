using ModelScript.Graphs;
using ModelScript.Maths.Numeric.Vectors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelScript.Graphs.Graph2D;

namespace ModelScript.Physics.Particle.Reciever
{
    public  abstract class RecieverBase
    {
        public Vector3D position;
        public int group;
        public string attribute;
        public Graph2DBase visualization;

        public float distanceToParticle(ParticleBase particle)
        {
            return (position-particle.position).Length;
        }

        public abstract void listen(float time, List<ParticleBase> particles);

    }
}
