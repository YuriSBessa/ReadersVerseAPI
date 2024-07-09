using ReadersVerseAPI.Domain.Dtos;
using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Interfaces;
using ReadersVerseAPI.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Infra.Repositorios
{
    public class EmprestimoRepositorio : Repositorio<Emprestimo>, IEmprestimoRepositorio
    {
        public EmprestimoRepositorio(MyDbContext context) : base(context)
        {
        }

        public IEnumerable<EmprestimoDTO> BuscarHistóricoDeEmprestimo(string userId)
        {
            return _dbSet.Where(v => v.UserId == userId)
                .Select(v => new EmprestimoDTO
                {
                    Id = v.Id,
                    UserId = v.UserId,
                    Titulo = v.Livro.Titulo,
                    Autor = v.Livro.Autor,
                    Genero = v.Livro.Genero,
                    DataEmprestimo = v.DataEmprestimo,
                    DataDevolucaoPrevista = v.DataDevolucaoPrevista,
                    DataDevolucaoEfetiva = v.DataDevolucaoEfetiva.ToString() ?? "-",
                    Status = v.Status
                });
        }
    }
}
