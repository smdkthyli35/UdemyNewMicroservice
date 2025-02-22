﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace UdemyNewMicroservice.Shared.Extensions
{
    public static class CommonServiceExtension
    {
        public static IServiceCollection AddCommonServiceExt(this IServiceCollection services, Type assembly)
        {
            services.AddHttpContextAccessor();

            services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining(assembly));

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssemblyContaining(assembly);

            return services;
        }
    }
}