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
        public void ShouldGetPageContent()
        {
            //given
            var app = new NurlApplication();
            var commands = new string[] { "get", "-url", @"https://jcambray.github.io/fake.html" };
            var expectedString = @"<html>Hello!</html>";

            //when
            app.DispatchArgs(commands);
            var data = app.Datas;

            //then
            Assert.AreEqual(expectedString, data);


        }

        [Test]
        public void FileContentShouldBeEqualToStringVariable()
        {
            //given
            var app = new NurlApplication();
            var commands = new string[] { "get", "-url", @"https://jcambray.github.io/fake.html","-save",@"c:\test\testfile.htm" };
            var expectedFileContent = @"<html>Hello!</html>";

            //when
            app.DispatchArgs(commands);
            var fileContent = File.ReadAllText(@"c:\test\testfile.htm");

            //then
            Assert.AreEqual(expectedFileContent, fileContent);
        }

    }
}
