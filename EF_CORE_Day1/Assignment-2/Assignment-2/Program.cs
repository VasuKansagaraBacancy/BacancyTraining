using Assignment_2.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Scoped 
builder.Services.AddDbContext<EFCoreDBContext>(options =>
    options.UseSqlServer(connectionString), ServiceLifetime.Scoped);

// Singleton 

// builder.Services.AddDbContext<EFCoreDBContext>(options =>
//     options.UseSqlServer(connectionString), ServiceLifetime.Singleton);

// Transient

// builder.Services.AddDbContext<EFCoreDBContext>(options =>
//     options.UseSqlServer(connectionString), ServiceLifetime.Transient);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
