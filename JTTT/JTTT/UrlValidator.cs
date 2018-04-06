using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTTT
{
    public class UrlValidator
    {
        public bool isValid(Url url)
        {
            if (Uri.IsWellFormedUriString(url.Address, UriKind.Absolute))
            {
                return true;
            }
            MessageBox.Show("URL adress is incorrect", "Error");
            return false;
        }
    }
}
