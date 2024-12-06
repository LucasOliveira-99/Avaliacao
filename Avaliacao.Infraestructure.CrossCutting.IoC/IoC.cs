using Avaliacao.Application;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avaliacao.Infraestructure.CrossCutting.IoC
{
    public static class IoC
    {
        public static void DependencyInjection(this IServiceCollection services, IConfiguration configuration, Type startup)
        {
            services.AddAutoMapper(
               typeof(ApplicationIoC),
               typeof(InfraestructureIoC),
                startup
           );

            services.ResolveApplication();

            services.ResolveInfraestructure(configuration);
        }
    }
}