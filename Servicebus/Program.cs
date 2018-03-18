using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace Servicebus
{

    class Program
    {
        private const string ServiceBusConnectionString = "";
        const string QueueName = "";
        static IQueueClient queueClient;
        static void Main(string[] args)
        {
            MainAsync().GetAwaiter().GetResult();
        }

        static async Task MainAsync()
        {
            const int numberOfMessages = 10;
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);

            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");

            // Send messages.
            await SendMessagesAsync(numberOfMessages);

            Console.ReadKey();

            await queueClient.CloseAsync();
        }
        static async Task SendMessagesAsync(int numberOfMessagesToSend)
{
    try
    {
        for (var i = 0; i < numberOfMessagesToSend; i++)
        {
            // Create a new message to send to the queue.
            string messageBody = $"Message {i}";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));

            // Write the body of the message to the console.
            Console.WriteLine($"Sending message: {messageBody}");

            // Send the message to the queue.
            await queueClient.SendAsync(message);
        }
    }
    catch (Exception exception)
    {
        Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
    }
}
    }
    
    
    
    
    //class Program
    //{

    //   static ManualResetEvent _mrEvent = new ManualResetEvent(false);
    //    static void Main(string[] args)
    //    {
    //       Console.WriteLine(ServiceBusEnvironment.DefaultIdentityHostName);
    //       Console.WriteLine(ServiceBusEnvironment.CreateAccessControlUri("fabiouri"));
    //        Console.Write(ServiceBusEnvironment.SystemConnectivity.Mode);
    //        Console.WriteLine(ServiceBusEnvironment.CreateServiceUri("sb","fabiodemartino",string.Empty,true));
    //        Console.WriteLine(ServiceBusEnvironment.CreateServiceUri("sb", "fabiodemartino", string.Empty, false));
           
    //        try
    //        {
    //            //Shared Access policies Root Managed Shared Access Key Primary key
    //            var tp = TokenProvider.CreateSharedSecretTokenProvider("fabio", "v5wO6YA+7uehfddctv7xhcRNXnLat2QFnb1U+CRu9XQ=");
    //            var uri = ServiceBusEnvironment.CreateServiceUri("sb","fabiodemartino",string.Empty,true);
    //            tp.BeginGetToken(uri.ToString(), "Listen", true, TimeSpan.FromSeconds(5), TokenReceived, tp);
    //            if (_mrEvent.WaitOne(TimeSpan.FromMinutes(10)))
    //            {
    //                Console.WriteLine("Received a token");
    //            }
    //            else
    //            {
    //                Console.WriteLine("Did not received a token"); 
    //            }
               

    //        }
    //        catch (Exception ex)
    //        {
    //          Console.WriteLine(ex);  
    //        }
    //        Console.ReadLine();
    //        //const string queueName = "thequeue";
    //        //var tokenProvider = TokenProvider.CreateSharedSecretTokenProvider(
    //        //    "fabio", "fabio"
    //        //);
    //    }

    //    private static void TokenReceived(IAsyncResult ar)
    //    {
    //        var tp = (TokenProvider) ar.AsyncState;
    //        var token = tp.EndGetToken(ar);
          
    //       Console.WriteLine((string) token.Id);
    //        _mrEvent.Set();
    //    }
    //}
}
