using System.Text.Json.Serialization;

namespace AzureDab.Client.Models;

public class AuthorList
{
    public IEnumerable<AuthorItem> Value { get; set; } = Enumerable.Empty<AuthorItem>();

    public record AuthorItem
    {
        public int Id { get; init; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; init; } = string.Empty;

        [JsonPropertyName("last_name")]
        public string LastName { get; init; } = string.Empty;

        [JsonPropertyName("middle_name")]
        public string MiddleName { get; init; } = string.Empty;
    }
}
