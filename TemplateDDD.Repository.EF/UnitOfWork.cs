using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateDDD.Domain.Interface.UnitOfWork;
using TemplateDDD.Repository.EF.Context;

namespace TemplateDDD.Repository.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        public  DbContext _contexto;
        private DbContextTransaction _transaction;
        public UnitOfWork(DbContext contexto)
        {
            this._contexto = contexto;
        }
        

        void IUnitOfWork.BeginTransaction()
        {
            _transaction = _contexto.Database.BeginTransaction();
        }

        void IUnitOfWork.Commit()
        {
            if (_transaction != null)
            {
                _contexto.SaveChanges();
                _transaction.Commit();
            }
        }

        void IUnitOfWork.Rollback()
        {
            if (_transaction != null)
            {
                _transaction.Rollback();
            }
        }

        void IUnitOfWork.Salvar()
        {
            _contexto.SaveChanges();
        }
    }
}
