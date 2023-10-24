using ListaDeCompromisso.CrossCutting.Cryptography;
using ListaDeCompromisso.Infra.Interfaces;
using ListaDeCompromisso.Presentation.Models;
using ListaDeCompromisso.Presentation.Settings;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompromisso.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(LoginModel model,
            [FromServices] IUsuarioRepository usuarioRepository,
            [FromServices] TokenSettings tokenSettings)
        {
            try
            {
                //verificar se o email e senha pertencem a algum usuario..
                var usuario = usuarioRepository.Get(model.Email, MD5Cryptography.Encrypt(model.Senha));

                if (usuario == null) //se usuário não foi encontrado
                    return StatusCode(401, new { Message = "Acesso negado. Usuário inválido." });

                //gerando e retornando o TOKEN de autenticação..
                return Ok(new
                {
                    Message = "Usuário autenticado com sucesso.",
                    AccessToken = tokenSettings.GenerateToken(usuario.Email)
                }); ;
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}