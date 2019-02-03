using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgilityAlfonso
{
    class Program
    {
        static void Main(string[] args)
        {
            // From Web
            var url = "http://html-agility-pack.net/";
            var web = new HtmlWeb();
            var doc = web.Load(url);


        }
    }
}
