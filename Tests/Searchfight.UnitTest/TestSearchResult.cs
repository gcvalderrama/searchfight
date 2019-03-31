using NUnit.Framework;
using Searchfight.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.UnitTest
{
    [TestFixture()]
    public class TestSearchResult
    {
        [Test()]
        public void TestGoogleBingResult()
        {
            SearchResult result = new SearchResult();
            result.LoadResult("google", ".net", 4450000000);
            result.LoadResult("bing", ".net", 12354420);
            result.LoadResult("google", "java", 966000000);
            result.LoadResult("bing", "java", 94381485);
            Assert.AreEqual(result.Results.Count(), 4);
            string rpt = result.Report();            
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(".net: bing: 12354420 google: 4450000000");
            sb.AppendLine("java: bing: 94381485 google: 966000000");
            sb.AppendLine("bing winner: java");
            sb.AppendLine("google winner: .net");            
            sb.AppendLine("Total winner: .net");
            System.Console.WriteLine("===========");
            System.Console.WriteLine(rpt);
            System.Console.WriteLine("===========");
            System.Console.WriteLine(sb.ToString());
            Assert.AreEqual(sb.ToString(), rpt);
        }
    }
}
