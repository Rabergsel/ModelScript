using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Physics.Particle
{
    public class SquareDeflatingParticle : ParticleBase
    {

        public float initialWay = 1f;
        public float initialAmplitude = 1f;

        private float way = 0f;

        public SquareDeflatingParticle(float initialWay, float initialAmplitude)
        {
            this.initialWay = initialWay;
            this.initialAmplitude = initialAmplitude;

            attributes.Add("amplitude", initialAmplitude);
        }

        public override void onTimestep(float t, float deltaT)
        {
            Console.Write("Pos before = {0}\t", position.ToString());

            var delta = deltaPosition(deltaT);
            way += delta.Length;
            attributes["amplitude"] = initialAmplitude / (float)Math.Pow(initialWay / (initialWay + way), 2);
            move(delta);

            Console.WriteLine("Pos after = {1}", position.ToString());
        }

    }
}
