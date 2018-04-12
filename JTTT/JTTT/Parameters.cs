using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Parameters
    {
        public int Id { get; set; }
        // img - send parameters
        virtual public Url Url { get; set; }
        virtual public Key Key { get; set; }
        virtual public Mail Mail { get; set; }

        //public City City { get; set; }
        //public Temp Temp { get; set; }
        //public Parameters() { }
          
        public override string ToString()
        {
            return String.Format("Url: {0} Key: {1} Mail: {0}", Url, Key, Mail);
        }
    }
}
