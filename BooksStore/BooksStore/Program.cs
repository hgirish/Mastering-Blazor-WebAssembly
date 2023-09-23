using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BooksStore;
using BooksStore.Services;
using Blazored.LocalStorage;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Components.Authorization;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped<DemoLoggingHandler>();
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();

//builder.Services.AddScoped(sp => new HttpClient { 
//    BaseAddress = new Uri(builder.Configuration["ApiUrl"]) });
builder.Services.AddHttpClient("BooksStore.API", httpClient =>
httpClient.BaseAddress = new Uri(builder.Configuration["ApiUrl"]))
    .AddHttpMessageHandler<DemoLoggingHandler>();

builder.Services.AddScoped(sp =>
sp.GetRequiredService<IHttpClientFactory>()
.CreateClient("BooksStore.API"));

builder.Services.AddScoped<ILoggingService, ConsoleLoggingService>();
builder.Services.AddScoped<IBooksService, BooksHttpClientService>();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddSingleton<AppStateContainer>();

builder.Services.AddAuthorizationCore();
builder.Services.AddScoped<AuthenticationStateProvider, JwtAuthenticationStateProvider>();

await builder.Build().RunAsync();
