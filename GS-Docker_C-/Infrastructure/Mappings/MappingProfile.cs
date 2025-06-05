using AutoMapper;
using GeoAlertaC.Application.DTOs.Request;
using GeoAlertaC.Application.DTOs.Response;
using GeoAlertaC.Domain.Entities;

namespace GeoAlertaC.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            // Usuario <-> UsuarioRequest
            CreateMap<UsuarioRequest, Usuario>();
            CreateMap<Usuario, UsuarioResponse>();

            // Endereco <-> EnderecoRequest
            CreateMap<EnderecoRequest, Endereco>();
            CreateMap<Endereco, EnderecoResponse>();

            // Alerta -> AlertaResponse
            CreateMap<Alertas, AlertaResponse>()
                .ForMember(dest => dest.NivelRisco, opt => opt.MapFrom(src => src.NivelRisco.ToString()));

            // DadosClimaticosRequest -> Alertas (se for utilizado para gerar um alerta)
            CreateMap<DadosClimaticosRequest, Alertas>()
                .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom(src => src.UsuarioId))
                .ForMember(dest => dest.EnderecoId, opt => opt.MapFrom(src => src.EnderecoId))
                .ForMember(dest => dest.Descricao, opt => opt.Ignore()) // Pode ser calculado
                .ForMember(dest => dest.NivelRisco, opt => opt.Ignore()) // Pode ser calculado
                .ForMember(dest => dest.Probabilidade, opt => opt.Ignore()) // Pode ser calculado
                .ForMember(dest => dest.DataHora, opt => opt.MapFrom(_ => DateTime.UtcNow));



        }
    }
}
