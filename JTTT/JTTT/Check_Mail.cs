using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Check_Mail: ICondition
    {
        private string Key { get; set; }
        private string Url { get; set; }
        private string Mail { get; set; }

        public Check_Mail(string key, string url, string mail)
        {
            Key = key;
            Url = url;
            Mail = mail;
        }

        public void Check(string option)
        {
            // checks if there is key on the site, downloads image from site
        }

        public void Job(string option)
        {
            // send message on the mail and attaches the image
        }
    }
}
