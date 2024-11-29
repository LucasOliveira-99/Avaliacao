using AutoMapper;
using Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Microservice.WebAPI.Controllers.Common;
using Avaliacao.Microservice.WebAPI.DTOs.CadastrarVeiculo;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Microservice.WebAPI.Controllers
{
    public class VeiculoController : BaseController
    {
        public VeiculoController(IMapper mapper, IMediatorHandler mediatorHandler) : base(mapper, mediatorHandler)
        {
        }

        [HttpPost("cadastrar-veiculo")]
        public async Task<IActionResult> CadastrarVeiculo([FromBody] CadastrarVeiculoRequest request)
        {
            var command = _mapper.Map<CadastrarVeiculoRequest, CadastrarVeiculoCommand>(request);
            var response = await _mediatorHandler.EnviarComandoAsync(command);

            return response;
        }
    }
}
