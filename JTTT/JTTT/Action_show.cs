using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Windows.Media.Imaging;

namespace JTTT
{
    class Action_show : Action
    {
        public Action_show()
        {

        }

        public override void Job(Parameters parameters)
        {
            BitmapImage bi = new BitmapImage();
            bi.BeginInit();
            bi.UriSource = new Uri(System.IO.Directory.GetCurrentDirectory() + "/tmp/img" + parameters.Id + ".jpg");
            bi.CacheOption = BitmapCacheOption.OnLoad;
            bi.EndInit();

            ShowWindow showWindow = new ShowWindow();

            showWindow.ShowText.Text = parameters.Description;
            showWindow.ShowImg.Source = bi;
            showWindow.Show();
        }

        public override string ToString()
        {
            return "Show image";
        }
    }
}
