using ApiProdutos.Infra.Data.Entities;
using ApiProdutos.Services.Requests;
using AutoMapper;

namespace ApiProdutos.Services.Mappings
{
    /// <summary>
    /// Mapeamento Request -> Entity
    /// </summary>
    public class RequestToEntityMap : Profile
    {
        public RequestToEntityMap()
        {
            CreateMap<ProdutoPostRequest, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.IdProduto = Guid.NewGuid();
                    dest.DataCriacao = DateTime.Now;
                    dest.DataUltimaAlteracao = DateTime.Now;
                });

            CreateMap<ProdutoPutRequest, Produto>()
                .AfterMap((src, dest) =>
                {
                    dest.DataUltimaAlteracao = DateTime.Now;
                });
        }
    }
}
