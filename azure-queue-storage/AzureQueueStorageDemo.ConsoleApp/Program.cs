using Azure.Storage.Queues;
using Azure.Storage.Queues.Models;

var connectionString = "<your connection string here>";

var queueName = $"queuedemo1";

var queueClient = new QueueClient(connectionString, queueName);

await queueClient.CreateIfNotExistsAsync();

//await SendSomeMessages(queueClient);

//await PeekMessages(queueClient, 10);

//await UpdateMessage(queueClient);

//await ReceiveMessages(queueClient);

//await DeleteMessages(queueClient);

//await queueClient.DeleteAsync();

async Task DeleteMessages(QueueClient queueClient)
{
    QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 20);

    foreach (var message in messages)
    {
        var response = await queueClient.DeleteMessageAsync(message.MessageId, message.PopReceipt);
        if (response.IsError)
        {
            Console.WriteLine($"ERROR: [{response.Status}] {response.ReasonPhrase}");
        }
        else
        {
            Console.WriteLine($"SUCCESS: {response.Status}");
        }
    }
}

async Task ReceiveMessages(QueueClient queueClient)
{
    QueueMessage[] messages = await queueClient.ReceiveMessagesAsync(maxMessages: 10);

    foreach (var message in messages)
    {
        Console.WriteLine($"{message.MessageId} - {message.InsertedOn} - {message.Body} - {message.DequeueCount}");
    }
}

async Task UpdateMessage(QueueClient queueClient)
{
    var message = await queueClient.ReceiveMessageAsync();
    await queueClient.UpdateMessageAsync(
        message.Value.MessageId,
        message.Value.PopReceipt,
        "Message #0 - mod");
}

async Task PeekMessages(QueueClient queueClient, int? numberOfMessages)
{
    var messages = await queueClient.PeekMessagesAsync(maxMessages: numberOfMessages);
    foreach (var message in messages.Value)
    {
        Console.WriteLine($"{message.MessageId} - {message.InsertedOn} - {message.ExpiresOn} - {message.Body}");
    }
}

async Task SendSomeMessages(QueueClient queueClient)
{
    for (int i = 0; i < 20; i++)
    {
        var message = $"Message #{i + 1}";
        await queueClient.SendMessageAsync(message);
    }
}


//var message = "Hi everybody!";
//var sendInfo = await queueClient.SendMessageAsync(message);

//if (sendInfo is not null)
//{
//    Console.WriteLine($"{sendInfo.Value.MessageId} - {sendInfo.Value.ExpirationTime}");
//}
//Console.WriteLine($"Message '{message}' sent to queue {queueName}");