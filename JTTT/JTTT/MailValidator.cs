﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class MailValidator
    {
        public bool isValid(Mail mail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(mail.address);
                return addr.Address == mail.address;
            }
            catch
            {
                return false;
            }
        }
    }
}