namespace ModelScript.Maths.Numeric.Matrices
{
    public class Matrix
    {

        public float[,] values;

        public int width { get { return values.GetLength(1); } }
        public int height { get { return values.GetLength(0); } }


        public Matrix(float[,] values)
        {
            this.values = values;
        }

        public Matrix(int x, int y)
        {
            values = new float[y, x];

            for (int xt = 0; xt < x; xt++)
            {
                for (int yt = 0; yt < y; yt++)
                {
                    values[xt, yt] = 0;
                }
            }

        }

        public float getValue(int x, int y)
        {
            return values[y, x];
        }


        public void setValue(int x, int y, float value)
        {
            values[y, x] = value;
        }

        public float getValueClamped(float x, float y, float minX, float maxX, float minY, float maxY)
        {
            int indexX = (int)((x - minX) / (maxX - minX)) * values.GetLength(0);
            int indexY = (int)((y - minY) / (maxY - minY)) * values.GetLength(1);

            return values[indexY, indexX];
        }


    }
}
