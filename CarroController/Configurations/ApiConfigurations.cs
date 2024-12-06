using Avaliacao.Infraestructure.CrossCutting.IoC;
using Avaliacao.Microservice.WebAPI.Configurations.Culture;
using Avaliacao.Microservice.WebAPI.Configurations.Swagger;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Reflection;
using System.Text.Json.Serialization;


namespace Avaliacao.Microservice.WebAPI.Configurations
{
    public static class ApiConfiguration
    {
        public static IServiceCollection UseApiServices(this IServiceCollection services, IConfiguration configuration, Type startup)
        {
            
            services.SetDefaultCultureToBrazilian();
            services.AddControllers().AddNewtonsoftJson();

            services.Configure<JsonOptions>(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new DateTimeConverter());
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });
            services.Configure<RequestLocalizationOptions>(options => options.DefaultRequestCulture = new RequestCulture("pt-BR"));

            services.AddAutoMapper(Assembly.GetAssembly(typeof(ApiConfiguration)));

            services.AddEndpointsApiExplorer();

            services.DependencyInjection(configuration, startup);

            services.AddSwaggerService();

            services.AddMemoryCache();

            services.AddDistributedMemoryCache();

            services.AddOptions();

            return services;
        }
    }
}
