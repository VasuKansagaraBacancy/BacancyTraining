using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies() // Enable lazy loading proxies
           .UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")) // Your connection string from appsettings.json
           .LogTo(Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information); // Logging SQL queries
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Migrate & Seed dynamic data
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    // Apply any pending migrations
    context.Database.Migrate();

    // Seed dynamic data
    context.SeedDynamicData();
}

app.Run();
