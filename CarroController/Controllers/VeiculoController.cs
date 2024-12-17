using AutoMapper;
using Avaliacao.Application.Veiculo.Commands.AlugarVeiculo;
using Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo;
using Avaliacao.Application.Veiculo.Commands.FinalizarAluguel;
using Avaliacao.Application.Veiculo.Commands.ObterVeiculo;
using Avaliacao.Infraestructure.CrossCutting.Common.Interfaces;
using Avaliacao.Microservice.WebAPI.Controllers.Common;
using Avaliacao.Microservice.WebAPI.DTOs.AlugarVeiculo;
using Avaliacao.Microservice.WebAPI.DTOs.CadastrarVeiculo;
using Avaliacao.Microservice.WebAPI.DTOs.FinalizarAluguel;
using Avaliacao.Microservice.WebAPI.DTOs.ObterVeiculo;
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

        [HttpPost("alugar-veiculo")]
        public async Task<IActionResult> AlugarVeiculo([FromBody] AlugarVeiculoRequest request)
        {
            var command = _mapper.Map<AlugarVeiculoRequest, AlugarVeiculoCommand>(request);
            var response = await _mediatorHandler.EnviarComandoAsync(command);

            return response;
        }

        [HttpPost("finalizar-aluguel")]
        public async Task<IActionResult> FinalizarAluguel([FromBody] FinalizarAluguelRequest request)
        {
            var command = _mapper.Map<FinalizarAluguelRequest, FinalizarAluguelCommand>(request);
            var response = await _mediatorHandler.EnviarComandoAsync(command);

            return response;
        }

        [HttpGet("obter-veiculos")]
        public async Task<IActionResult> ObterVeiculos([FromQuery] ObterVeiculoRequest request)
        {
            var command = _mapper.Map<ObterVeiculoRequest, ObterVeiculoQuery>(request);
            var veiculos = await _mediatorHandler.ExecutarQueryAsync(command);

            return Ok(veiculos);
        }
    }
}