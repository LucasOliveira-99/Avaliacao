using AutoMapper;
using Avaliacao.Application.Veiculo.Commands.CadastrarVeiculo;

namespace Avaliacao.Microservice.WebAPI.DTOs.CadastrarVeiculo.Maps
{
    public class CadastrarVeiculoMap : Profile
    {
        public CadastrarVeiculoMap()
        {
            CreateMap<CadastrarVeiculoRequest, CadastrarVeiculoCommand>()
    .ForMember(
        dest => dest.Placa,
        opt => opt.MapFrom(src => src.Placa)
    )
    .ForMember(
        dest => dest.Modelo,
        opt => opt.MapFrom(src => src.Modelo)
    )
    .ForMember(
        dest => dest.Marca,
        opt => opt.MapFrom(src => src.Marca)
    )
    .ForMember(
        dest => dest.Cor,
        opt => opt.MapFrom(src => src.Cor)
    );
        }
    }
}
