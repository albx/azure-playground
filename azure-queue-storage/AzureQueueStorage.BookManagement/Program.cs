// See https://aka.ms/new-console-template for more information
using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;
using AzureQueueStorage.Messages;

Console.WriteLine("Hello, World!");

var messages = new[]
{
    new BookRegisteredMessage(Guid.NewGuid(), "Harry potter e la pietra filosofale", "J.K. Rowling"),
    new BookRegisteredMessage(Guid.NewGuid(), "Un bellissimo libro", "AA.VV."),
    new BookRegisteredMessage(Guid.NewGuid(), "Un Altro libro", "Autore a caso")
};

var client = new QueueClient(
    "UseDevelopmentStorage=true",
    "registered-books",
    new QueueClientOptions { MessageEncoding = QueueMessageEncoding.Base64 });

await client.CreateIfNotExistsAsync();

foreach (var message in messages)
{
    var data = new BinaryData(message);
    SendReceipt response = await client.SendMessageAsync(data);

    Console.WriteLine($"{response.MessageId} - {response.InsertionTime}");
}
