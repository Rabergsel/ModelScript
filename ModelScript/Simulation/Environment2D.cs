using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Simulation
{
    internal class Environment2D : EnvironmentBase
    {

        public override void run(float timespan, float timestep)
        {
            for(float t = 0; t < timespan; t+=timestep)
            {

            }
        }

        internal override void updateEmitters(float time, float timestep)
        {
            foreach(var emitter in emitters)
            {
                var newParticles = emitter.emit();
                foreach(var particle in newParticles)
                {
                    particles.Add(particle);
                }
            }
        }

        internal override void updateParticles(float time, float timestep)
        {
            throw new NotImplementedException();
        }

        private void particleFilter()
        {
            for(int i = 0; i < particles.Count; i++)
            {
                if (particles[i].position.z != 0) particles.RemoveAt(i);
            }
        }

    }
}
