using Microsoft.EntityFrameworkCore;
using SunbedSaaS.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

// Connection to the database (Reads from appsettings.json file)
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();

// OpenAPI is the new way .NET 9+ handles API documentation (replaces Swagger)
builder.Services.AddOpenApi();

var app = builder.Build();

// 2. MIDDLEWARE (The "Pipe" through which requests flow)
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// This tells the app to look at your Controllers (we'll make these later)
app.MapControllers();

app.Run();