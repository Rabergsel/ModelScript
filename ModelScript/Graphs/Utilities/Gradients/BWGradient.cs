namespace ModelScript.Graphs.Utilities.Gradients
{
    public class BWGradient : GradientBase
    {

        public override Tuple<int, int, int> getRGB(float value)
        {
            return new Tuple<int, int, int>((int)(value * 255), (int)(value * 255), (int)(value * 255));
        }

    }
}
