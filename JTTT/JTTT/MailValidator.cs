using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTTT
{
    class MailValidator
    {
        public bool isValid(Mail mail)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(mail.Address);
                return addr.Address == mail.Address;
            }
            catch
            {
                MessageBox.Show("E-mail address is incorrect","Error");
                return false;
            }
        }
    }
}
