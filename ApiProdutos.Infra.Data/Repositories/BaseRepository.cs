using ApiProdutos.Infra.Data.Contexts;
using ApiProdutos.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Repositories
{
    /// <summary>
    /// Classe genérica para implementar o repositorio
    /// </summary>
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para inicialização do atributo
        protected BaseRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public virtual void Add(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Added;
            _sqlServerContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public virtual void Delete(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Deleted;
            _sqlServerContext.SaveChanges();
        }

        public virtual List<TEntity> GetAll()
        {
            return _sqlServerContext.Set<TEntity>().ToList();
        }

        public virtual TEntity Get(Guid id)
        {
            return _sqlServerContext.Set<TEntity>().Find(id);
        }
    }
}



