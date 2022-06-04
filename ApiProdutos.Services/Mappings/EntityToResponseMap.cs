using ApiProdutos.Infra.Data.Entities;
using ApiProdutos.Services.Responses;
using AutoMapper;

namespace ApiProdutos.Services.Mappings
{
    /// <summary>
    /// Mapeamento Entity -> Response
    /// </summary>
    public class EntityToResponseMap : Profile
    {
        public EntityToResponseMap()
        {
            CreateMap<Produto, ProdutoGetResponse>()
                .AfterMap((src, dest) =>
                {
                    dest.Total = (src.Preco * src.Quantidade);
                });
        }
    }
}
