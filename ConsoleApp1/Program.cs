using Alfonso.Spider;
using DotnetSpider.Core;
using DotnetSpider.Core.Processor;
using DotnetSpider.Core.Scheduler;
using DotnetSpider.Downloader;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            AlfonsoSpiderManager alfonsoSpiderManager = new AlfonsoSpiderManager();
            alfonsoSpiderManager.Spy();

            ////var site = new DotnetSpider.Core.Scheduler { CycleRetryTimes = 3, SleepTime = 300 };
            ////IScheduler asd = new QueueScheduler() { Name}

            //var spider = Spider.Create(new GithubProfileProcessor()).AddRequest(new Request("https://github.com/zlzforever"));
            //spider.ThreadNum = 5;
            //spider.Run();
            //Console.Read();
        }

        private class GithubProfileProcessor : BasePageProcessor
        {
            protected override void Handle(Page page)
            {

                //*[@id="js-pjax-container"]/div/div[1]/div[4]/h1/span[1]
                var name = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/h1/span").GetValue();
                var author = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/h1/span[2]").GetValue();
                var mail = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/ul/li/a").GetValue();
                var bio = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/div/div").GetValue();
                                            
                page.SkipTargetRequests = string.IsNullOrWhiteSpace(name);
                page.AddResultItem("name", name);
                page.AddResultItem("author", author);
                page.AddResultItem("mail", mail);
                page.AddResultItem("bio", bio);
                
            }
        }
    }
}
