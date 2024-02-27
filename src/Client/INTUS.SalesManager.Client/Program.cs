using INTUS.SalesManager.Client;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Radzen;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddRadzenComponents();
var baseAddress = builder.Configuration.GetValue<string>("ApplicationUrl")!;
builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});
builder.Services.AddScoped<SalesManagerClientService>();

await builder.Build().RunAsync();
