using DOTNET_Day2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
IConfiguration configuration = app.Configuration;

string key = configuration.GetSection("Tokens:key").Value;
Console.WriteLine(key);

app.UseErrorHandlerMiddleware();

app.UseCustomMiddleware();

app.Use(async (context, next) =>
{
    await context.Response.WriteAsync("use method middleware");
    await next();
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("run method middleware");
});

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