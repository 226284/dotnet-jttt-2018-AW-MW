using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    public class Log
    {
        public string date = "01-01-2000";
        public string word = "none";
        public string url = "http://demotywatory.pl";
        public string mail = "wiemichal@wp.pl";

        public Log(string d, string w, string u, string m)
        {
            date = d;
            word = w;
            url = u;
            mail = m;
        }

        public void add()
        {
            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                sw.WriteLine(date.ToString() + "  " + word + "  " + url + "  " + mail + Environment.NewLine);
            }
        }

        public void fail_url(string u)
        {
            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                sw.WriteLine(date.ToString() + "  Wrong URL:  " + u + Environment.NewLine);
            }
        }

        public void fail_mail(string m)
        {
            using (StreamWriter sw = File.AppendText("log.txt"))
            {
                sw.WriteLine(date.ToString() + "  Wrong URL:  " + m + Environment.NewLine);
            }
        }
    }
}
