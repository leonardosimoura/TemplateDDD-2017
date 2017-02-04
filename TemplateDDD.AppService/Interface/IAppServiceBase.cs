using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Interface.UnitOfWork;

namespace TemplateDDD.AppService.Interface
{
    public interface IAppServiceBase<TModel> where TModel : class 
    {

        void Adicionar(ref TModel entidade);

        void AdicionarMuitos(ref IEnumerable<TModel> entidade);

        void Atualizar(TModel entidade);

        void AtualizarMuitos(IEnumerable<TModel> entidade);

        void Remover(params object[] id);

        void RemoverMuitos(IEnumerable<object[]> id);

        TModel SelecionarPorId(params object[] id);

        IEnumerable<TModel> SelecionarTodos();
    }
}
