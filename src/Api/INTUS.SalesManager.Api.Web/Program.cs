using INTUS.SalesManager.Api.Web.Components;
using INTUS.SalesManager.Api.Web.Middleware;
using INTUS.SalesManager.Application;
using INTUS.SalesManager.Domain.Services.Lookups;
using INTUS.SalesManager.Domain.Services.Orders;
using INTUS.SalesManager.Infrastructure.Common;
using INTUS.SalesManager.Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<DbContext, SalesManagerDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddMediatR(it => it.RegisterServicesFromAssemblies(Module.Assembly));
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));
builder.Services.AddScoped(typeof(ILookupService<>), typeof(LookupService<>));

builder.Services.AddTransient<ExceptionHandlingMiddleware>();

var baseAddress = builder.Configuration.GetValue<string>("ApplicationUrl")!;
builder.Services.AddScoped(_ => new HttpClient
{
    BaseAddress = new Uri(baseAddress)
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.MapControllers();
app.UseSwagger();
app.UseSwaggerUI();

app.MapRazorComponents<App>()
    .AddInteractiveWebAssemblyRenderMode()
    .AddInteractiveServerRenderMode()
    .AddAdditionalAssemblies(typeof(INTUS.SalesManager.Client._Imports).Assembly);

app.Run();
