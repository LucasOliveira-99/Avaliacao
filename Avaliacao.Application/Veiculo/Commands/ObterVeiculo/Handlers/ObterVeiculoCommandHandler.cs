using Avaliacao.Application.Veiculo.Commands.ObterVeiculo.Views;
using Avaliacao.Infraestructure.CrossCutting.Common.CQS;
using Avaliacao.Microservice.Domain.Contexts.Veiculos.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Avaliacao.Application.Veiculo.Commands.ObterVeiculo.Handlers
{
    public class ObterVeiculoCommandHandler : CommandHandler, IRequestHandler<ObterVeiculoQuery, IActionResult>
    {
        private readonly IVeiculoRepository _veiculoRepository;

        public ObterVeiculoCommandHandler(IVeiculoRepository veiculoRepository)
        {
            _veiculoRepository = veiculoRepository;
        }

        public async Task<IActionResult> Handle(ObterVeiculoQuery command, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.ObterVeiculos(command.VeiculoId);

            if (veiculo is null)
            {
                return ReturnNotFound<ObterVeiculoView>("Veículo não encontrado");
            }

            return RetornaOkComLista(veiculo.Select(x => new ObterVeiculoView(x)).ToList());
        }
    }
}