using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Interfaces
{
    public interface ILivroRepositorio : IRepositorio<Livro>
    {
        public IEnumerable<Livro> GetLivroPorFiltro(string buscar, EFiltro filtro);
    }
}
