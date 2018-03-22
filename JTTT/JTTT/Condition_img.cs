using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace JTTT
{
    class Condition_img : Condition
    {
        public Condition_img(Key key, Url url) : base(key, url)
        {
            Key = key;
            Url = url;
        }
        public override bool Check(string option)
        {
            WebClient client = new WebClient();
            var reply = client.DownloadString(Url.address);

            var web = new HtmlWeb();
            var doc = web.Load(Url.address);


            var nodes = doc.DocumentNode.Descendants("img");

            foreach (var i in nodes)
            {
                if (i.GetAttributeValue("alt", "").ToLower().Contains(Key.Name.ToLower()))
                {
                    string path = @"img.jpg";
                    using (var client2 = new WebClient())
                    {
                        client.DownloadFile(i.GetAttributeValue("src", ""), path);
                    }

                    break;
                }
            }
            return true;
        }

        public override string ToString()
        {
            return "Check image description";
        }
    }
}
