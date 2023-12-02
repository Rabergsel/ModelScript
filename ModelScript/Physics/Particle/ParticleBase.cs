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
            //Console.WriteLine("delta Pos = {0}\t dt = {1}", velocity * seconds, seconds);

            return (velocity * seconds);
        }

        public void move(Vector3D delta)
        {
            //Console.Write("Pos before: {0}\t delta = ", position.ToString(), delta.ToString());
            position += delta;
            //Console.WriteLine("Pos after: {0}", position.ToString());
        }

        public virtual void onTimestep(float t, float deltaT)
        {
            move(deltaPosition(deltaT));
        }




    }
}
