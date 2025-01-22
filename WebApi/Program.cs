using Dal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SchoolContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolDb")
    )
);

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    app.Logger.LogInformation("Middleware start");
    await next.Invoke();
    app.Logger.LogInformation("Middleware end");
});

app.UseStaticFiles();

app.MapControllers();

app.Run();
