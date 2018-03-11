using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Log :ILog
    {
        private DateTime date;
        private string key;
        private string url;
        private string mail;

        public Log(string k, string u, string m)
        {
            date = DateTime.Now;
            key = k;
            url = u;
            mail = m;
        }

        public void Save(string name)
        {
            using (StreamWriter sw = File.AppendText(name))
            {
                sw.WriteLine(date.ToString() + "  " + key + "  " + url + "  " + mail + Environment.NewLine);
            }
        }

        public void Show()
        {
            Console.WriteLine(date.ToString() + "  " + key + "  " + url + "  " + mail);
        }
    }
}
