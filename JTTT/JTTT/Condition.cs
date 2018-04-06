using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Condition : ICondition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Key Key { get; set; }
        public Url Url { get; set; }

        public Condition(Key key, Url url)
        {
            Key = key;
            Url = url;
        }

        public virtual bool Check(string option)
        {
            return false;// checks if there is key on the site, downloads image from site
        }

    }
}
