﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Action : IAction
    {
        public Mail Mail;
        protected string fromMail = "amadi@scz.pl";

        public Action(Mail mail)
        {
            //  Mail = mail;
        }
        public virtual void Job()
        {
            //send mail or something
        }
    }
}
