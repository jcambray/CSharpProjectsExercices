using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nurl
{
    public class NurlApplication
    {
        public string Datas { get; set; }
        //public float avg { get; set; }
        //public string[] ConsoleArgs { get; set; }


        public void GetData(string url)
        {
            try
            {
                var client = new WebClient();
                Datas =  RemoveRetourChariot((client.DownloadString(url)));
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.Message);
            }
        }

        public void Save(string path, string datas)
        {
            try
            {
                FileInfo fi = new FileInfo(path);
                if (!fi.Directory.Exists)
                {
                    fi.Directory.Create();
                }
                File.WriteAllText(path, datas);
                Console.WriteLine("save successful!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string GetFileName(string url)
        {
            var urlParts = url.Split('/');
            return urlParts[2];
        }

        public void testConnectionTime(string url, int times)
        {
            WebClient client = new WebClient();

            for (int i = 0; i < times; i++)
            {
                var timeAtStart = DateTime.Now;
                GetData(url);
                var timeAtEnd = DateTime.Now;
                var timespan = timeAtEnd - timeAtStart;
                Console.WriteLine("Temps écoulé : " + timespan.TotalMilliseconds.ToString() + " millisecondes.");
            }
        }

        public void AvgTestConnection(string url, int times)
        {
            TimeSpan cumul = TimeSpan.Zero;
            for (int i = 0; i < times; i++)
            {
                var start = DateTime.Now;
                GetData(url);
                var end = DateTime.Now;
                cumul += end - start;
            }
            var avg = cumul.TotalMilliseconds / times;
            Console.WriteLine("Temps moyen du chargement: " + avg + " millisecondes.");

        }

        public void DispatchArgs(string[] consoleArgs)
        {
            for (int i = 0; i < consoleArgs.Length; i++)
            {
                switch (consoleArgs[i])
                {
                    case "get":
                        if (consoleArgs[i + 1] == "-url")
                        {
                            GetData(consoleArgs[i + 2]);
                            Console.WriteLine(Datas);
                        }
                        else
                        {
                            Console.WriteLine("Invalid option");
                            return;
                        }
                        break;

                    case "test":
                        if (consoleArgs[i + 1] == "-url")
                        {
                            var url = consoleArgs[i + 2];
                            if (consoleArgs[i + 3] == "-time")
                            {
                                int time;
                                if (!int.TryParse(consoleArgs[i + 4], out time))
                                {
                                    Console.WriteLine("Invalid argument");
                                    return;
                                }
                                try
                                {
                                    var avg = consoleArgs[i + 5];
                                    if (avg == "-avg")
                                    {
                                        AvgTestConnection(url, time);
                                        return;
                                    }
                                }
                                catch (IndexOutOfRangeException)
                                {
                                    testConnectionTime(url, time);
                                    return;
                                }
                            }
                            else
                                Console.WriteLine("Invalid option");
                        }
                        break;
                    case "-save":
                        string file = consoleArgs[i + 1];
                        Save(file, Datas);
                        break;
                }
            }
        }

        public string RemoveRetourChariot(string str)
        {
            if (str != null)
            {
                str.Remove(str.Length - 2);
            }
            return str;
        }


    }
}
