using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelScript.Flow.Input
{
    public abstract class InputBase
    {

        public abstract void read();

        public abstract Dictionary<string, string> process();

    }
}
