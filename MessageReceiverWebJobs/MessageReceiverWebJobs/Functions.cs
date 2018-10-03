using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs;

namespace MessageReceiverWebJobs
{
    public class Functions
    {
        public static void ProcessQueueMessage([ServiceBusTrigger("myqueue", Connection = "AzureWebJobsServiceBus")]string message)
        {
            Console.WriteLine(message);
        }
    }
}
