
using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle.Emitter
{
    public class Circle2DEmitter : EmitterBase
    {
        public float amount = 3;
        public int activations = 2;
        public float speed = 1f;

        public Vector3D position;

        private int actualEmissions = 0;

        public int group = 0;

        public float maxNoise = 0.01f;


        public override List<ParticleBase> emit()
        {

            if (actualEmissions < activations)
            {
                List<ParticleBase> parts = new List<ParticleBase>();

                for (float i = 0; i <= amount; i++)
                {
                    float noise = (float)(new Random().NextDouble()) * maxNoise;
                    var velocity1 = new Vector3D((i + noise) * (1 / amount), (float)Math.Sqrt(1 - Math.Pow((i + noise) * (1 / amount), 2)), 0);
                    var velocity2 = new Vector3D(velocity1.x, -velocity1.y, 0);
                    var velocity3 = new Vector3D(-velocity1.x, velocity1.y, 0);
                    var velocity4 = new Vector3D(-velocity1.x, -velocity1.y, 0);

                    var paricle1 = new ParticleBase(group, position, velocity1 * speed);
                    var paricle2 = new ParticleBase(group, position, velocity2 * speed);
                    var paricle3 = new ParticleBase(group, position, velocity3 * speed);
                    var paricle4 = new ParticleBase(group, position, velocity4 * speed);

                    parts.Add(paricle1);
                    parts.Add(paricle2);
                    parts.Add(paricle3);
                    parts.Add(paricle4);

                }
                actualEmissions++;
                return parts;
            }

            return new List<ParticleBase>();

        }

    }
}
