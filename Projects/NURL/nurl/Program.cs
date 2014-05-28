using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace nurl
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new NurlApplication();
            app.DispatchArgs(args);
        }



    }
}
