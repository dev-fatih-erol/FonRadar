using FluentValidation;
using FluentValidation.AspNetCore;
using FonRadar.Application.Accounts.Validators;
using FonRadar.Application.Common.Accessors;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FonRadar.Application.Common.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserAccessor, UserAccessor>();

            services.AddMediatR(typeof(ServiceCollectionExtensions).Assembly);

            services.AddFluentValidationAutoValidation()
                .AddValidatorsFromAssemblyContaining<LoginValidator>();

            return services;
        }
    }
}