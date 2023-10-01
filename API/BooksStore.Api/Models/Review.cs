namespace BooksStore.Api.Models;

public class Review
{

    public Review()
    {
        Id = Guid.NewGuid().ToString();
    }

    public string Id { get; set; }
    public int Rating { get; set; }
    public string? Description { get; set; }
}