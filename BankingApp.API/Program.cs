using Microsoft.EntityFrameworkCore;
using BankingApp.Repository.Context;
using BankingApp.API.Filters;
using FluentValidation.AspNetCore;
using BankingApp.Service.Validations.User;
using BankingApp.Service.Mapping;
using BankingApp.API.Extensions;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();





builder.Services.AddControllers(options => options.Filters.Add(new ValidateFilterAttribute())).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<UserCreatDtoValidation>());

builder.Services.AddDbContext<BankingAppDbContext>(options =>
                                                options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddScopedWithExtension();

builder.Services.AddAutoMapper(typeof(MapProfile));



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
