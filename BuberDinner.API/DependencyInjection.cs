using BuberDinner.API.Common.Errors;
using BuberDinner.API.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.API;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, DuberDinnerProblemDetailsFactory>();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddMappings();

        return services;
    }
}


