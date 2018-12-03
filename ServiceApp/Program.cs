using AzureMessageQueue;
using System;

namespace ServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            string serviceBusConnectionString = "Endpoint=sb://sigfoxpractice.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=cOktybDv9Z0wxCj+XUTAW5E1CqtpvcNPHH1BJ9+XNiI=";
            string queueName = "sigfoxpracticequeue";
            var messageBussHandler = new AzureMessageBussHandler(serviceBusConnectionString, queueName);
            messageBussHandler.GetNextMessage();

            Console.ReadKey();
        }
    }
}
