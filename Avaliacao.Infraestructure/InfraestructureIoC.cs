using System.Data;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Infraestructure.Data;
using Avaliacao.Infraestructure.Mediator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Avaliacao.Infraestructure
{
    public static class InfraestructureIoC
    {
        public static void ResolveInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddSingleton<IGatewayMessageBus, GatewayMessageBus>();

            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IHistoricoValidacaoCampoRepository, HistoricoValidacaoCampoRepository>();
            services.AddScoped<IContratoRepository, ContratoRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IDadosBeneficiarioRepository, DadosBeneficiarioRepository>();
            services.AddScoped<ICartaoRepository, CartaoRepository>();
            services.AddScoped<IHistoricoContratoBeneficiarioRepository, HistoricoContratoBeneficiarioRepository>();
            services.AddScoped<IContratoBeneficiarioRepository, ContratoBeneficiarioRepository>();
            services.AddScoped<IPlanoRepository, PlanoRepository>();
            services.AddScoped<IRestricaoVendaProdutosRepository, RestricaoVendaProdutosRepository>();

            var connectionString = configuration.GetConnectionString("DefaultConnection");
            services.AddTransient<IDbConnection>(_ => new NpgsqlConnection(connectionString));

            services.AddDbContext<ApplicationDbContext>(opt =>
              opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.ResolveMessageBus(configuration);
            //services.ResolveInfraestructureRabbitMQMessageBus(configuration);
        }
    }
}