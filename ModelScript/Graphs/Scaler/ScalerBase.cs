using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Graphs.Scaler
{
    public abstract class ScalerBase
    {
        public abstract float scale(float value, float min, float max);
    }
}
