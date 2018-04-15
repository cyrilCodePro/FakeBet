﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace FakeBet.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .UseStartup<Startup>()
                .Build();
    }
}