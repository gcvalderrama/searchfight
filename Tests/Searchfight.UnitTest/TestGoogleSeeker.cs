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
    class TestGoogleSeeker
    {
        [Test()]
        public void TestGoogleResult()
        {
            string content = File.ReadAllText("./google_result.txt");

            GoogleSeeker seeker = new GoogleSeeker();
            var result = seeker.Search(content);
            Assert.AreEqual(21990000000, result);
            
        }
    }
}
