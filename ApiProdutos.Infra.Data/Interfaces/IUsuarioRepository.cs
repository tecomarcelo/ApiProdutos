using ApiProdutos.Infra.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Interfaces
{
    /// <summary>
    /// Interface de repositório para usuário
    /// </summary>
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Get(string login, string senha);
    }
}



