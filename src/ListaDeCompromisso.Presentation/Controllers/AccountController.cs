using ListaDeCompromisso.CrossCutting.Cryptography;
using ListaDeCompromisso.Domain.Entities;
using ListaDeCompromisso.Infra.Interfaces;
using ListaDeCompromisso.Presentation.Models;
using Microsoft.AspNetCore.Mvc;

namespace ListaDeCompromisso.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AccountModel model, [FromServices] IUsuarioRepository usuarioRepository)
        {
            try
            {
                #region Verificando se o email informado já está cadastrado

                if (usuarioRepository.Get(model.Email) != null)
                {
                    return StatusCode(403, new { Message = "O email informado já encontra-se cadastrado. Tente outro." });
                }

                #endregion

                var usuario = new Usuario
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = model.Nome,
                    Email = model.Email,
                    Senha = MD5Cryptography.Encrypt(model.Senha),
                    DataCriacao = DateTime.Now
                };

                usuarioRepository.Create(usuario);
                return Ok(new
                {
                    Message = "Usuário cadastrado com sucesso."
                });
            }
            catch (Exception e)
            {
                //retornando um status code de erro da API..
                return StatusCode(500, e.Message);
            }
        }
    }
}