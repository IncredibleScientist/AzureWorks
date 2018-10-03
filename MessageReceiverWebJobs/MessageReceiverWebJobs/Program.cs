using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MessageReceiverWebJobs
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new HostBuilder().UseEnvironment("development")
             .ConfigureWebJobs(b =>
             {

                 b.AddAzureStorageCoreServices()
                 .AddAzureStorage()
                 .AddServiceBus();

             })

             .ConfigureLogging((context, b) =>
             {
                 b.SetMinimumLevel(LogLevel.Debug);
                 b.AddConsole();

             });

            var host = builder.Build();
            using (host)
            {
                host.Run();
            }
        }
    }
}
