using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Log //:ILog
    {
        public Log(Task task)
        {
            using (StreamWriter sw = System.IO.File.AppendText("log.txt"))
            {
                sw.WriteLine(task.Time.time + "   " + task.Parameters.ToString());
            }
        }
    }
}
