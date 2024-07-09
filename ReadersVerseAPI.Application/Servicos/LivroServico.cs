using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Enums;
using ReadersVerseAPI.Domain.Exceptions;
using ReadersVerseAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Application.Servicos
{
    public class LivroServico : ILivroServico
    {
        private readonly ILivroRepositorio _livroRepositorio;

        public LivroServico(ILivroRepositorio livroRepositorio)
        {
            this._livroRepositorio = livroRepositorio;
        }

        public IEnumerable<Livro> BuscarLivroPorFiltro(string buscar, EFiltro filtro)
        {
            return _livroRepositorio.GetLivroPorFiltro(buscar, filtro);
        }

        public Livro BuscarLivroPorId(int id)
        {
            Livro livro = _livroRepositorio.BuscarPorId(id);

            if (livro is null)
            {
                throw new BadRequestException("Livro não encontrado");
            }

            return livro;
        }

        public void DiminuirQuantidadeLivros(Livro livro)
        {
            livro.DiminuirQuantidade();
            _livroRepositorio.Editar(livro);
        }
    }
}
