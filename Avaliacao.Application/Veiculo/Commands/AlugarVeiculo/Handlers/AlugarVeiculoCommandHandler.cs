using Avaliacao.Application.Veiculo.Commands.AlugarVeiculo.Views;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Microservice.Domain.Contexts.Alugueis.Dto;
using Avaliacao.Microservice.Domain.Contexts.Alugueis.Interfaces;
using Avaliacao.Microservice.Domain.Contexts.Veiculos.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Application.Veiculo.Commands.AlugarVeiculo.Handlers
{
    public class AlugarVeiculoCommandHandler : CommandHandler, IRequestHandler<AlugarVeiculoCommand, IActionResult>
    {
        private IVeiculoRepository _veiculoRepository;
        private IAluguelRepository _aluguelRepository;

        public AlugarVeiculoCommandHandler(IVeiculoRepository veiculoRepository, IAluguelRepository aluguelRepository)
        {
            _veiculoRepository = veiculoRepository;
            _aluguelRepository = aluguelRepository;
        }

        public async Task<IActionResult> Handle(AlugarVeiculoCommand command, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.ObterVeiculoPorId(command.VeiculoId);

            if (veiculo is null)
            {
                return ReturnNotFound<AlugarVeiculoView>("Veículo não encontrado");
            }

            if (!veiculo.EstaDisponivel())
            {
                return ReturnBadRequest<AlugarVeiculoView>("Veículo indisponível para aluguel");
            }

            var dtoAlugarVeiculo = AlugarVeiculoDTO(command);

            var aluguel = new Microservice.Domain.Contexts.Alugueis.Aluguel(dtoAlugarVeiculo);

            //Atualizar status veiculo
            veiculo.MarcarComoIndisponivel();
            _veiculoRepository.UpdateAsync(veiculo);
            await PersistirDados(_veiculoRepository.UnitOfWork);

            if (aluguel is not null)
            {
                _aluguelRepository.CreateAsync(aluguel);
                await PersistirDados(_aluguelRepository.UnitOfWork);
            }

            return ReturnOk(new AlugarVeiculoView(aluguel));
        }

        private AlugarVeiculoDTO AlugarVeiculoDTO(AlugarVeiculoCommand command)
        {
            var aluguelDTO = new AlugarVeiculoDTO
            {
                VeiculoId = command.VeiculoId,
                DataInicio = command.DataInicio,
                DataFim = command.DataFim,
                Valor = command.Valor
            };
            return aluguelDTO;
        }
    }
}