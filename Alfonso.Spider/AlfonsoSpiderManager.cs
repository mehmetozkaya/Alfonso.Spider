using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using DotnetSpider.Core.Scheduler;
using DotnetSpider.Downloader;
using System;

namespace Alfonso.Spider
{
    public class AlfonsoSpiderManager
    {
        public void Spy()
        {            
            var spider = DotnetSpider.Core.Spider.Create(new GithubProfileProcessor()).AddRequest(new Request("https://github.com/zlzforever"));           
            spider.ThreadNum = 5;
            spider.Run();
            Console.Read();
        }

        public void Download()
        {
            HttpClientDownloader downloader = new HttpClientDownloader();
            var response = downloader.Download(new Request("http://www.163.com")
            {
                Headers = new System.Collections.Generic.Dictionary<string, object>
                {
                     { "Cookies", "a=b"}
                }
            });

        }
    }

    public class GithubProfileProcessor : BasePageProcessor
    {
        protected override void Handle(Page page)
        {
            //*[@id="js-pjax-container"]/div/div[1]/div[4]/h1/span[1]
            var name = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/h1/span").GetValue();
            var author = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/h1/span[2]").GetValue();
            var mail = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/ul/li/a/text()").GetValue();
            var bio = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div[8]/div/div").GetValue();
            
            page.SkipTargetRequests = string.IsNullOrWhiteSpace(name);
            page.AddResultItem("name", name);
            page.AddResultItem("author", author);
            page.AddResultItem("mail", mail);
            page.AddResultItem("bio", bio);
        }
    }
}
