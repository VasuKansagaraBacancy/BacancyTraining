using DOTNET_Day2.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var configuration = builder.Configuration;
string key = configuration.GetSection("Tokens:key").Value;
Console.WriteLine($"Token Key: {key}");

builder.Services.AddCors(options =>
{
    options.AddPolicy("ConfigureCors", policy =>
    {
        Console.WriteLine($"Inside CORS Policy - Token Key: {key}"); 
    });
});

var app = builder.Build();

app.UseCors("ConfigureCors");

app.UseErrorHandlerMiddleware();
app.UseCustomMiddleware();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Middleware - Token Key: {key}");
    await context.Response.WriteAsync("use method middleware\n");
    await next();
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("run method middleware\n");
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();