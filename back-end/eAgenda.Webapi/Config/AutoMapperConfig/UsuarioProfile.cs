using AutoMapper;
using eAgenda.Dominio.ModuloAutenticacao;
using eAgenda.Webapi.ViewModels.ModuloAutenticacao;

namespace eAgenda.Webapi.Config.AutoMapperConfig
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<RegistrarUsuarioViewModel, Usuario>()
                .ForMember(destino => destino.EmailConfirmed, opt => opt.MapFrom(origem => true))
                .ForMember(destino => destino.UserName, opt => opt.MapFrom(origem => origem.Email));

        }
    }
}
