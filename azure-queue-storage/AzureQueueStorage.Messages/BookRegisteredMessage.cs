namespace AzureQueueStorage.Messages;

public record BookRegisteredMessage(Guid Id, string Title, string Author);
