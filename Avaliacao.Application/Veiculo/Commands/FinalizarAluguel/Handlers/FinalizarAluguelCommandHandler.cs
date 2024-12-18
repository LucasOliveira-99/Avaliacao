using Avaliacao.Application.Veiculo.Commands.AlugarVeiculo.Views;
using Avaliacao.Application.Veiculo.Commands.FinalizarAluguel.Views;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Microservice.Domain.Contexts.Alugueis.Interfaces;
using Avaliacao.Microservice.Domain.Contexts.Veiculos.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Application.Veiculo.Commands.FinalizarAluguel.Handlers
{
    public class FinalizarAluguelCommandHandler : CommandHandler, IRequestHandler<FinalizarAluguelCommand, IActionResult>
    {
        private readonly IVeiculoRepository _veiculoRepository;
        private readonly IAluguelRepository _aluguelRepository;

        public FinalizarAluguelCommandHandler(IVeiculoRepository veiculoRepository, IAluguelRepository aluguelRepository)
        {
            _veiculoRepository = veiculoRepository;
            _aluguelRepository = aluguelRepository;
        }

        public async Task<IActionResult> Handle(FinalizarAluguelCommand command, CancellationToken cancellationToken)
        {
            var aluguel = await _aluguelRepository.ObterAluguel(command.AluguelId);

            if (aluguel is null)
            {
                return ReturnNotFound<FinalizarAluguelView>("Aluguel não encontrado");
            }

            aluguel.FinalizarAluguel(command.DataDevolucao);

            var veiculo = await _veiculoRepository.ObterVeiculoPorId(aluguel.VeiculoId);

            //Atualizar status veiculo
            veiculo.MarcarComoDisponivel();
            _veiculoRepository.UpdateAsync(veiculo);
            await PersistirDados(_veiculoRepository.UnitOfWork);

            _aluguelRepository.UpdateAsync(aluguel);
            await PersistirDados(_aluguelRepository.UnitOfWork);

            return ReturnOk(new AlugarVeiculoView(aluguel));
        }
    }
}