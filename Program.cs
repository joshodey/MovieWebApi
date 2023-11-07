using Microsoft.EntityFrameworkCore;
using MoviesWebApi.Context;
using MoviesWebApi.Configuration;
using MoviesWebApi.Repisotory;
using MoviesWebApi.Entities;
using MoviesWebApi.IRepository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<MovieDbContext>(options =>
options.UseSqlite("Data Source = MovieDb"));

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IRepository<Movies>, Repository<Movies>>();
builder.Services.AddScoped<IRepository<Genres>, Repository<Genres>>();
builder.Services.AddScoped<IRepository<Ratings>, Repository<Ratings>>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
