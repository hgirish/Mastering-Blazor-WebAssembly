using BooksStore.Models;
using System.Net.Http.Json;

namespace BooksStore.Services;

public class BooksHttpClientService: IBooksService
{
    private readonly HttpClient _httpClient;

    public BooksHttpClientService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task AddBookAsync(SubmitBook book)
    {
        var response = await _httpClient.PostAsJsonAsync("books", book);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
            Console.WriteLine(error.Message);
        }
    }

	public async Task AddReviewAsync(string bookId, AddBookReviewRequest review)
	{
        var response = await _httpClient.PostAsJsonAsync($"books/review/{bookId}", review);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
            Console.WriteLine(error);
        }
	}

	public async Task<List<Book>> GetAllBooksAsync()
    {
        var response = await _httpClient.GetAsync("books");
        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<List<Book>>();
        }
        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
            throw new Exception(errorResponse?.Message);
        }
    }

    public async Task<Book?> GetBookByIdAsync(string? id)
    {
        var response = await _httpClient.GetAsync($"books/{id}");
        if (response.IsSuccessStatusCode)
        {
            var book =  await response.Content.ReadFromJsonAsync<Book>();
            Console.WriteLine(book?.Title);
            return book;
        }
        else
        {
            var errorResponse = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
             Console.WriteLine(errorResponse?.Message);
            throw new Exception(errorResponse?.Message);
        }
    }

	public async Task UploadBookCoverAsync(string bookId, Stream stream, string fileName)
	{
        using var content = new MultipartFormDataContent();
        using var fileContent = new StreamContent(stream);
        fileContent.Headers.ContentDisposition = 
            new System.Net.Http.Headers.ContentDispositionHeaderValue("form-data")
        {
            Name = "file",
            FileName = fileName
        };
        content.Add(fileContent);
        var response = await _httpClient.PostAsync($"/books/{bookId}/cover", content);
        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
            Console.WriteLine(error?.Message);
        }

	}
}