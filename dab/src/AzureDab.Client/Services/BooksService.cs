using AzureDab.Client.Models;
using System.Net.Http.Json;

namespace AzureDab.Client.Services;

public class BooksService
{
    public BooksService(HttpClient http)
    {
        Http = http ?? throw new ArgumentNullException(nameof(http));
    }

    public HttpClient Http { get; }

    public async Task<BookList> GetBooksAsync()
    {
        var list = await Http.GetFromJsonAsync<BookList>("api/Book");
        if (list == null)
        {
            throw new InvalidOperationException("Invalid response");
        }

        return list;
    }

    public async Task<BookList.BookItem> GetBookDetailAsync(int bookId)
    {
        var list = await Http.GetFromJsonAsync<BookList>($"api/Book/id/{bookId}");
        if (list == null)
        {
            throw new InvalidOperationException("Invalid response");
        }

        return list.Value.First();
    }

    public async Task<SeriesList.SeriesItem> GetSeriesDetailAsync(int seriesId)
    {
        var list = await Http.GetFromJsonAsync<SeriesList>($"api/Series/id/{seriesId}");
        if (list == null)
        {
            throw new InvalidOperationException("Invalid response");
        }

        return list.Value.First();
    }
}
