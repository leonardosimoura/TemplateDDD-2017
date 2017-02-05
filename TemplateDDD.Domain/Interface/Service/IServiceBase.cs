using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Interface.UnitOfWork;

namespace TemplateDDD.Domain.Interface.Service
{
    public interface IServiceBase<TModel> : IDisposable where TModel : class 
    {
        //IUnitOfWork Uow { get; set; }
        void Adicionar(ref TModel entidade);

        void AdicionarMuitos(ref IEnumerable<TModel> itens);

        void Atualizar(TModel entidade);

        void AtualizarMuitos(IEnumerable<TModel> itens);

        void Remover(params object[] id);

        void RemoverMuitos(IEnumerable<object[]> id);

        TModel SelecionarPorId(params object[] id);

        IEnumerable<TModel> SelecionarTodos();
    }
}
