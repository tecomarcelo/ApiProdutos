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
    /// Classe de repositório para Usuário
    /// </summary>
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        //atributo
        private readonly SqlServerContext _sqlServerContext;

        //construtor para inicializar o atributo
        public UsuarioRepository(SqlServerContext sqlServerContext)
            : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Usuario Get(string login, string senha)
        {
            return _sqlServerContext.Usuario
                .FirstOrDefault(u => u.Login.Equals(login)
                                  && u.Senha.Equals(senha));
        }
    }
}


