using System.Reflection;
using System;
using System.Linq;
using Application.Common.Validation;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.AddMediatR(assembly);
            services.AddValidatorsFromAssembly(assembly);
            services.AddAllTransient(typeof(IContextualValidator<>), assembly);

            return services;
        }
    }
    
    public static class ServiceCollectionExtensions
    {
        public static void AddAllTransient(this IServiceCollection services, Type superType, Assembly assembly)
        {
            var types = assembly.DefinedTypes.Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == superType));
            foreach (var type in types)
            {
                if (type.IsGenericType)
                {
                    continue;
                }
                
                var genericSuperType = type.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == superType);
                services.AddTransient(genericSuperType, type);
            }
        }
    }
}
