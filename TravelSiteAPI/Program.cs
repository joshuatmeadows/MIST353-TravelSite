using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TravelSiteAPI.Data;
using TravelSiteAPI.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddDbContext<DbContextClass>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
options.AddPolicy("AllowMyRazorPagesApp",
    builder =>
{
builder.WithOrigins("https://localhost:7146") // Specify the exact origin
       .AllowAnyHeader()
       .AllowAnyMethod();
});
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowMyRazorPagesApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
