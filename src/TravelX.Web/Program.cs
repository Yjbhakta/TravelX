using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TravelX.Web;
using TravelX.Web.Services;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Configure HttpClient with service discovery
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000") });

// Add resilient HTTP client for API calls
builder.Services.AddHttpClient<HotelRegistrationService>(client =>
{
    client.BaseAddress = new Uri("http://localhost:5000");
})
.AddStandardResilienceHandler();

// Add MudBlazor services
builder.Services.AddMudServices();

// Add authentication
builder.Services.AddAuthorizationCore();

// Add registration service
builder.Services.AddScoped<HotelRegistrationService>();

await builder.Build().RunAsync();