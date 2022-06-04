using ApiProdutos.Infra.Data.Contexts;
using ApiProdutos.Infra.Data.Interfaces;
using ApiProdutos.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiProdutos.Services.Configurations
{
    /// <summary>
    /// Classe de configuração do EntityFramework no AspNet
    /// </summary>
    public static class EntityFrameworkConfiguration
    {
        public static void AddEntityFramework(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration
                .GetConnectionString("ApiProdutos");

            builder.Services.AddDbContext<SqlServerContext>
                (options => options.UseSqlServer(connectionString));

            builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }
    }
}