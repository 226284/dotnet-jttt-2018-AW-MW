using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Key
    {
        //public int Id { get; set; }
        public string Name { get; set; }

        public Key() { }
        public Key(string name)
        {
            Name = name;
        }
    }
}
