using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Microservice.Domain.Contexts.Veiculo.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Handlers
{
    public class CadastrarVeiculoCommandHandler : CommandHandler, IRequestHandler<CadastrarVeiculoCommand, IActionResult>
    {
        private readonly IContratoRepository _contratoRepository;
        private readonly IValidarAdesaoService _validarAdesaoService;

        public CadastrarVeiculoCommandHandler(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        public async Task<IActionResult> Handle(CadastrarVeiculoCommand command, CancellationToken cancellationToken)
        {

            var dtoVeiculo = VeiculoDTO(command);

            var veiculo = new Microservice.Domain.Contexts.Veiculo.Veiculo(dtoVeiculo);

            return ReturnOk(new ValidarAdesaoView(validaContrato, mensagensContrato));
        }

        private VeiculoDTO VeiculoDTO(CadastrarVeiculoCommand command)
        {
            var veiculoDTO = new VeiculoDTO
            {
                Placa = command.Placa,
                Modelo = command.Modelo,
                Cor = command.Cor,
                Marca = command.Marca
            };
            return veiculoDTO;
        }
    }
}