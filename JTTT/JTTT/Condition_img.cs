using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Condition_img: Condition
    {
        public Condition_img(Key key, Url url) : base(key, url)
        {
            Key = key;
            Url = url;
        }
        public override bool Check(string option)
        {
            return true;
        }

        public override string ToString()
        {
            return "Check image description";
        }
    }
}
