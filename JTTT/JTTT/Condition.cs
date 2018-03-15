using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Condition: ICondition
    {
        private Key Key = new Key();
        private Url Url = new Url();
     
        public Condition(Key key, Url url)
        {
            Key = key;
            Url = url;
        }

        public void Check(string option)
        {
            // checks if there is key on the site, downloads image from site
        }

    }
}
