using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BooksStore.Models;

public class SubmitBook
{
    [Required]
    [StringLength(80,MinimumLength = 3)]
    [JsonPropertyName("title")]
    public string? Title { get; set; }
    [StringLength(5000)]
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [Required]
    [StringLength(80, MinimumLength = 3)]
    [JsonPropertyName("author")]
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    [Range(1,9999, ErrorMessage ="Number of pages must be at least 1 and at most 9999")]
    [DisplayName("Number of Pages")]
    [JsonPropertyName("pagesCount")]
    public int PagesCount { get; set; }
    [Range(typeof(decimal),"0","99999")]
    [JsonPropertyName("price")]
    public decimal Price { get; set; }
}
