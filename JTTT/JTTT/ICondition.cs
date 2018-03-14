using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    interface ICondition
    {
        // checks the option in the box
        void Check(string option);
        // do the job from the second box
        void Job(string option);
    }
}
