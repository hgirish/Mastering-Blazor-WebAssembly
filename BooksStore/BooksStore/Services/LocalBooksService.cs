using BooksStore.Models;

namespace BooksStore.Services;

public class LocalBooksService : IBooksService
{
    static List<Book> _allBooks = new List<Book>
    {
        new Book
        {
            
            AuthorName = "John Smith",
            PublishingDate = new DateTime(2021, 01, 12),
            Title = "Blazor WebAssembly Guide",
            Description = "Blazor WebAssembly Guide by John Smith."
        },
         new Book
        {
            
            AuthorName = "John Smith",
            PublishingDate = new DateTime(2022, 02, 13),
            Title = "Mastering Blazor WebAssembly",
            Description =  "Mastering Blazor WebAssembly by John Smith"
        },
          new Book
        {
             
            AuthorName = "John Smith",
            PublishingDate = new DateTime(2021, 08, 01),
            Title = "Learning Blazor from A to Z",
            Description = "Learning Blazor from A to Z by John Smith"
        },
    };
    public Task<List<Book>> GetAllBooksAsync()
    {
        return Task.FromResult(_allBooks);
    }

    public Task<Book?> GetBookByIdAsync(string? id)
    {
        var book = _allBooks.SingleOrDefault(b=> b.Id  == id);
        return Task.FromResult(book);
        
    }
}