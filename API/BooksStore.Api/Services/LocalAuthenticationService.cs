﻿using BooksStore.Api.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BooksStore.Api.Services;

public class LocalAuthenticationService : IAuthenticationService
{
    private static List<User> _users = new()
        {
            new User(Guid.NewGuid(), "John", "Smith", "admin@masteringblazor.com", "Test.123", "Admin", "US"),
            new User(Guid.NewGuid(), "Ahmad", "Mozaffar", "ahmad.mozaffar@masteringblazor.com", "Test.123", "Customer", "UK"),
        };
    public Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
    {
        ArgumentNullException.ThrowIfNull(loginRequest);

        var user = _users.FirstOrDefault(x => 
        x.Username == loginRequest.Username
        && x.Password == loginRequest.Password);

        if (user == null)
        {
            throw new Exception("Invalid username or password");
        }
        var token = GenerateJwtToken(user);
        return Task.FromResult(new LoginResponse { Token = token });
    }

    private string GenerateJwtToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email, user.Username),
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.GivenName, user.FirstName),
            new Claim(ClaimTypes.Surname, user.LastName),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Country, user.Country),
        };

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("This key is to secure the access token, " +
            "it doesn't look like the best thing ever but let's see"));

        var token = new JwtSecurityToken(
            issuer: "booksstore.api",
            audience: "booksstore.customers",
            claims: claims,
            expires: DateTime.UtcNow.AddDays(30),
            signingCredentials: 
            new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

   
}    
internal record User(
    Guid Id,
    string FirstName,
    string LastName,
    string Username,
    string Password,
    string Role,
    string Country);