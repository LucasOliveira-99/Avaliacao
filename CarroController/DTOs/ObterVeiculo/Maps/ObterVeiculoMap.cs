using AutoMapper;
using Avaliacao.Application.Veiculo.Commands.ObterVeiculo;

namespace Avaliacao.Microservice.WebAPI.DTOs.ObterVeiculo.Maps
{
    public class ObterVeiculoMap : Profile
    {
        public ObterVeiculoMap()
        {
            CreateMap<ObterVeiculoRequest, ObterVeiculoQuery>()
    .ForMember(
        dest => dest.VeiculoId,
        opt => opt.MapFrom(src => src.VeiculoId)
    );
        }
    }
}