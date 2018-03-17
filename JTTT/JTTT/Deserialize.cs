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
            ListofTasks listofTasks = new ListofTasks();
            listofTasks = JsonConvert.DeserializeObject<ListofTasks>(input);

            return listofTasks;
        }
    }
}
