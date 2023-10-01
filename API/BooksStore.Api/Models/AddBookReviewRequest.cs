using System.ComponentModel.DataAnnotations;

namespace BooksStore.Api.Models;

public class AddBookReviewRequest
{

    [Range(1, 5, ErrorMessage = "Rating must be between 1 and 5")]
    public int Rating { get; set; } = 1;

    public string? Description { get; set; }

}