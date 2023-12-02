using ModelScript.Maths.Numeric.Vectors;

namespace ModelScript.Simulation
{
    public class Environment2D : EnvironmentBase
    {

        public override void run(float timespan, float timestep)
        {
            var stopwatch = System.Diagnostics.Stopwatch.StartNew();
            for (float t = 0; t < timespan; t += timestep)
            {
                
                time = t;
                updateEmitters(t, timestep);
                updateParticles(t, timestep);
                renderVisus();
                try
                {
                    var eta = (1 - (t / timespan)) / (t / timespan) * stopwatch.Elapsed;
                    Console.WriteLine("t = {0}\t#part = {1}\tETA: {2}", time, particles.Count, eta);
                }
                catch
                {
                    Console.WriteLine("t = {0}\t#part = {1}", time, particles.Count);
                }
                
            }
        }

        internal override void updateEmitters(float time, float timestep)
        {
            foreach (var emitter in emitters)
            {
                var newParticles = emitter.emit();
                foreach (var particle in newParticles)
                {
                    particles.Add(particle);
                }
            }
        }

        internal override void updateParticles(float time, float timestep)
        {
            particleFilter();

            for (int i = 0; i < particles.Count; i++)
            {


                var particle = particles[i];



                bool collision = false;

                foreach (var obj in objects)
                {
                    Vector3D colPos;
                    Vector3D remain;
                    Vector3D newVelo;

                    if (obj.reflectParticle(particle, timestep, out colPos, out remain, out newVelo))
                    {
                        particles[i].velocity = newVelo;
                        particles[i].position = colPos + remain;

                        //Console.Write("Particle #{0}\t", i);
                        //Console.Write("Current Pos = {0}\t", particle.position.ToString());
                        //Console.Write("Current Vel = {0}\n", particle.velocity.ToString());
                        //Console.WriteLine("Collided; colPos = {0}\tremain = {1}\tnewVelo = {2}", colPos, remain, newVelo);
                        collision = true;
                        break;
                    }
                    else
                    {

                    }
                }

                if (!collision)
                {
                    //Console.WriteLine("No collision");
                    particles[i].move(particle.deltaPosition(timestep));
                }
            }
        }

        private void particleFilter()
        {
            for (int i = 0; i < particles.Count; i++)
            {
                if (particles[i].position.z != 0)
                {
                    particles.RemoveAt(i);
                }
            }
        }

    }
}
