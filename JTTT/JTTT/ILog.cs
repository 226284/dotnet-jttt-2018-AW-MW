using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    interface ILog
    {
        void Save(string name);
        void Show();
    }
}
