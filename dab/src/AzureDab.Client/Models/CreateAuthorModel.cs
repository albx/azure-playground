using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace AzureDab.Client.Models;

public class CreateAuthorModel
{
    [JsonPropertyName("first_name")]
    [Required]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("last_name")]
    [Required]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("middle_name")]
    public string MiddleName { get; set; } = string.Empty;
}
