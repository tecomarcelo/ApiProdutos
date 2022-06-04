using ApiProdutos.Infra.Data.Contexts;
using ApiProdutos.Infra.Data.Entities;
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
    /// Classe de repositório para Produto
    /// </summary>
    public class ProdutoRepository : IProdutoRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para inicializar o atributo
        public ProdutoRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }


        public void Add(Produto entity)
        {
            _sqlServerContext.Produto.Add(entity);
            _sqlServerContext.SaveChanges();
        }

        public void Update(Produto entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Delete(Produto entity)
        {
            _sqlServerContext.Produto.Remove(entity);
            _sqlServerContext.SaveChanges();
        }

        public List<Produto> GetAll()
        {
            return _sqlServerContext.Produto
                .OrderBy(p => p.Nome)
                .ToList();
        }

        public Produto Get(Guid id)
        {
            return _sqlServerContext.Produto
                .Find(id);
        }
    }
}



