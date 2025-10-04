using Backend.Models;
using Microsoft.EntityFrameworkCore;

var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

// Enable CORS for React app running on http://localhost:5173 which is different from the backend url http://localhost:3000
// for effective communication between frontend and backend, we have to enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.WithOrigins("http://localhost:5173") // React app url
                                .AllowAnyMethod()
                                .AllowAnyHeader();
                      });
});

// Add services to the container.
builder.Services.AddControllers();

string connectionString = builder.Configuration.GetConnectionString("Default") ?? throw new ArgumentNullException("Connection string 'Default' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString));

var app = builder.Build();

// Middleware to handle HTTP requests and responses
app.UseCors(MyAllowSpecificOrigins);
app.MapControllers();

app.Run();
