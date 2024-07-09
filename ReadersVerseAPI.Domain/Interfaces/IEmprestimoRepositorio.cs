using ReadersVerseAPI.Domain.Dtos;
using ReadersVerseAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Interfaces
{
    public interface IEmprestimoRepositorio : IRepositorio<Emprestimo>
    {
        public IEnumerable<EmprestimoDTO> BuscarHistóricoDeEmprestimo(string userId);
    }
}
