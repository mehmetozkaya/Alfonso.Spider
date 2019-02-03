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
                //*[@id="js-pjax-container"]/div/div[1]/div[4]/h1
                page.AddResultItem("asd", page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/h1/span").GetValue());
                
                page.AddResultItem("author", page.Selectable().XPath("//div[@class='p-nickname vcard-username d-block']").GetValue());

                
                var name2 = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div[1]/div[4]/h1/span[1]").GetValue();
                var name3 = page.Selectable().XPath("//*[@id='js-pjax-container']/div/div/div/h1/span").GetValue();
                var name = page.Selectable().XPath("//span[@class='p-name vcard-fullname d-block']").GetValue();

                page.SkipTargetRequests = string.IsNullOrWhiteSpace(name);
                page.AddResultItem("name", name);
                page.AddResultItem("bio", page.Selectable().XPath("//div[@class='p-note user-profile-bio']/div").GetValue());
            }
        }
    }
}
