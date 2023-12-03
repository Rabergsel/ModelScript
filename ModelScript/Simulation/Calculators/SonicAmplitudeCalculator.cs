using ModelScript.Physics.Particle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Simulation.Calculators
{
    public class SonicAmplitudeCalculator : CalculatorBase
    {
        public float energy = 1f;
        public float frequency = 1f;
        public override void init(ref ParticleBase particle)
        {
            
        }

        public override void onEmission(ref ParticleBase particle, float t)
        {
            var e = energy * (float)Math.Sin(t * frequency);

            if (!particle.attributes.ContainsKey("sonicEnergy")) particle.attributes.Add("sonicEnergy", e);
        }

        public override void end(ref ParticleBase particle)
        {
            
        }

        public override void onTimestep(ref ParticleBase particle)
        {
           
        }

    }
}
