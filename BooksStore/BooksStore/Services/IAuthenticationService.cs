using BooksStore.Models;

namespace BooksStore.Services;

public interface IAuthenticationService
{
    Task<LoginResponse> LoginUserAsync(LoginRequest loginRequest);
}