using System.Text.Json.Serialization;

namespace AzureDab.Client.Models;

public class BookList
{
    public IEnumerable<BookItem> Value { get; set; } = Enumerable.Empty<BookItem>();

    public record BookItem
    {
        public int Id { get; init; }

        public string Title { get; init; } = string.Empty;

        public int? Year { get; init; }

        public int? Pages { get; init; }

        [JsonPropertyName("series_id")]
        public int? SeriesId { get; init; }
    }
}
