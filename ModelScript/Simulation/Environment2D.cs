namespace ModelScript.Simulation
{
    public class Environment2D : EnvironmentBase
    {

        public override void run(float timespan, float timestep)
        {
            for (float t = 0; t < timespan; t += timestep)
            {
                time = t;
                updateEmitters(t, timestep);
                updateParticles(t, timestep);
                renderVisus();
                Console.WriteLine("t = {0}\t#part = {1}", time, particles.Count);
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

            foreach (var particle in particles)
            {
                particle.move(particle.deltaPosition(timestep));
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
