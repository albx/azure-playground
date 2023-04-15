namespace AzureQueueStorage.Messages;

public class BookRegisteredMessage
{
    public BookRegisteredMessage(Guid id, string title, string author)
    {
        Id = id;
        Title = title;
        Author = author;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
}
