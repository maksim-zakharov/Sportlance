﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Sportlance.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.CreateDefaultBuilder(args)
                .UseSetting("detailedErrors", "true")
                .UseStartup<Startup>()
                .CaptureStartupErrors(true)
                .Build()
                .Run();
        }
    }
}