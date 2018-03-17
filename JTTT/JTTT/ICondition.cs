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
        bool Check(string option);
    }
}
