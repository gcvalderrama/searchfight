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
    public class TestBingProxy
    {
        [Test()]
        public void TestBingSearch()
        {
            var proxy = new BingProxy();
            string result = proxy.DoSearch(".net").Result.Content.ReadAsStringAsync().Result;
            Assert.IsNotNull(result);
        }
    }
}
