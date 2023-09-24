using BooksStore.Api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var AllowAllOrigins = "AllowAllOrigins";
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<BooksService>();
builder.Services.AddScoped<IAuthenticationService, LocalAuthenticationService>();
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowAllOrigins, policy =>
    {
        policy
   .AllowAnyHeader()
   .AllowAnyMethod()
   .AllowAnyOrigin();
    });
});
//builder.Services.AddAuthentication(options =>
//{
//    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(options =>
//    {
//        options.Audience = "http://localhost:5115/";
//        options.Authority = "https://localhost:44376/";
//    });

//auth.DefaultAuthenticateScheme = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//{
//    ValidateIssuer = true,
//    ValidateAudience = true,
//    ValidAudience = "https://booksstore-masteringblazorassembly.com",
//    ValidIssuer = "https://booksstore-masteringblazorwebassembly.com/api",
//    RequireExpirationTime = true,
//    IssuerSigningKey = new SymmetricSecurityKey(
//           Encoding.UTF8.GetBytes("This key is to secure the access token, " +
//           "it doesn't look like the best thing ever but let's see")),
//    ValidateIssuerSigningKey = true
//};
var app = builder.Build();

app.UseCors(AllowAllOrigins);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
   // IdentityModelEventSource.ShowPII = true;
}

app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
