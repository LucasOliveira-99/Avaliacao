using AutoMapper;
using Avaliacao.Application.Veiculo.Commands.AlugarVeiculo;
using Avaliacao.Application.Veiculo.Commands.FinalizarAluguel;
using Avaliacao.Microservice.WebAPI.DTOs.AlugarVeiculo;

namespace Avaliacao.Microservice.WebAPI.DTOs.FinalizarAluguel.Maps
{
    public class FinalizarAluguelMap : Profile
    {
        public FinalizarAluguelMap()
        {
            CreateMap<FinalizarAluguelRequest, FinalizarAluguelCommand>()
    .ForMember(
        dest => dest.AluguelId,
        opt => opt.MapFrom(src => src.AluguelId)
    )
    .ForMember(
        dest => dest.DataDevolucao,
        opt => opt.MapFrom(src => src.DataDevolucao)
    );
        }
    }
}