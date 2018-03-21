using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTTT
{
    class UrlValidator
    {
        public bool isValid(Url url)
        {
            try
            {
                return Uri.IsWellFormedUriString(url.address, UriKind.Absolute);
            }
            catch
            {
                MessageBox.Show("URL adress is incorrect","Error");
                return false;
            }
        }
    }
}
