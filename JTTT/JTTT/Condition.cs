using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Condition: ICondition
    {
        protected Key Key;// = new Key();
        protected Url Url;// = new Url();
     
        public Condition(Key key, Url url)
        {
            Key = key;
            Url = url;
        }
        
        public virtual void Check(string option)
        {
            // checks if there is key on the site, downloads image from site
        }

    }
}
