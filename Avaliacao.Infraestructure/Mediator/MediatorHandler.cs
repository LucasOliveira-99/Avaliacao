using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Infraestructure.Mediator
{
    public class MediatorHandler : IMediatorHandler
    {
        private readonly IMediator _mediator;

        public MediatorHandler(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> EnviarComandoAsync<T>(T comando) where T : Command
            => await _mediator.Send(comando);

        public async Task<TOutput> EnviarComandoAsync<TOutput, TInput>(TInput comando) where TInput : IRequest<TOutput>
           => await _mediator.Send(comando);

        public async Task<IActionResult> ExecutarQueryAsync<TInput>(TInput query) where TInput : Query
              => (IActionResult)await _mediator.Send(query);

        public async Task<TOutput> ExecutarQueryViewAsync<TOutput, TInput>(TInput query) where TInput : IRequest<TOutput>
                => await _mediator.Send(query);

        public Task PublicarEventoAsync<T>(T evento) where T : Event
        {
            throw new NotImplementedException();
        }
    }
}