using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs.Scaler
{
    internal class LinearScaler : ScalerBase
    {

        public override float scale(float value, float min, float max)
        {
            return (value-min)/(max - min);
        }

    }
}
