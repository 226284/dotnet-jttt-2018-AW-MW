﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;
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

        public async override Task<bool> Check(Parameters parameters)
        {
            Console.WriteLine(parameters.ToString());
            var web = new HtmlWeb();
            var doc = web.Load(parameters.Url.Address);


            var nodes = doc.DocumentNode.Descendants("img");

            foreach (var i in nodes)
            {
                if (i.GetAttributeValue("alt", "").ToLower().Contains(parameters.Key.Name.ToLower()))
                {
                    string path = @"tmp/img"+parameters.Id+".jpg";
                    string pathtxt = @"text.txt";
                    using (var client = new WebClient())
                    {
                        Console.WriteLine(i.GetAttributeValue("src", ""));
                        await client.DownloadFileTaskAsync(new Uri(i.GetAttributeValue("src", "")), path);
                        //System.IO.File.WriteAllText(pathtxt, i.GetAttributeValue("alt", ""));
                        parameters.Description = i.GetAttributeValue("alt", "");
                    }
                    break;
                    //return true; //poprawić!
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
