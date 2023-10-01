using BooksStore.Api.Exceptions;
using BooksStore.Api.Models;

namespace BooksStore.Api.Services;

public class BooksService
{
    static List<Book> _allBooks = new List<Book>
        {
                 new Book
                 {
                     Id = "60ce7ea9-ebb7-4bc1-894b-df6ec5347a0a",
                     AuthorName = "John Smith",
                     PublishingDate = new DateTime(2021, 01, 12),
                     Title = "Blazor WebAssembly Guide",
                     Price = 45,
                     PagesCount = 300,
                 },
                 new Book
                 {
                     Id = "12fa4fa1-4022-46d7-97ff-9ff2c73d3bde",
                     AuthorName = "John Smith",
                     PublishingDate = new DateTime(2022, 03, 13),
                     Title = "Mastering Blazor WebAssembly",
                     Price = 35,
                     PagesCount = 200,
                 },
                 new Book
                 {
                     Id = "e6c0d89c-3767-4aea-a61d-2e1260c2004a",
                     AuthorName = "John Smith",
                     PublishingDate = new DateTime(2022, 08, 01),
                     Title = "Learning Blazor from A to Z",
                     Price = 40,
                     PagesCount = 250,
                 }
        };

    public Task<List<Book>> GetAllBooksAsync()
    {
        return Task.FromResult(_allBooks);
    }

    public Task<Book> AddBookAsync(AddBookRequest request)
    {
        var book = new Book
        {
            AuthorName = request.AuthorName,
            Description = request.Description,
            PagesCount = request.PagesCount,
            Price = request.Price,
            Title = request.Title,
            Id = Guid.NewGuid().ToString(),
        };
        _allBooks.Add(book);

        return Task.FromResult(book);
    }

    public Task<Book?> GetByIdAsync(string id)
    {
        return Task.FromResult(_allBooks.FirstOrDefault(i => i.Id == id));
    }

    public Task AddReviewAsync(string bookId, AddBookReviewRequest review)
    {
        var book = _allBooks.FirstOrDefault(b => b.Id == bookId);
        if (book == null)
        {
            throw new DomainException("Book not found");
        }
        Console.WriteLine(book.Title);
        if (book.Reviews == null)
        {
            book.Reviews = new List<Review>();
        }
        Console.WriteLine(book.Reviews.Count);
        book.Reviews.Add(new()
        {
            Description = review.Description,
            Rating = review.Rating,
            Id = Guid.NewGuid().ToString(),
        });

        return Task.CompletedTask;
    }
}
