namespace Avaliacao.Microservice.WebAPI.Configurations
{
    public static class AppBuildConfiguration
    {
        public static IApplicationBuilder UseAppBuildConfiguration(this IApplicationBuilder applicationBuilder, IConfiguration configuration)
        {
            applicationBuilder.UseHttpsRedirection();

            //applicationBuilder.UseAuthentication();
            //applicationBuilder.UseAuthorization();

            return applicationBuilder;
        }
    }
}
