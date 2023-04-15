using AzureQueueStorage.Messages;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using System;

namespace AzureQueueStorage.Functions
{
    public class QueueFunction
    {
        private readonly ILogger _logger;

        public QueueFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<QueueFunction>();
        }

        [Function("QueueFunction")]
        public void Run(
            [QueueTrigger("registered-books")] BookRegisteredMessage message)
        {
            _logger.LogInformation($"C# Queue trigger function processed: {message.Id}");

            var filePath = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                $"{message.Title}.txt");

            System.IO.File.WriteAllText(
                filePath,
                $"Book ID: {message.Id}{Environment.NewLine}Book title: {message.Title}{Environment.NewLine}Book Author: {message.Author}");
        }
    }
}
