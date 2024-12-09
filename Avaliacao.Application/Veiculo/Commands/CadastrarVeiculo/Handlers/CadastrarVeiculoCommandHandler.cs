using Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Views;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Microservice.Domain.Contexts.Veiculo.Dto;
using Avaliacao.Microservice.Domain.Contexts.Veiculos.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo.Handlers
{
    public class CadastrarVeiculoCommandHandler : CommandHandler, IRequestHandler<CadastrarVeiculoCommand, IActionResult>
    {
        private IVeiculoRepository _veiculoRepository;

        public CadastrarVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IActionResult> Handle(CadastrarVeiculoCommand command, CancellationToken cancellationToken)
        {
            var dtoVeiculo = VeiculoDTO(command);

            var veiculo = new Microservice.Domain.Contexts.Veiculos.Veiculo(dtoVeiculo);

            if (veiculo is not null)
            {
                _veiculoRepository.CreateAsync(veiculo);
                await PersistirDados(_veiculoRepository.UnitOfWork);
            }


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