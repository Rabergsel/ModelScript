using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs.Utilities.Gradients
{
    public abstract class GradientBase
    {
        public abstract Tuple<int, int, int> getRGB(float value);
        public Tuple<int, int, int> getClampedRGB(float value, float min, float max)
        {
            return getRGB((value-min)/(max-min));
        }

    }
}
