using System;
using Serilog;
using Serilog.Exceptions;
using Searchfight.Services;
using Serilog.Formatting.Json;

namespace Searchfight
{
    class Program
    {        
        static void Main(string[] args)
        {
            ILogger logger = new LoggerConfiguration().Enrich.WithExceptionDetails()
                .WriteTo.RollingFile(new JsonFormatter(renderMessage: true),
                        @".\log-{Date}.txt").CreateLogger();
            try
            {                
                var service = new SearchService();
                var result = service.Search(args);
                Console.WriteLine(result);                
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurs, please review log file on same folder");
                logger.Error(ex, "an error on serchfight");
            }            
        }
    }
}
