using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Action_img: Action
    {
        public Action_img(Mail mail) : base(mail)
        {
            Mail = mail;
        }

        public virtual void Job(string option)
        {
            // checks if there is key on the site, downloads image from site
        }

        public override string ToString()
        {
            return "Check img description";
        }
    }
}
