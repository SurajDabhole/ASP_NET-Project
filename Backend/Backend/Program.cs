using Backend.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentNullException("Connection string 'Default' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Middleware to handle HTTP requests and responses
app.MapControllers();

app.Run();
