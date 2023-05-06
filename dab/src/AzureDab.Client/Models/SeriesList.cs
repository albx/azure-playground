namespace AzureDab.Client.Models;

public class SeriesList
{
    public IEnumerable<SeriesItem> Value { get; set; }

    public record SeriesItem
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
