using ApiProdutos.Infra.Data.Interfaces;
using ApiProdutos.Infra.Data.Utils;
using ApiProdutos.Services.Authentication;
using ApiProdutos.Services.Requests;
using ApiProdutos.Services.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        //atributo
        private readonly IUsuarioRepository _usuarioRepository;

        //construtor para injeção de dependência
        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(LoginPostRequest request)
        {
            try
            {
                var usuario = _usuarioRepository.Get(request.Login, MD5Util.Get(request.Senha));

                if (usuario == null)
                    return StatusCode(401, new { message = "Acesso negado." });

                var response = new LoginGetResponse
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    AccessToken = JwtTokenService.GenerateToken(usuario.Login),
                    DataExpiracao = DateTime.UtcNow.AddHours(JwtTokenService.ExpirationInHours)
                };

                return StatusCode(200, response);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = e.Message });
            }
        }
    }
}



