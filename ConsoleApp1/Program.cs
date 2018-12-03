using AzureMessageQueue;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start Pushing Data!");
            string serviceBusConnectionString = "Endpoint=sb://sigfoxpractice.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=cOktybDv9Z0wxCj+XUTAW5E1CqtpvcNPHH1BJ9+XNiI=";
            string queueName = "sigfoxpracticequeue";
            var messageBussHandler = new AzureMessageBussHandler(serviceBusConnectionString, queueName);

            for ( int i=0; i<10; i++)
            {
               
                messageBussHandler.QueueMessage($"message:{i}").GetAwaiter();
                
            }

            Console.WriteLine("Push Data Completed");

            Console.ReadKey();

        }
    }
}
