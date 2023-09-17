using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BooksStore.Models;

public class SubmitBook
{
    [Required]
    [StringLength(80,MinimumLength = 3)]
    public string? Title { get; set; }
    [StringLength(5000)]
    public string? Description { get; set; }
    [Required]
    [StringLength(80, MinimumLength = 3)]
    public string? Author { get; set; }
    public string? ISBN { get; set; }
    [Range(1,9999, ErrorMessage ="Number of pages must be at least 1 and at most 9999")]
    [DisplayName("Number of Pages")]
    public int PagesCount { get; set; }
    [Range(typeof(decimal),"0","99999")]
    public decimal Price { get; set; }
}
