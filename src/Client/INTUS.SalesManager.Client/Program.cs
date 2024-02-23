using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
var baseAddress = builder.Configuration.GetValue<string>("ApplicationUrl")!;
builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});

await builder.Build().RunAsync();
