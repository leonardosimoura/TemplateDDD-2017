using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using TemplateDDD.AppService.Interface;

namespace TemplateDDD.AppService.Service
{

    public class MapperService<TModel, TDestination> : IMapperService<TModel, TDestination> where TModel : class where TDestination : class
    {
        private readonly IMapper _mapper;

        public MapperService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TModel MapearParaViewModel(TDestination entidade)
        {
            return _mapper.Map<TDestination, TModel>(entidade);
        }

        public TDestination MapearParaDomain(TModel entidade)
        {
            return _mapper.Map<TModel, TDestination>(entidade);
        }

        public IEnumerable<TModel> MapearParaViewModel(IEnumerable<TDestination> entidade)
        {
            return _mapper.Map<IEnumerable<TDestination>, IEnumerable<TModel>>(entidade);
        }

        public IEnumerable<TDestination> MapearParaDomain(IEnumerable<TModel> entidade)
        {
            return _mapper.Map<IEnumerable<TModel>, IEnumerable<TDestination>>(entidade);
        }
    }
}
