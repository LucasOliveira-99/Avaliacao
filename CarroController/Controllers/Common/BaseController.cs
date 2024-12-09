using AutoMapper;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Microservice.WebAPI.Controllers.Common
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected readonly IMapper _mapper;
        protected readonly IMediatorHandler _mediatorHandler;

        protected BaseController()
        {
        }

        protected BaseController(IMapper mapper, IMediatorHandler mediatorHandler)
        {
            _mapper = mapper;
            _mediatorHandler = mediatorHandler;
        }

        protected virtual async Task<IActionResult> SendCommand<TRequestType, TCommandType>(TRequestType request) where TCommandType : Command
            => await _mediatorHandler.EnviarComandoAsync(_mapper.Map<TRequestType, TCommandType>(request));

        protected virtual async Task<IActionResult> SendCommand<TCommandType>(TCommandType command) where TCommandType : Command
            => await _mediatorHandler.EnviarComandoAsync(command);

        protected virtual async Task<IActionResult> ExecutarQueryAsync<TInput>(TInput query) where TInput : Query
        => await _mediatorHandler.ExecutarQueryAsync(query);
    }
}