using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using hello_razor.Models;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// choose sqlite for dev and sqlserver for prod
if(builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<HelloRazorMovieContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("HelloRazorMovieContext")));
}
else
{
    builder.Services.AddDbContext<HelloRazorMovieContext>(options=>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionMovieContext")));
}

var app = builder.Build();

// add seed initializer
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

// app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
