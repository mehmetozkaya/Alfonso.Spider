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
            var url = "";
            var doc = new HtmlWeb().Load(url);
            var phoneList = doc.DocumentNode.SelectSingleNode("//*[@id='listele']/div[3]");

            

            foreach (HtmlNode phone in phoneList.ChildNodes)
            {
                if (phone.Name != "ul")
                    continue;
                
                var phoneName = phone.SelectSingleNode("//*[@id='125051']/li[1]/div[2]/a");

                var nodeUrun = phone.QuerySelector("\\31 25051 > li.fiyat.cell > a");
                var fiyat = phone.QuerySelector("#li.fiyat.cell>a");

                var ozellikNodes = phone.SelectNodes("//*[@id='125051']/li");

                foreach (var item in ozellikNodes)
                {
                    var asd = item.InnerText;
                }
                //*[@id="125051"]/li[2]
                //*[@id="125051"]/li[3]
                //*[@id="125051"]/li[4]

                //if(phone.Attributes["class"].Value == "metin row")
                //{

                //}


            }


            var html = @"https://www.expatriates.com/cls/41002766.html";
            HtmlWeb web = new HtmlWeb();
            var htmlDoc = web.Load(html);

            var mainTitle = htmlDoc.DocumentNode.SelectSingleNode("//*[@class='page-title']//h1");
            if (mainTitle == null) return;
            if (mainTitle.InnerText.Trim().Contains("Page Not Found")) { Console.WriteLine("Page In Active Now"); return; }

            var nodeTitle = htmlDoc.DocumentNode.SelectSingleNode("//*[@class='no-bullet']");

            string sDate = string.Empty;
            string sCategory = string.Empty;
            string sRegion = string.Empty;
            string sSubRegion = string.Empty;
            string sPostingID = string.Empty;
            string sTelephone = string.Empty;
            string sEncodedEmail = string.Empty;
            string sEmail = string.Empty;


            if (nodeTitle != null && nodeTitle.HasChildNodes)
            {
                foreach (HtmlNode n in nodeTitle.ChildNodes)
                {
                    //Console.WriteLine("\r\nName: " + n.Name + " HTML: " + n.OuterHtml + " Text: " + n.InnerText );

                    if (n.InnerText.Contains("Date:"))
                    {
                        string[] saDate = n.InnerText.Split(":".ToCharArray());
                        if (saDate.Length == 2) { sDate = saDate[1].Trim(); }
                    }
                    else if (n.InnerText.Contains("Category:"))
                    {
                        string[] saCategory = n.InnerText.Split(":".ToCharArray());
                        if (saCategory.Length == 2) { sCategory = saCategory[1].Trim(); }
                    }

                    else if (n.InnerText.Contains("Region:"))
                    {
                        string[] saRegion = n.InnerText.Split(":".ToCharArray());
                        if (saRegion.Length == 2)
                        {
                            sRegion = saRegion[1].Trim().Replace("\r", "").Replace("\n", "");

                            if (sRegion.Contains("(") && sRegion.Contains(")"))
                            {
                                sSubRegion = sRegion.Substring(sRegion.IndexOf("(") + 1, (sRegion.LastIndexOf(")") - sRegion.IndexOf("(")) - 1).Trim();
                                sRegion = sRegion.Replace("(" + sSubRegion + ")", "");
                            }
                        }

                    }
                    else if (n.InnerText.Contains("Posting ID:"))
                    {
                        sPostingID = n.InnerText;
                        string[] saPosting = n.InnerText.Split(":".ToCharArray());
                        if (saPosting.Length == 2) { sPostingID = saPosting[1].Trim(); }
                    }
                    else if (n.OuterHtml.Contains("tel:"))
                    {
                        sTelephone = n.InnerText.Trim();
                    }
                    else if (n.InnerText.Contains("From:"))
                    {
                        var emailNode = n.SelectSingleNode("//*[@class='__cf_email__']");
                        if (emailNode != null)
                        {
                            foreach (HtmlAttribute attribute in emailNode.Attributes)
                            {
                                if (attribute.Name.Contains("data-cfemail"))
                                {
                                    sEncodedEmail = attribute.Value;
                                }
                            }
                        }
                    }
                }
            }

            Console.WriteLine("\nDate: " + sDate);
            Console.WriteLine("\nCategory: " + sCategory);
            Console.WriteLine("\nRegion: " + sRegion);
            Console.WriteLine("\nSub Region: " + sSubRegion);
            Console.WriteLine("\nPostingID: " + sPostingID);
            Console.WriteLine("\nTelephone: " + sTelephone);



            //// From Web
            //var url = "http://html-agility-pack.net/";
            //var web = new HtmlWeb();
            //var doc = web.Load(url);

            //var node = doc.DocumentNode.SelectSingleNode("//head/title");
            //var div = doc.GetElementbyId("foo");

            //// With XPath 
            //var value = doc.DocumentNode
            // .SelectNodes("//td/input")
            // .First()
            // .Attributes["value"].Value;

            //// With LINQ 
            //var nodes = doc.DocumentNode.Descendants("input")
            // .Select(y => y.Descendants()
            // .Where(x => x.Attributes["class"].Value == "box"))
            // .ToList();

        }
    }
}
