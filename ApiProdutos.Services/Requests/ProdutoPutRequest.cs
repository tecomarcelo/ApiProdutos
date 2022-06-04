using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Services.Requests
{
    /// <summary>
    /// Modelo de dados para o serviço de edição de produto
    /// </summary>
    public class ProdutoPutRequest
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public Guid IdProduto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }
    }
}





