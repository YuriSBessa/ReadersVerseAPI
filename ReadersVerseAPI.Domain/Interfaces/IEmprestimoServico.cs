using ReadersVerseAPI.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Interfaces
{
    public interface IEmprestimoServico
    {
        public void CriarEmprestimo(int livroId);
        public IEnumerable<EmprestimoDTO> BuscarHistóricoDeEmprestimo();
        public void DevolverLivro(int livroId);
        public void VerificarDataEmprestimo();
    }
}
