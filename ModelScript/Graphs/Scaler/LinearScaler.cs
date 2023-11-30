namespace ModelScript.Graphs.Scaler
{
    internal class LinearScaler : ScalerBase
    {

        public override float scale(float value, float min, float max)
        {
            return (value - min) / (max - min);
        }

    }
}
