
using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Physics.Particle
{
    public class ParticleBase
    {
        private int group = 0;
        public Dictionary<string, float> attributes = new Dictionary<string, float>();

        public Vector3D position;
        public Vector3D velocity;

        public ParticleBase(int group, Vector3D position, Vector3D velocity)
        {
            this.group = group;
            this.position = position;
            this.velocity = velocity;
        }

        public Vector3D deltaPosition(float seconds)
        {
            return (velocity * seconds);
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
