using AzureDab.Client.Models;
using System.Net.Http.Json;

namespace AzureDab.Client.Services;

public class AuthorsService
{
    public AuthorsService(HttpClient http)
    {
        Http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public HttpClient Http { get; }

    public async Task<AuthorList> GetAuthorsAsync()
    {
        var list = await Http.GetFromJsonAsync<AuthorList>("api/Author");
        if (list == null)
        {
            throw new InvalidOperationException("Invalid response");
        }

        return list;
    }

    public async Task CreateNewAuthorAsync(CreateAuthorModel author)
    {
        var response = await Http.PostAsJsonAsync("api/Author", author);
        response.EnsureSuccessStatusCode();
    }
}
