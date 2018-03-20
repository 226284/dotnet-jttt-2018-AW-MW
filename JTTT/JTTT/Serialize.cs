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
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            string output = JsonConvert.SerializeObject(listofTasks, settings);
            Console.WriteLine(output);

            return output;
        }
    }
}
