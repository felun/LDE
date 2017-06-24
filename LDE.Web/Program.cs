﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace LDE.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = new WebHostBuilder()
              //.UseKestrel()
              //.UseContentRoot(Directory.GetCurrentDirectory())
              //.UseStartup<Startup>()
              //.UseApplicationInsights()
              //.Build();
              .UseKestrel()
              .UseContentRoot(Directory.GetCurrentDirectory())
              .UseSetting("detailedErrors", "true")
              .UseIISIntegration()
              .UseStartup<Startup>()
              .CaptureStartupErrors(true)
              .UseApplicationInsights()
              .Build();

            host.Run();
        }
    }
}
