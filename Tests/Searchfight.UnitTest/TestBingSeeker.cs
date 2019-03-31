using NUnit.Framework;
using Searchfight.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searchfight.UnitTest
{
    [TestFixture()]
    public class TestBingSeeker
    {
        [Test()]
        public void TestBingResult()
        {
            string content = File.ReadAllText("./bing_result.txt");
            var seeker = new BingSeeker();
            var result = seeker.Search(content);
            Assert.AreEqual(16800000, result);
        }
    }
}
