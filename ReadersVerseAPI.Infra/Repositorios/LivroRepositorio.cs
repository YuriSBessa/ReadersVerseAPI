using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Enums;
using ReadersVerseAPI.Domain.Interfaces;
using ReadersVerseAPI.Infra.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Infra.Repositorios
{
    public class LivroRepositorio : Repositorio<Livro>, ILivroRepositorio
    {
        public LivroRepositorio(MyDbContext context) : base(context)
        {
        }

        public IEnumerable<Livro> GetLivroPorFiltro(string buscar, EFiltro filtro)
        {
            var query = _dbSet.AsQueryable();

            switch (filtro)
            {
                case EFiltro.Titulo:
                    query = query.Where(v => v.Titulo.Contains(buscar));
                    break;
                case EFiltro.Autor:
                    query = query.Where(v => v.Autor.Contains(buscar));
                    break;
                case EFiltro.Genero:
                    query = query.Where(v => v.Genero.Contains(buscar));
                    break;
                case EFiltro.Editora:
                    query = query.Where(v => v.Editora.Contains(buscar));
                    break;
                default:
                    query = query.Where(v => v.Titulo.Contains(buscar) || v.Autor.Contains(buscar) || v.Genero.Contains(buscar) || v.Editora.Contains(buscar));
                    break;
            }

            return query.ToList();
        }
    }
}
