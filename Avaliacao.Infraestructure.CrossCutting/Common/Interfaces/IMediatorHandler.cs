using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Infraestructure.CrossCutting.Common.Interfaces
{
    public interface IMediatorHandler
    {

        Task<IActionResult> EnviarComandoAsync<T>(T comando) where T : Command;

        Task<TOutput> EnviarComandoAsync<TOutput, TInput>(TInput comando) where TInput : IRequest<TOutput>;

        Task<IActionResult> ExecutarQueryAsync<TInput>(TInput query) where TInput : Query;

        Task<TOutput> ExecutarQueryViewAsync<TOutput, TInput>(TInput query) where TInput : IRequest<TOutput>;
    }
}