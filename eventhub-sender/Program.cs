using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Messaging.EventHubs;
using Azure.Messaging.EventHubs.Producer;

namespace eventhub_sender
{
    class Program
    {
        private const string connectionString = "";
        private const string eventHubName = "";
        static async Task Main()
        {
            // Create a producer client that you can use to send events to an event hub
            await using (var producerClient = new EventHubProducerClient(connectionString, eventHubName))
            {
                while(true)
                {
                    using EventDataBatch eventBatch = await producerClient.CreateBatchAsync();

                    var json = JsonSerializer.Serialize(new SensorData());

                    Console.WriteLine(json);

                    eventBatch.TryAdd(new EventData(Encoding.UTF8.GetBytes(json)));
        
                
                    await producerClient.SendAsync(eventBatch);
                    Console.WriteLine("A batch of 3 events has been published.");
                    await Task.Delay(1000);
                }
            }
        }
    }
}
