using Dal;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<SchoolContext>(
    optionsBuilder => optionsBuilder.UseSqlServer(
        builder.Configuration.GetConnectionString("SchoolDb")
    )
);

builder.Services.AddSwaggerGen(c =>
{
    // indiquer le chemin du fichier de documentation
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    c.IncludeXmlComments(xmlPath);

});

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader();
        policy.WithMethods("GET", "POST", "PUT", "DELETE", "OPTIONS");
        policy.WithOrigins("http://localhost:4200");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseCors();

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

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
