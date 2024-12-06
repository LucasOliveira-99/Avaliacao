using Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Views;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Microservice.Domain.Contexts.Veiculo.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Handlers
{
    public class CadastrarVeiculoCommandHandler : CommandHandler, IRequestHandler<CadastrarVeiculoCommand, IActionResult>
    {
        public async Task<IActionResult> Handle(CadastrarVeiculoCommand command, CancellationToken cancellationToken)
        {

            var dtoVeiculo = VeiculoDTO(command);

            var veiculo = new Microservice.Domain.Contexts.Veiculo.Veiculo(dtoVeiculo);

            return ReturnOk(new CadastrarVeiculoView(veiculo));
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