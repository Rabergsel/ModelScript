
using ModelScript.Maths.Numeric.Vectors;
using SkiaSharp;
using System.Drawing;

namespace ModelScript.Physics.Objects
{
    public abstract class ObjectBase
    {
        /// <summary>
        /// Calculates a reflection of a particle
        /// </summary>
        /// <param name="particle">The particle to reflect</param>
        /// <param name="deltaT">The timestep size</param>
        /// <param name="collisionPos">If colliding, this is the position where they collide. Null if not colliding</param>
        /// <param name="remainingWay">If colliding, this is the traveled vector since reflection. Null if not colliding</param>
        /// <returns>Whether the particle was reflected or not.</returns>
        public abstract bool reflectParticle(Particle.ParticleBase particle, float deltaT, out Vector3D collisionPos, out Vector3D remainingWay, out Vector3D newVelocity);
        public abstract bool isColliding(Vector3D position, Vector3D vector);

        public abstract void visualize(string alignment, ref SKCanvas canvas, int width, int height, PointF minCoord, PointF maxCoord);

    }
}
