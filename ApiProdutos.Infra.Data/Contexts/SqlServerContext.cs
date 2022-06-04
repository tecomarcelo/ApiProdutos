using ApiProdutos.Infra.Data.Entities;
using ApiProdutos.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Contexts
{
    /// <summary>
    /// Classe para acesso ao banco de dados com o EntityFramework
    /// </summary>
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionando as classes de mapeamento
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        public DbSet<Produto> Produto { get; set; }
    }
}



