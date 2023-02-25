using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Mega_Desk_Web.Data;
using Mega_Desk_Web.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<Mega_Desk_WebContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Mega_Desk_WebContext") ?? throw new InvalidOperationException("Connection string 'Mega_Desk_WebContext' not found.")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
