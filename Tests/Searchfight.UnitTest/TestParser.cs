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
    public class TestParser
    {
        [Test()]
        public void TestEmptyArgs() {
            string[] inputs = new string[] { };
            Parser parser = new Parser(inputs);
            Assert.IsFalse(parser.IsValid); 
        }

        [Test()]
        public void TestOneArgument()
        {
            string[] inputs = new string[] { "java" };
            Parser parser = new Parser(inputs);
            Assert.IsFalse(parser.IsValid);
        }
        [Test()]
        public void TestTwoArgument()
        {
            string[] inputs = new string[] { "java", "net" };
            Parser parser = new Parser(inputs);
            Assert.IsTrue(parser.IsValid);
            Assert.IsNotEmpty(parser.Words);
        }
    }
}
