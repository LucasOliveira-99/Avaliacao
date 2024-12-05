using System.Diagnostics;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Avaliacao.Application.Common.Behavior
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
       where TRequest : IRequest<TResponse> where TResponse : IActionResult
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var req = (request as Command);
            var aggregateId = req?.AggregateId;
            var body = string.Empty;
            TResponse response;

            _logger.LogInformation($"[INICIO] Execução do comando: {typeof(TRequest).Name} | Agreggate Id: {aggregateId} | Body: {body}");
            var stopwatch = Stopwatch.StartNew();

            try
            {
                response = await next();
            }
            catch (Exception ex)
            {
                _logger.LogError($"[ERRO] Exception na execução do comando: {typeof(TRequest).Name} | Agreggate Id: {aggregateId} | Body: {body} | Exception: {ex}");
                throw;
            }
            finally
            {
                stopwatch.Stop();
                _logger.LogInformation($"[FIM] Execução do comando: {typeof(TRequest).Name} | Agreggate Id: {aggregateId} | Execution time={stopwatch.ElapsedMilliseconds}ms");
            }

            return response!;
        }
    }
}