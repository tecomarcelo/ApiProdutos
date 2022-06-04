using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Services.Requests
{
    /// <summary>
    /// Modelo de dados para o serviço de cadastro de produto
    /// </summary>
    public class ProdutoPostRequest
    {
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public int Quantidade { get; set; }
    }
}



