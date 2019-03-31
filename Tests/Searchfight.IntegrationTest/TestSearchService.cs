using NUnit.Framework;
using Searchfight.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.IntegrationTest
{
    [TestFixture()]
    public  class TestSearchService
    {
        [Test()]
        public void TestSearch()
        {
            var service = new SearchService();
            var result = service.LoadSearchResults(new string[] { "net", "java", "java script" });
            Console.WriteLine(result.Result.Report());
            Assert.AreEqual(result.Result.Results.Count(), 6);
        }
    }
}
