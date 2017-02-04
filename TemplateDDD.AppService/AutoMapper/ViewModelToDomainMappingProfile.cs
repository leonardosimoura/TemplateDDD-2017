using AutoMapper;
using TemplateDDD.AppService.ViewModels;
using TemplateDDD.Domain.Entidade;

namespace TemplateDDD.AppService.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<UsuarioViewModel,Usuario>();
        }
    }
}