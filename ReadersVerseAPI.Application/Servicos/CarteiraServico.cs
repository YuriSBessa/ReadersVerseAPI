using Microsoft.AspNetCore.Http;
using ReadersVerseAPI.Domain.Dtos;
using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Application.Servicos
{
    public class CarteiraServico : ICarteiraServico
    {
        private readonly ICarteiraRepositorio _carteiraRepositorio;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CarteiraServico(ICarteiraRepositorio carteiraRepositorio,
                               IHttpContextAccessor  httpContextAccessor     
            )
        {
            this._carteiraRepositorio = carteiraRepositorio;
            this._httpContextAccessor = httpContextAccessor;
        }

        public Carteira BuscarCarteiraCompletor()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _carteiraRepositorio.BuscarCarteiraCompleta(userId);
        }

        public void CriarCarteira(string userId)
        {
            _carteiraRepositorio.Criar(new Carteira(userId));
        }

        public void DiminuirSaldoCarteira(decimal valorSaldoAtual)
        {
            Carteira carteira = BuscarCarteiraCompletor();

            carteira.Saldo_Atual = valorSaldoAtual;

            _carteiraRepositorio.Editar(carteira);
        }

        public CarteiraDTO GetCarteiras()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            return _carteiraRepositorio.GetCarteira(userId).First();
        }
    }
}
