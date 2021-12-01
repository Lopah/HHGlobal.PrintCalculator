using System.Reflection;
using FluentValidation;
using HHGlobal.PrintCalculator.API.Behaviors;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace HHGlobal.PrintCalculator.API.Extensions;

public static class ServicesExtensions
{
    public static void AddMediatRService(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}