using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Interface.Repository;
using TemplateDDD.Domain.Interface.Service;
using TemplateDDD.Domain.Interface.UnitOfWork;

namespace TemplateDDD.Domain.Service
{
    public class ServiceBase<TModel> : IServiceBase<TModel> where TModel : class
    {
        private readonly IRepositoryBase<TModel> _repository;
        public ServiceBase(IRepositoryBase<TModel> repository )
        {
            _repository = repository;
        }

        //IUnitOfWork IServiceBase<TModel>.Uow { get; set; }

        void IServiceBase<TModel>.Adicionar(ref TModel entidade)
        {
            _repository.Adicionar(ref entidade);
        }

        void IServiceBase<TModel>.AdicionarMuitos(ref IEnumerable<TModel> itens)
        {
            _repository.AdicionarMuitos(ref itens);
        }

        void IServiceBase<TModel>.Atualizar(TModel entidade)
        {
            _repository.Atualizar(entidade);
        }

        void IServiceBase<TModel>.AtualizarMuitos(IEnumerable<TModel> itens)
        {
            _repository.AtualizarMuitos(itens);
        }

        void IServiceBase<TModel>.Remover(params object[] id)
        {
            _repository.Remover(id);
        }

        void IServiceBase<TModel>.RemoverMuitos(IEnumerable<object[]> id)
        {
            _repository.RemoverMuitos(id);
        }


        TModel IServiceBase<TModel>.SelecionarPorId(params object[] id)
        {
            return _repository.SelecionarPorId(id);
        }

        IEnumerable<TModel> IServiceBase<TModel>.SelecionarTodos()
        {
            return _repository.SelecionarTodos();
        }
    }
}
