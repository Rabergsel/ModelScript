using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs.Utilities.Gradients
{
    public class BRGradient : GradientBase
    {

        byte alpha = 128;


        public BRGradient(byte alpha)
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
            return new Tuple<int, int, int, int>((int)(value * 255), 0, 0, alpha);
        }

    }
}
