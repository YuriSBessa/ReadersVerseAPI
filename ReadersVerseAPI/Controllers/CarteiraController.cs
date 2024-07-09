using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReadersVerseAPI.Domain.Dtos;
using ReadersVerseAPI.Domain.Interfaces;

namespace ReadersVerseAPI.Controllers
{
    [ApiController]
    [Route("Carteira")]
    public class CarteiraController : Controller
    {
        private readonly ICarteiraServico _carteiraServico;

        public CarteiraController(ICarteiraServico carteiraServico)
        {
            this._carteiraServico = carteiraServico;
        }

        [Authorize]
        [HttpPost("CriarCarteira")]
        public IActionResult CriarCarteira([FromBody] CriarCarteiraDTO dto)
        {
            _carteiraServico.CriarCarteira(dto.UserId);
            return NoContent();
        }

        [Authorize]
        [HttpGet("BuscarCarteira")]
        public IActionResult BuscarCarteira()
        {
            return Ok(_carteiraServico.GetCarteiras());
        }
    }
}
