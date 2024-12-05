using System.Reflection;
using Avaliacao.Application.Common.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Avaliacao.Application
{
    public static class ApplicationIoC
    {
        public static void ResolveApplication(this IServiceCollection services)
        {
            AssemblyScanner
            .FindValidatorsInAssembly(Assembly.GetAssembly(typeof(ApplicationIoC)))
            .ForEach(result => services.AddScoped(result.InterfaceType, result.ValidatorType));

            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddScoped(typeof(IPipelineBehavior<,>), typeof(FailFastRequestBehavior<,>));
            services.AddMediatR(
                typeof(ApplicationIoC),
                typeof(InfraestructureIoC)
            );
        }
    }
}