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
        private DateTime Date { get; set; }
        private string Key { get; set; }
        private string Url { get; set; }
        private string Mail { get; set; }

        public Log(string key, string url, string mail)
        {
            Date = DateTime.Now;
            Key = key;
            Url = url;
            Mail = mail;
        }

        public void Save(string name)
        {
            using (StreamWriter sw = File.AppendText(name))
            {
                sw.WriteLine(Date.ToString() + "  " + Key + "  " + Url + "  " + Mail + Environment.NewLine);
            }
        }

        public void Show()
        {
            Console.WriteLine(Date.ToString() + "  " + Key + "  " + Url + "  " + Mail);
        }
    }
}
