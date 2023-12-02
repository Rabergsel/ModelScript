
using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle.Emitter
{
    public class Circle2DEmitter : EmitterBase
    {
        public float amount = 3;
        public int activations = 2;
        public float speed = 1f;

        public Vector3D position = new Vector3D(0, 0, 0);

        private int actualEmissions = 0;

        public ParticleBase particle = new ParticleBase(0, new Vector3D(0, 0, 0), new Vector3D(0, 0, 0));

        public int group = 0;

        public override List<ParticleBase> emit()
        {

            if (actualEmissions < activations)
            {
                List<ParticleBase> parts = new List<ParticleBase>();

                for (float i = 0; i <= amount; i++)
                {
                    var velocity = new Vector3D(i * (1 / amount), (float)Math.Sqrt(1 - Math.Pow(i * (1 / amount), 2)), 0);
                    var velocity2 = new Vector3D(velocity.x, -velocity.y, 0);
                    var velocity3 = new Vector3D(-velocity.x, velocity.y, 0);
                    var velocity4 = new Vector3D(-velocity.x, -velocity.y, 0);

                    particle.position = position;
                    particle.velocity = velocity * speed;
                    parts.Add(particle);
                    particle.velocity = velocity2 * speed;
                    parts.Add(particle);
                    particle.velocity = velocity3 * speed;
                    parts.Add(particle);
                    particle.velocity = velocity4 * speed;
                    parts.Add(particle);

                }
                actualEmissions++;
                return parts;
            }

            return new List<ParticleBase>();

        }

    }
}
