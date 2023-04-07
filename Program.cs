using System.Reflection;
using Aula01.Context;
using Aula01.Repositories;
using Aula01.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation(options =>
             {
                 // Validate child properties and root collection elements
                 options.ImplicitlyValidateChildProperties = true;
                 options.ImplicitlyValidateRootCollectionElements = true;

                 // Automatic registration of validators in assembly
                 options.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
                });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// builder.Services.AddDbContext<MovieContext>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("MovieContext"))
// );

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
