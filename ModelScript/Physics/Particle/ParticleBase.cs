using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle
{
    public class ParticleBase
    {
        int group = 0;
        public Dictionary<string, float> attributes = new Dictionary<string, float>();

        Vector3D position;
        Vector3D velocity;

        public ParticleBase(int group, Vector3D position, Vector3D velocity)
        {
            this.group = group;
            this.position = position;
            this.velocity = velocity;
        }

        public Vector3D deltaPosition(float seconds)
        {
            return position + (velocity* seconds);
        }

        public void move(Vector3D delta)
        {
            position += delta;
        }

        public virtual void onTimestep(float t, float deltaT)
        {
            move(deltaPosition(deltaT));
        }


    }
}
