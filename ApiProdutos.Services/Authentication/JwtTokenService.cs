using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiProdutos.Services.Authentication
{
    /// <summary>
    /// Classe para geração dos TOKENS JWT
    /// </summary>
    public static class JwtTokenService
    {
        /// <summary>
        /// Chave secreta para geração dos tokens
        /// </summary>
        public static string SecretKey => "ad2024d9-ba2f-4b52-b098-af39e22989e2";

        /// <summary>
        /// Tempo para expiração do TOKEN em horas
        /// </summary>
        public static int ExpirationInHours => 6;

        /// <summary>
        /// Método para gerar e retornar o TOKEN do usuário
        /// </summary>
        /// <returns></returns>
        public static string GenerateToken(string login)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(SecretKey);

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, login) }),
                Expires = DateTime.UtcNow.AddHours(ExpirationInHours),
                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(descriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}



