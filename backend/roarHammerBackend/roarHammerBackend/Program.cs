using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using roarHammerBackend.Models;
using roarHammerBackend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add MongoDB settings to the service container
builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

// Register the DarkAngelService to handle MongoDB operations
builder.Services.AddSingleton<DarkAngelService>();

// Enable MVC pattern with controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Step 1: Configure CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); // Enable Swagger
    app.UseSwaggerUI(); // Enable Swagger UI
}

// Step 2: Use CORS middleware
app.UseCors("AllowAllOrigins");

app.UseHttpsRedirection(); // Redirect HTTP requests to HTTPS

app.MapControllers(); // Map attribute-routed controllers for the DarkAngels API

app.Run(); // Run the application