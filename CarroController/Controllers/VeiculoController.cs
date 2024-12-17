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

        /// <summary>
        /// Cadastra um novo veículo.
        /// </summary>
        /// <param name="request">Dados do veículo a ser cadastrado.</param>
        /// <returns>Resultado da operação de cadastro.</returns>
        [HttpPost("cadastrar-veiculo")]
        public async Task<IActionResult> CadastrarVeiculo([FromBody] CadastrarVeiculoRequest request)
        {
            var command = _mapper.Map<CadastrarVeiculoRequest, CadastrarVeiculoCommand>(request);
            var response = await _mediatorHandler.EnviarComandoAsync(command);

            return response;
        }

        /// <summary>
        /// Solicita o aluguel de um veículo.
        /// </summary>
        /// <param name="request">Dados do aluguel do veículo.</param>
        /// <returns>Resultado da operação de aluguel.</returns>
        [HttpPost("alugar-veiculo")]
        public async Task<IActionResult> AlugarVeiculo([FromBody] AlugarVeiculoRequest request)
        {
            var command = _mapper.Map<AlugarVeiculoRequest, AlugarVeiculoCommand>(request);
            var response = await _mediatorHandler.EnviarComandoAsync(command);

            return response;
        }

        /// <summary>
        /// Finaliza o aluguel de um veículo.
        /// </summary>
        /// <param name="request">Dados para finalizar o aluguel.</param>
        /// <returns>Resultado da operação de finalização do aluguel.</returns>
        [HttpPost("finalizar-aluguel")]
        public async Task<IActionResult> FinalizarAluguel([FromBody] FinalizarAluguelRequest request)
        {
            var command = _mapper.Map<FinalizarAluguelRequest, FinalizarAluguelCommand>(request);
            var response = await _mediatorHandler.EnviarComandoAsync(command);

            return response;
        }

        /// <summary>
        /// Obtém uma lista de veiculos já cadastrados.
        /// </summary>
        /// <param name="request">Parâmetros para obter os veículos.</param>
        /// <returns>Lista de veículos.</returns>
        [HttpGet("obter-veiculos")]
        public async Task<IActionResult> ObterVeiculos([FromQuery] ObterVeiculoRequest request)
        {
            var command = _mapper.Map<ObterVeiculoRequest, ObterVeiculoQuery>(request);
            var veiculos = await _mediatorHandler.ExecutarQueryAsync(command);

            return Ok(veiculos);
        }
    }
}