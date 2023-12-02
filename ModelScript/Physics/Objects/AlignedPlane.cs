using ModelScript.Graphs.Scaler;
using ModelScript.Maths.Numeric.Vectors;
using ModelScript.Physics.Particle;
using SkiaSharp;
using System.Drawing;

namespace ModelScript.Physics.Objects
{
    public class AlignedPlane : ObjectBase
    {
        public Vector3D minPoint = new Vector3D(0, 0, 0);
        public Vector3D maxPoint = new Vector3D(0, 0, 0);
        private string alignment = "a";

        public AlignedPlane(Vector3D minPoint, Vector3D maxPoint)
        {
            var min = new Vector3D(Math.Min(minPoint.x, maxPoint.x),
                Math.Min(minPoint.y, maxPoint.y),
                Math.Min(minPoint.z, maxPoint.z));

            var max = new Vector3D(
                Math.Max(minPoint.x, maxPoint.x),
                Math.Max(minPoint.y, maxPoint.y),
                Math.Max(minPoint.z, maxPoint.z));

            this.minPoint = min;
            this.maxPoint = max;

            if (minPoint.x == maxPoint.x)
            {
                alignment = "x";
            }

            if (minPoint.y == maxPoint.y)
            {
                alignment = "y";
            }

            if (minPoint.z == maxPoint.z)
            {
                alignment = "z";
            }

            if (alignment == "a")
            {
                throw new Exception("No aligned plane can be generated with those coordinates.");
            }
        }

        public override bool isColliding(Vector3D position, Vector3D vector)
        {
            var diff = 0f;

            if (alignment == "x")
            {
                diff = minPoint.x - position.x;
                //Console.WriteLine("diff = {0}\tvector = {1}", diff, vector.x);
                if (diff > Math.Abs(vector.x))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (alignment == "y")
            {
                diff = minPoint.y - position.y;
                if (diff > vector.y)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            if (alignment == "z")
            {
                diff = minPoint.z - position.z;

                if (diff > vector.z)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }

            throw new Exception("Invalid alignment of plane");

        }

        public override bool reflectParticle(ParticleBase particle, float deltaT, out Vector3D collisionPos, out Vector3D remainingWay, out Vector3D newVelocity)
        {

            var travel = particle.velocity * deltaT;

            collisionPos = null;
            remainingWay = null;
            newVelocity = null;

            float diff = 0f;
            float part = 1f;

            if (alignment == "x") { diff = minPoint.x - particle.position.x; part = diff / travel.x; }
            if (alignment == "y") { diff = minPoint.y - particle.position.y; part = diff / travel.y; }
            if (alignment == "z") { diff = minPoint.z - particle.position.z; part = diff / travel.z; }

            part = Math.Abs(part);

            if (part < 0 | part > 1)
            {

                collisionPos = null;
                remainingWay = null;
                newVelocity = null;
                return false;
            }
            //Console.WriteLine("Reflecting: diff = {0}\tpart = {1}", diff, part);

            collisionPos = particle.position + (travel * part);

            if (alignment == "x" & !isWithinBounds(collisionPos.y, minPoint.y, maxPoint.y, "y") | !isWithinBounds(collisionPos.z, minPoint.z, maxPoint.z, "z"))
            {
                return false;
            }

            if (alignment == "y" & !isWithinBounds(collisionPos.x, minPoint.x, maxPoint.x, "x") | !isWithinBounds(collisionPos.z, minPoint.z, maxPoint.z, "z"))
            {
                return false;
            }

            if (alignment == "z" & !isWithinBounds(collisionPos.x, minPoint.x, maxPoint.x, "x") | !isWithinBounds(collisionPos.y, minPoint.y, maxPoint.y, "y"))
            {
                return false;
            }

            if (alignment == "x") { particle.velocity.x = particle.velocity.x * -1; }
            if (alignment == "y") { particle.velocity.y = particle.velocity.y * -1; }
            if (alignment == "z") { particle.velocity.z = particle.velocity.z * -1; }

            newVelocity = particle.velocity;

            remainingWay = (particle.velocity * (1 - part));

            particle.position = collisionPos + remainingWay;

            return true;

        }

        private bool isWithinBounds(float value, float min, float max, string debuginfo = "")
        {
            //Console.WriteLine("Checking {4} {0}<{1}<{2} = {3}", min, value, max, (value >= min) & (value <= max), debuginfo);
            return (value >= min) & (value <= max);
        }

        public override void visualize(string alignment, ref SKCanvas canvas, int width, int height, PointF minCoord, PointF maxCoord)
        {
            var scaler = new LinearScaler();

            if (this.alignment == "x" & alignment == "XY")
            {
                var coordX = width * scaler.scale(minPoint.x, minCoord.X, maxCoord.X);

                var coordY1 = height * scaler.scale(minPoint.y, minCoord.Y, maxCoord.Y);
                var coordY2 = height * scaler.scale(maxPoint.y, minCoord.Y, maxCoord.Y);

                // Console.WriteLine("Plane: Simu Coords {3}|{4} --> {5}|{6}   Visu Coords =  {0}|{1} --> {0}|{2}", coordX, coordY1, coordY2, minCoord.X, minCoord.Y, maxCoord.X, maxCoord.Y);

                using (SKPaint skPaint = new SKPaint())
                {
                    skPaint.Style = SKPaintStyle.Stroke;
                    skPaint.IsAntialias = true;
                    skPaint.Color = SKColors.Blue;
                    skPaint.StrokeWidth = 5;
                    skPaint.StrokeCap = SKStrokeCap.Round;
                    canvas.DrawLine(coordX, coordY1, coordX, coordY2, skPaint);

                }
            }

            if (this.alignment == "y" & alignment == "XY")
            {
                var coordX1 = width * scaler.scale(minPoint.x, minCoord.X, maxCoord.X);
                var coordX2 = width * scaler.scale(maxPoint.x, minCoord.X, maxCoord.X);

                var coordY = height - (height * scaler.scale(minPoint.y, minCoord.Y, maxCoord.Y));

                // Console.WriteLine("Plane: Simu Coords {3}|{4} --> {5}|{6}   Visu Coords =  {0}|{1} --> {0}|{2}", coordX, coordY1, coordY2, minCoord.X, minCoord.Y, maxCoord.X, maxCoord.Y);

                using (SKPaint skPaint = new SKPaint())
                {
                    skPaint.Style = SKPaintStyle.Stroke;
                    skPaint.IsAntialias = true;
                    skPaint.Color = SKColors.Blue;
                    skPaint.StrokeWidth = 5;
                    skPaint.StrokeCap = SKStrokeCap.Round;
                    canvas.DrawLine(coordX1, coordY, coordX2, coordY, skPaint);

                }
            }
        }

    }
}
