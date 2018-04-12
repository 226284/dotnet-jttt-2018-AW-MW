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
        public ListofTask JsonDeserialize(string input)
        {
            ListofTask Tasks = new ListofTask();
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            Tasks = JsonConvert.DeserializeObject<ListofTask>(input, settings);

            return Tasks;
        }
    }
}
