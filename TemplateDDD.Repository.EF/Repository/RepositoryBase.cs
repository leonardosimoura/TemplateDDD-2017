using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Interface.Repository;
using TemplateDDD.Domain.Interface.UnitOfWork;

namespace TemplateDDD.Repository.EF.Repository
{
    public class RepositoryBase<TModel> : IRepositoryBase<TModel> where TModel : class
    {
        private readonly DbContext _dbContext;

        public RepositoryBase(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        void IRepositoryBase<TModel>.Adicionar(ref TModel entidade)
        {
            _dbContext.Set<TModel>().Add(entidade);
            _dbContext.SaveChanges();
        }

        void IRepositoryBase<TModel>.AdicionarMuitos(ref IEnumerable<TModel> itens)
        {
            _dbContext.Set<TModel>().AddRange(itens);
            _dbContext.SaveChanges();
        }

        void IRepositoryBase<TModel>.Atualizar(TModel entidade)
        {
            _dbContext.Entry(entidade).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }

        void IRepositoryBase<TModel>.AtualizarMuitos(IEnumerable<TModel> itens)
        {
            foreach (var entidade in itens)
            {
                _dbContext.Entry(entidade).State = EntityState.Modified;

            }
            _dbContext.SaveChanges();
        }

        void IRepositoryBase<TModel>.Remover(params object[] id)
        {
            var entidade = _dbContext.Set<TModel>().Find(id);
            if (entidade != null)
                _dbContext.Entry(entidade).State = EntityState.Deleted;

            _dbContext.SaveChanges();
        }

        void IRepositoryBase<TModel>.RemoverMuitos(IEnumerable<object[]> id)
        {
            foreach (var item in id)
            {
                var entidade = _dbContext.Set<TModel>().Find(item);

                if (entidade != null)
                    _dbContext.Entry(entidade).State = EntityState.Deleted;
            }
            _dbContext.SaveChanges();
        }


        TModel IRepositoryBase<TModel>.SelecionarPorId(params object[] id)
        {
            return _dbContext.Set<TModel>().Find(id);
        }

        IEnumerable<TModel> IRepositoryBase<TModel>.SelecionarTodos()
        {
            return _dbContext.Set<TModel>();
        }
    }
}
