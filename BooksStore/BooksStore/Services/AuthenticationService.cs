using BooksStore.Models;
using System.Net.Http.Json;

namespace BooksStore.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly HttpClient _httpClient;

    public AuthenticationService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest)
    {
        var response = await _httpClient.PostAsJsonAsync("authentication/login", loginRequest);

        if (response.IsSuccessStatusCode)
        {
            return await response.Content.ReadFromJsonAsync<LoginResponse>();
        }
        var error = await response.Content.ReadFromJsonAsync<ApiErrorResponse>();
        await Console.Out.WriteLineAsync(error?.Message);
        throw new Exception(error?.Message);
    }
}