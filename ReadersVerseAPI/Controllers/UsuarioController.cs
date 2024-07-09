using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadersVerseAPI.Domain.Exceptions;
using ReadersVerseAPI.Domain.Interfaces;
using ReadersVerseAPI.Domain.Models;
using ReadersVerseAPI.Domain.Models.Request;
using ReadersVerseAPI.Domain.Models.Response;

namespace ReadersVerseAPI.Controllers
{
    [ApiController]
    public class UsuarioController : Controller
    {
        private IIdentityService _identityService;

        public UsuarioController(IIdentityService identityService)
        {
            this._identityService = identityService;
        }

        [HttpPost("cadastro")]
        public async Task<ActionResult<UsuarioCadastroResponse>> Cadastrar(UsuarioCadastroRequest usuarioCadastro)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var resultado = await _identityService.CadastrarUsuario(usuarioCadastro);

            if (resultado.Sucesso)
            {
                return Ok(resultado);
            }
            else if (resultado.Erros.Count > 0)
            {
                return BadRequest(resultado);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLoginResponse>> Login(UsuarioLoginRequest usuarioLogin)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest();
                }

                var resultado = await _identityService.Login(usuarioLogin);

                if (resultado.Sucesso)
                {
                    return Ok(resultado);
                }

                return Unauthorized();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<ActionResult> Logout()
        {
            return Ok(_identityService.Logout());
        }
    }
}
