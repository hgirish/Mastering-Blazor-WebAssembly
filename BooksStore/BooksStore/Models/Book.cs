using System.Text.Json.Serialization;

namespace BooksStore.Models;

public class Book
{
    [JsonPropertyName("id")]
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [JsonPropertyName("authorName")]
    public string? AuthorName { get; set; }
    [JsonPropertyName("publishingDate")]
    public DateTime PublishingDate { get; set; }
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
    [JsonPropertyName("coverImageUrl")]
    public string? CoverImageUrl { get; set; }
    [JsonPropertyName("pagesCount")]
    public int PagesCount { get; set; }
}
