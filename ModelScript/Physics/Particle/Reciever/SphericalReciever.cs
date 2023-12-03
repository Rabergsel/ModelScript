using ModelScript.Graphs.Graph2D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Physics.Particle.Reciever
{
    public class SphericalReciever : RecieverBase
    {
        public float radius = 1f;
        public bool logarithmic = false;


        public override void listen(float time, List<ParticleBase> particles)
        {
           
            float value = 0f;
            if (logarithmic) value = 1e-100f;

            foreach(var p in particles)
            {
                if(distanceToParticle(p) < radius)
                {
                    value += p.attributes[attribute];
                }
            }
            //if (logarithmic) value = (float)Math.Log(value, 10);
          
            visualization.addValue(time, (float)(Math.Log10(value + 0.0000001)));
        }

    }
}
