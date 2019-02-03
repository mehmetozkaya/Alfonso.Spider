using System;
using System.Collections.Generic;
using System.Text;
using DotnetSpider.Core;
using DotnetSpider.Extension;
using DotnetSpider.Extension.Pipeline;

namespace Alfonso.Spider
{
    [TaskName("AlfonsoSpider")]
    public class AlfonsoSpider : EntitySpider
    {
        public AlfonsoSpider() : base("AlfonsoSpider")
        {
        }

        protected override void OnInit(params string[] arguments)
        {
            var word = "araba";
            var constr = "Server=(localdb)\\mssqllocaldb;Integrated Security=true;Initial Catalog=baidu;";


            AddRequest(string.Format("http://news.baidu.com/ns?word={0}&tn=news&from=news&cl=2&pn=0&rn=20&ct=1", word), new Dictionary<string, dynamic> { { "Keyword", word } });
            AddEntityType<BaiduSearchEntry>();
            AddPipeline(new SqlServerEntityPipeline());
            //AddPipeline(new ConsoleEntityPipeline());
        }
    }
}
