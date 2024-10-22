using BookTok.Application.Users;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookTok.Application.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        var applicationAssembly = typeof(ServiceCollectionExtension).Assembly;

        services.AddAutoMapper(applicationAssembly);
        services.AddValidatorsFromAssembly(applicationAssembly).AddFluentValidationAutoValidation();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(applicationAssembly));

        services.AddHttpContextAccessor();
        services.AddScoped<IUserContext, UserContext>();
    }
}
