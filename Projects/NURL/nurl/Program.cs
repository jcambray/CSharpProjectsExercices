using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace nurl
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new NurlApplication();
            Console.Read();
            //app.ParseArgument(args);
        }



    }

    public class NurlApplication
    {
        String url = @"http://api.openweathermap.org/data/2.5/weather?q=paris&units=metric";

        public NurlApplication()
        {
            //SaveAsJSON(GetFileName(url), GetData(url));
            testConnectionTime(url,"5");
        }

        public void ParseArgument(string[] strgs)
        {
            for (int i = 0; i < strgs.Length; i++)
            {
                Console.WriteLine(strgs.ElementAt<string>(i));
            }
        }

        private string GetData(string url)
        {
            WebClient client = new WebClient();
            var datas = client.DownloadString(url);
            return datas;
        }

        public void SaveAsJSON(string path, string datas)
        {
            try
            {
                File.WriteAllText(path + ".json", datas);
                Console.WriteLine("save successful!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetFileName(string url)
        {
            string[] urlParts = url.Split('/');
            return urlParts[2];
        }

        public void testConnectionTime(string url, string times)
        {
            int t;
            int.TryParse(times, out t);

            if (t == 0)
            {
                Console.WriteLine("Invalid argument");
                return;
            }

            WebClient client = new WebClient();
            
            for (int i = 0; i < t; i++)
            {
                var timeAtStart = DateTime.Now;
                GetData(url);
                var timeAtEnd = DateTime.Now;
                var timespan = timeAtEnd - timeAtStart;
                Console.WriteLine("Temps écoulé : " + timespan.TotalMilliseconds.ToString() + " millisecondes.");
            }
        }

        public void AvgTestConnection(string url, string time)
        {

        }


    }

}
