

using BooksStore.Api.Models;

namespace BooksStore.Api.Services;

public interface IAuthenticationService
{
    Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
}