using Microsoft.AspNetCore.Localization;

namespace Avaliacao.Microservice.WebAPI.Configurations.Culture
{
    public static class CultureConfiguration
    {
        public static IServiceCollection SetDefaultCultureToBrazilian(this IServiceCollection services)
            => services.Configure<RequestLocalizationOptions>(o => o.DefaultRequestCulture = new RequestCulture("pt-BR"));
    }
}
