using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Serialize
    {
        public string JsonSerialize(ListofTasks listofTasks)
        {
            string output = JsonConvert.SerializeObject(listofTasks);
            Console.WriteLine(output);

            return output;
        }
    }
}
