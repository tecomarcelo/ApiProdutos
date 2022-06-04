namespace ApiProdutos.Services.Configurations
{
    /// <summary>
    /// Classe para configuração do AutoMapper
    /// </summary>
    public static class AutoMapperConfiguration
    {
        /// <summary>
        /// Método para configuração do uso do automapper
        /// </summary>
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}



