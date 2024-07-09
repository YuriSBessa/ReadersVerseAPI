using ReadersVerseAPI.Domain.Dtos;
using ReadersVerseAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Interfaces
{
    public interface ICarteiraRepositorio : IRepositorio<Carteira>
    {
        public IEnumerable<CarteiraDTO> GetCarteira(string userId);
        public Carteira BuscarCarteiraCompleta(string userId);
    }
}
