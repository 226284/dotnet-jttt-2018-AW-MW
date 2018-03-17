using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Deserialize
    {
        public ListofTasks JsonDeserialize(string input)
        {
            Console.WriteLine(input);
            return JsonConvert.DeserializeObject<ListofTasks>(input);
        }
    }
}
