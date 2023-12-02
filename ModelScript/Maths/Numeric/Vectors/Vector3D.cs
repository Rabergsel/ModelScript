namespace ModelScript.Maths.Numeric.Vectors
{
    public class Vector3D
    {
        public float x;
        public float y;
        public float z;

        public float Length
        {
            get
            {
                return (float)Math.Sqrt(x * x + y * y + z * z);
            }
        }

        public Vector3D(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public static Vector3D operator +(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
        }

        public static Vector3D operator -(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
        }

        public static Vector3D operator *(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x * v2.x, v1.y * v2.y, v1.z * v2.z);
        }

        public static Vector3D operator /(Vector3D v1, Vector3D v2)
        {
            return new Vector3D(v1.x / v2.x, v1.y / v2.y, v1.z / v2.z);
        }

        public static Vector3D operator *(Vector3D v1, float v2)
        {
            return new Vector3D(v1.x * v2, v1.y * v2, v1.z * v2);
        }

        public static Vector3D operator /(Vector3D v1, float v2)
        {
            return new Vector3D(v1.x / v2, v1.y / v2, v1.z / v2);
        }

        public override string ToString()
        {
            return String.Format("({0}|{1}|{2})", x, y, z);
        }


    }
}
