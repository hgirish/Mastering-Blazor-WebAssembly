using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BooksStore;

public class JwtAuthenticationStateProvider : AuthenticationStateProvider
{
    private const string ACCESS_TOKEN = "access_token";
    private readonly ILocalStorageService _storage;

    public JwtAuthenticationStateProvider(ILocalStorageService storage)
    {
        _storage = storage;
    }
    public override async Task<AuthenticationState> GetAuthenticationStateAsync()
    {
        if (await _storage.ContainKeyAsync(ACCESS_TOKEN))
        {
            // PRocess the token here
            var tokenAsString = await _storage.GetItemAsync<string>(ACCESS_TOKEN);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(tokenAsString);
            var identity = new ClaimsIdentity(token.Claims, "jwt");
            var user = new ClaimsPrincipal(identity);
            var authState = new AuthenticationState(user);
            NotifyAuthenticationStateChanged(Task.FromResult(authState));
            return authState;
        }
        var anonymousUser = new ClaimsPrincipal(
            new ClaimsIdentity());
        var anonymousAuthState = new AuthenticationState(anonymousUser);
        NotifyAuthenticationStateChanged(
            Task.FromResult(anonymousAuthState));
        return anonymousAuthState;
    }
}