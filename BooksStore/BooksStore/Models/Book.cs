namespace BooksStore.Models;

public class Book
{
    public string? Id { get; set; } = Guid.NewGuid().ToString();
    public string? Title { get; set; }
    public string? AuthorName { get; set; }
    public DateTime PublishingDate { get; set; }
    public string? Description { get; set; }
}
