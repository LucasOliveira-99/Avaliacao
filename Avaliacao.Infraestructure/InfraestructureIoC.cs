using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Infraestructure.Data;
using Avaliacao.Infraestructure.Data.Repositories;
using Avaliacao.Infraestructure.Mediator;
using Avaliacao.Microservice.Domain.Contexts.Alugueis.Interfaces;
using Avaliacao.Microservice.Domain.Contexts.Veiculos.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using System.Data;

namespace Avaliacao.Infraestructure
{
    public static class InfraestructureIoC
    {
        public static void ResolveInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IAluguelRepository, AluguelRepository>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(connectionString));

            services.AddDbContext<ApplicationDbContext>(opt =>
              opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            //services.ResolveInfraestructureRabbitMQMessageBus(configuration);
        }
    }
}