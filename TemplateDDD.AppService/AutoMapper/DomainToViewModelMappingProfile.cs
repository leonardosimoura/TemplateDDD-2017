using AutoMapper;
using TemplateDDD.AppService.ViewModels;
using TemplateDDD.Domain.Entidade;

namespace TemplateDDD.AppService.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}