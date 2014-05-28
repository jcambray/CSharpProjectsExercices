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
      
            var app = new NurlApplication();
            var commands = new string[] { "get", "-url", @"https://jcambray.github.io/fake.html" };
            var expectedString = @"<html>Hello!</html>";

   
            app.DispatchArgs(commands);
            var data = app.Datas;


            Assert.AreEqual(expectedString, data);


        }

        [Test]
        public void FileContentShouldBeEqualToStringVariable()
        {

            
            var commands = new string[] { "get", "-url", @"https://jcambray.github.io/fake.html","-save",@"c:\test\testfile.htm" };
            var expectedFileContent = @"<html>Hello!</html>";

            var app = new NurlApplication();
            app.DispatchArgs(commands);
            var fileContent = File.ReadAllText(@"c:\test\testfile.htm");


            Assert.AreEqual(expectedFileContent, fileContent);
        }

        [Test]
        public void GetAverageTime()
        {
            var app = new NurlApplication();

            //given
            var command = new String[] { "test", "-url", @"https://jcambray.github.io/fake.html", "-time", "3","-avg" };
            
            //when
            app.DispatchArgs(command);

            //then
            Assert.IsTrue(app.avg > 0);
        }

        [Test]
        public void TestConnection()
        {
            var app = new NurlApplication();
           
            //given
            var command = new String[] { "test", "-url", @"https://jcambray.github.io/fake.html", "-time", "3" };

            //when
            app.DispatchArgs(command);

            //then
            Assert.IsTrue(app.Time > 0);
        }

    }
}
