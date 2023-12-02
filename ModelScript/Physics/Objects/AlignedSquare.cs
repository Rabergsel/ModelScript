using ModelScript.Maths.Numeric.Vectors;
using ModelScript.Physics.Particle;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Physics.Objects
{
    public class AlignedSquare : ObjectBase
    {
        List<AlignedPlane> planes = new List<AlignedPlane>();


        public AlignedSquare(float x, float y, float width, float height)
        {

            planes.Clear();
            planes.Add(new AlignedPlane(new Vector3D(x, y, float.MinValue), new Vector3D(x + width, y, float.MaxValue)));
            planes.Add(new AlignedPlane(new Vector3D(x, y, float.MinValue), new Vector3D(x, y + height, float.MaxValue)));
            planes.Add(new AlignedPlane(new Vector3D(x + width, y, float.MinValue), new Vector3D(x + width, y + height, float.MaxValue)));
            planes.Add(new AlignedPlane(new Vector3D(x, y + height, float.MinValue), new Vector3D(x + width, y + height, float.MaxValue)));
        }

        public override bool isColliding(Vector3D position, Vector3D vector)
        {
            return planes[0].isColliding(position, vector) |
                planes[1].isColliding(position, vector) |
                planes[2].isColliding(position, vector) |
                planes[3].isColliding(position, vector);
        }

        public override bool reflectParticle(ParticleBase particle, float deltaT, out Vector3D collisionPos, out Vector3D remainingWay, out Vector3D newVelocity)
        {
            if (planes[0].reflectParticle(particle, deltaT, out collisionPos, out remainingWay, out newVelocity)) return true;
            if (planes[1].reflectParticle(particle, deltaT, out collisionPos, out remainingWay, out newVelocity)) return true;
            if (planes[2].reflectParticle(particle, deltaT, out collisionPos, out remainingWay, out newVelocity)) return true;
            if (planes[3].reflectParticle(particle, deltaT, out collisionPos, out remainingWay, out newVelocity)) return true;

            return false;

        }

        public override void visualize(string alignment, ref SKCanvas canvas, int width, int height, PointF minCoord, PointF maxCoord)
        {
            foreach(var plane in planes)
            {
                plane.visualize(alignment, ref canvas, width, height, minCoord, maxCoord);
            }
        }

    }
}
