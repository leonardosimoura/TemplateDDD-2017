using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateDDD.AppService.Interface
{
    public interface IMapperService<TModel, TDestination> where TModel: class where TDestination : class
    {
        TModel MapearParaViewModel(TDestination entidade);

        TDestination MapearParaDomain(TModel entidade);

        IEnumerable<TModel> MapearParaViewModel(IEnumerable<TDestination> entidade);

        IEnumerable<TDestination> MapearParaDomain(IEnumerable<TModel> entidade);
    }
}
