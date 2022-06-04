namespace ApiProdutos.Services.Responses
{
    /// <summary>
    /// Modelo de dados para a consulta de produtos
    /// </summary>
    public class ProdutoGetResponse
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public decimal Total { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}



