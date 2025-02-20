using DOTNET_Day3;
using DOTNET_Day3.DOTNET_Day3;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IFileService, FileService>();
builder.Services.AddScoped<IOpenWeather, LocationRequest>();

builder.Services.AddSingleton<IGetGuidSingleton, GuidService>(); 
builder.Services.AddScoped<IGetGuidScoped, GuidService>();        
builder.Services.AddTransient<IGetGuidTransient, GuidService>();  


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
