using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Text;
using homework7;

namespace Homework7Tests
{

    [TestClass]
    public class Homework4Tests
    {
        private Stream BuildATestStream()
        {
            const string input =
                @"the quick brown fox
jumped over the lazy brown dog
roses are redviolets are blue
homework is homework
but code rings true
should you take the time to read
the test case you might learn new
ways of working out the problem
did you remember to check for resharper warnings
did you test for error the error conditions
do not fail not not write your ownunit tests";
            return new MemoryStream(Encoding.UTF8.GetBytes(input));
        }

        [TestMethod]
        public void TextFinder_HappyPath_IsHappy()
        {
            var parser = new TextFinder(BuildATestStream(), "test");
            var match = parser.NextMatch();
            StringAssert.Contains(match, "test");
            match = parser.NextMatch();
            StringAssert.Contains(match, "test");
            match = parser.NextMatch();
            StringAssert.Contains(match, "test");
            match = parser.NextMatch();
            Assert.IsNull(match);
        }

        [TestMethod]
        public void RegexFinder_HappyPath_IsHappy()
        {
            var parser = new RegexFinder(BuildATestStream(), "wr[^ ]*e");
            var match = parser.NextMatch();
            StringAssert.Contains(match, "write");
            match = parser.NextMatch();
            Assert.IsNull(match);
        }

        [TestMethod]
        public void TextFinder_nullAndEmpty_returnNull()
        {
            var parser = new TextFinder(null, "test");
            var match = parser.NextMatch();
            Assert.IsNull(match);

            parser = new TextFinder(new MemoryStream(Encoding.UTF8.GetBytes("")), "test");
            match = parser.NextMatch();
            Assert.IsNull(match);

        }
        [TestMethod]
        public void RegexFinder_nullAndEmpty_returnNull()
        {
            var parser = new RegexFinder(null, "test");
            var match = parser.NextMatch();
            Assert.IsNull(match);

            parser = new RegexFinder(new MemoryStream(Encoding.UTF8.GetBytes("")), "wr[^ ]*e");
            match = parser.NextMatch();
            Assert.IsNull(match);

        }
    }
}

