using Avaliacao.Microservice.WebAPI.Configurations;
using Avaliacao.Microservice.WebAPI.Configurations.Swagger;

try
{
    var builder = WebApplication.CreateBuilder(args);
    builder.Services.UseApiServices(builder.Configuration, typeof(Program));

    var app = builder.Build();
    app.UseAppBuildConfiguration(builder.Configuration);

    if (!app.Environment.IsProduction())
    {
        app.UseSwaggerConfig();
    }

    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Console.WriteLine("Erro", ex.Message);
}