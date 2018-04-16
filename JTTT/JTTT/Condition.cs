using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Condition : ICondition
    {
        public int Id { get; set; }

        public Condition() { }

        public virtual bool Check(Parameters _parameters)
        {
            return false; // checks if there is condition in the bracket
        }

    }
}
