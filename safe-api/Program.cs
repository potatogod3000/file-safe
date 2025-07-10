using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using safe_api.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration["DatabaseConnection:FileSafeConnection"]
                       ?? throw new InvalidOperationException("Connection string" + "'DatabaseConnection:FileSafeConnection' not found.");

builder.Services.AddControllers();

builder.Services.AddDbContext<FileSafeDbContext>(x => x.UseNpgsql(connectionString));
builder.Services.AddIdentity<IdentityUser<string>, IdentityRole<string>>()
    .AddEntityFrameworkStores<FileSafeDbContext>();

var app = builder.Build();

app.MapControllers();
app.Run();
