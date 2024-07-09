using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadersVerseAPI.Domain.Exceptions;
using ReadersVerseAPI.Domain.Interfaces;

namespace ReadersVerseAPI.Controllers
{
    [ApiController]
    [Route("Emprestimo")]
    public class EmprestimoController : Controller
    {
        private readonly IEmprestimoServico _emprestimoServico;

        public EmprestimoController(IEmprestimoServico emprestimoServico)
        {
            this._emprestimoServico = emprestimoServico;
        }

        [Authorize]
        [HttpPost("CriarEmprestimo/{livroId}")]
        public IActionResult CriarEmprestimo([FromRoute] int livroId)
        {
            try
            {
                _emprestimoServico.CriarEmprestimo(livroId);
                return NoContent();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("BuscarHistoricoEmprestimo")]
        public IActionResult BuscarHistoricoEmprestimo()
        {
            return Ok(_emprestimoServico.BuscarHistóricoDeEmprestimo());
        }

        [Authorize]
        [HttpPatch("DevolverLivro/{id}")]
        public IActionResult DevolverLivro(int id)
        {
            try
            {
                _emprestimoServico.DevolverLivro(id);
                return NoContent();
            }
            catch (BadRequestException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPatch("VerificarEmprestimo")]
        public IActionResult VerificarEmprestimo()
        {
            _emprestimoServico.VerificarDataEmprestimo();
            return NoContent();
        }
    }
}
