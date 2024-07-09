using ReadersVerseAPI.Domain.Dtos;
using ReadersVerseAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Interfaces
{
    public interface ICarteiraServico
    {
        public void CriarCarteira(string userId);
        public CarteiraDTO GetCarteiras();
        public Carteira BuscarCarteiraCompletor();
        public void DiminuirSaldoCarteira(decimal valorSaldoAtual);
    }
}
