using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JTTT
{
    //  [Table("Condition_imgs")]
    class Condition_img : Condition
    {
        public Condition_img()
        {

        }

        public override bool Check(Parameters parameters)
        {
            WebClient client = new WebClient();
            var reply = client.DownloadString(parameters.Url.Address);

            var web = new HtmlWeb();
            var doc = web.Load(parameters.Url.Address);


            var nodes = doc.DocumentNode.Descendants("img");

            foreach (var i in nodes)
            {
                if (i.GetAttributeValue("alt", "").ToLower().Contains(parameters.Key.Name.ToLower()))
                {
                    string path = @"img.jpg";
                    using (var client2 = new WebClient())
                    {
                        client.DownloadFile(i.GetAttributeValue("src", ""), path);
                    }
                    break;
                    //return true; //poprawić!
                }
            }
            //MessageBox.Show("No img found on this site", "Warning");
            //return false;
            return true;
        }

        public override string ToString()
        {
            return "Check image description";
        }
    }
}
