using AutoMapper;
using Avaliacao.Application.Veiculo.Commands.AlugarVeiculo;

namespace Avaliacao.Microservice.WebAPI.DTOs.AlugarVeiculo.Maps
{
    public class AlugarVeiculoMap : Profile
    {
        public AlugarVeiculoMap()
        {
            CreateMap<AlugarVeiculoRequest, AlugarVeiculoCommand>()
    .ForMember(
        dest => dest.VeiculoId,
        opt => opt.MapFrom(src => src.VeiculoId)
    )
    .ForMember(
        dest => dest.DataInicio,
        opt => opt.MapFrom(src => src.DataInicio)
    )
    .ForMember(
        dest => dest.DataFim,
        opt => opt.MapFrom(src => src.DataFim)
    )
    .ForMember(
        dest => dest.Valor,
        opt => opt.MapFrom(src => src.Valor)
    )
    .ForMember(
        dest => dest.Status,
        opt => opt.MapFrom(src => src.Status)
    );
        }
    }
}