using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadersVerseAPI.Domain.Enums;
using ReadersVerseAPI.Domain.Interfaces;

namespace ReadersVerseAPI.Controllers
{
    [ApiController]
    [Route("/Livro")]
    public class LivroController : Controller
    {
        private readonly ILivroServico _livroServico;

        public LivroController(ILivroServico livroServico)
        {
            this._livroServico = livroServico;
        }

        [Authorize]
        [HttpGet("buscarLivroPorFiltro")]
        public IActionResult BuscarLivroPorFiltro(
            [FromQuery] string? buscar,
            [FromQuery] EFiltro filtro
        )
        {
            return Ok(_livroServico.BuscarLivroPorFiltro(buscar, filtro));
        }

        [Authorize]
        [HttpGet("buscarLivroPorId/{id}")]
        public IActionResult BuscarLivroPorId([FromRoute] int id)
        {
            try
            {
                return Ok(_livroServico.BuscarLivroPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
