namespace ApiProdutos.Services.Responses
{
    public class LoginGetResponse
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string AccessToken { get; set; }
        public DateTime DataExpiracao { get; set; }
    }
}



