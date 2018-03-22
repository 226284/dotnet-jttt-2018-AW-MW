using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
   public class Deserialize
    {
        public ListofTasks JsonDeserialize(string input)
        {
            ListofTasks listofTasks = new ListofTasks();
            JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
            listofTasks = JsonConvert.DeserializeObject<ListofTasks>(input, settings);

            return listofTasks;
        }
    }
}
