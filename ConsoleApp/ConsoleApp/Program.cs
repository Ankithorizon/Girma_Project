using System;
using Microsoft.Extensions.DependencyInjection;
using ServiceLib.Services;

// ILogger
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.Extensions.Logging.Debug;

// EventLog
using System.Diagnostics;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.Extensions.Hosting;

namespace ConsoleApp
{
    class Program
    {


        static void Main(string[] args)
        {

            // Setting up dependency injection
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // Get an instance of the service
            var myService = serviceProvider.GetService<EmployeeService>();

            // Call the service (logs are made here)
            myService.GetEmployeeById(0);
            
        }
        private static void ConfigureServices(ServiceCollection services)
        {

            // ILogger
            // Register service from the library
            // services.AddTransient<EmployeeService>();


            //services.AddLogging(config =>
            //{
            //    config.AddDebug(); // Log to debug (debug window in Visual Studio or any debugger attached)
            //    config.AddConsole(); // Log to console (colored !)               
            //})
            //.Configure<LoggerFilterOptions>(options =>
            //{
            //    options.AddFilter<DebugLoggerProvider>(null /* category*/ , LogLevel.Information /* min level */);
            //    options.AddFilter<ConsoleLoggerProvider>(null  /* category*/ , LogLevel.Information /* min level */);
            //}).AddTransient<EmployeeService>();



            // ILogger
            // services.AddLogging(configure => configure.AddConsole())
            services.AddLogging(configure => configure.AddEventLog())
               .Configure<EventLogSettings>(settings =>
               {
                   settings.SourceName = "Girma ILogger To EventLog";                   
               })
                //.Configure<LoggerFilterOptions>(
                //      options => options.MinLevel = LogLevel.Information
                // )
            .AddTransient<EmployeeService>();
        }

    }
}
