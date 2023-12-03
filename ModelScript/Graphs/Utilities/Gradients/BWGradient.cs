﻿namespace ModelScript.Graphs.Utilities.Gradients
{
    public class BWGradient : GradientBase
    {
        private byte alpha = 128;


        public BWGradient(byte alpha)
        {
            this.alpha = alpha;
        }

        /// <summary>
        /// Returns RGB value for a specific value between 0 and 1
        /// </summary>
        /// <param name="value"></param>
        /// <returns>A Tuple with the values R, G, B, A</returns>
        public override Tuple<int, int, int, int> getRGB(float value)
        {
            return new Tuple<int, int, int, int>((int)(value * 255), (int)(value * 255), (int)(value * 255), alpha);
        }

    }
}
