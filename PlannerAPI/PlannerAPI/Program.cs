using Microsoft.EntityFrameworkCore;
using PlannerAPI.Models;

var builder = WebApplication.CreateBuilder(args);

// Dodanie konfiguracji CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowLocalhost8081",
        policy =>
        {
            policy
                .WithOrigins(
                    "http://localhost:8081",
                    "http://127.0.0.1:8081",
                    "http://192.168.0.100:8081" // jeœli uruchamiasz na fizycznym telefonie
                )
                .AllowAnyHeader()
                .AllowAnyMethod();

        });
});

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// U¿ycie CORS – bardzo wa¿ne: to musi byæ przed UseAuthorization
app.UseCors("AllowLocalhost8081");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
