using System;
using FluentValidation;
using Hellang.Middleware.ProblemDetails;
using HHGlobal.PrintCalculator.API.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatRService();
builder.Services.AddProblemDetails(options =>
{
    options.MapToStatusCode<ValidationException>(StatusCodes.Status400BadRequest);
    options.MapToStatusCode<ArgumentNullException>(StatusCodes.Status400BadRequest);
})
    .AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseProblemDetails();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.MapControllers();

app.Run();