
using ModelScript.Physics.Particle;

namespace ModelScript.Simulation.Calculators
{
    public abstract class CalculatorBase
    {
        public abstract void init(ref ParticleBase particle);
        public abstract void onTimestep(ref ParticleBase particle);

        public abstract void onEmission(ref ParticleBase particle, float t);
        public abstract void end(ref ParticleBase particle);


    }
}
