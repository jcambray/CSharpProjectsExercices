using System;
using System.IO;
using nurl;
using System.Net;
using NUnit.Framework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace nurlTests
{
    [TestFixture]
    class NurlTest
    {
        [Test]
        public void StringVariableShouldNotBeEmpty()
        {
            WebClient client = new WebClient();
            var url = @"http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric";
            var data = client.DownloadString(url);
            Assert.IsTrue(data.Length != 0);
        }

        [Test]
        public void FileShouldNotBeEmpty()
        {
            NurlApplication app = new NurlApplication();
            string data = "tototatatiti";
            string file = "testFile";
            string expectedfile = file+".json";
            app.SaveAsJSON(file, data);
            Assert.IsTrue(new FileInfo(expectedfile).Length > 0);
        }

        [Test]
        public void TimeSpanIsNotNull()
        {
            var url = @"http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric";
            NurlApplication nurl = new NurlApplication();
            var default_diff = new TimeSpan(0,0,0);
            var diff = default_diff;

            var start = DateTime.Now;
            nurl.GetData(url);
            var end = DateTime.Now;
            diff = end - start;
            Assert.AreNotEqual(default_diff,diff);
        }
    }
}
