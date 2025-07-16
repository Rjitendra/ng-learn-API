using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Models.Context;
using Services;

var builder = WebApplication.CreateBuilder(args);

// 🔹 Logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// 🔹 Add services to the container
builder.Services.AddControllers();

// 🔹 Add Swagger/OpenAPI support
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Product API",
        Version = "v1",
        Description = "ASP.NET Core Web API with PostgreSQL, Repository Pattern, Events",
        Contact = new OpenApiContact
        {
            Name = "Your Name",
            Email = "yourname@example.com"
        }
    });
});

// PostgreSQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Dependency Injection
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IVersionedService<,>), typeof(VersionedService<,>));

// 🔹 CORS (Allow All — customize in production)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// 🔹 Error handling
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error"); // Define a proper error controller or endpoint
    app.UseHsts();                     // Strict Transport Security
}
app.UseHttpsRedirection();

app.UseCors("AllowAll");                         // Enable CORS
app.UseStaticFiles();                  // For serving static content if needed
app.UseRouting();

app.UseAuthorization();

// 🔹 Swagger UI
app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API v1");
    options.RoutePrefix = "swagger"; // Navigate to /swagger
});

app.MapControllers();                  // Map attribute-based controllers
app.MapGet("/health", () => "API is Healthy"); // Optional health check

app.Run();
