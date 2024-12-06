using System.Data;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Infraestructure.Data;
using Avaliacao.Infraestructure.Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using Microsoft.EntityFrameworkCore;
using Avaliacao.Microservice.Domain.Contexts.Veiculo.Interfaces;
using Avaliacao.Infraestructure.Data.Repositories;

namespace Avaliacao.Infraestructure
{
    public static class InfraestructureIoC
    {
        public static void ResolveInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(connectionString));

            services.AddDbContext<ApplicationDbContext>(opt =>
              opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //services.ResolveInfraestructureRabbitMQMessageBus(configuration);
        }
    }
}