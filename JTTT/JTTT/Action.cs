using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Action : IAction
    {
        public int Id { get; set; }

        public Action()
        {

        }

        public virtual void Job(Parameters _parameters)
        {
            //send mail or show image or something else
        }
    }
}
