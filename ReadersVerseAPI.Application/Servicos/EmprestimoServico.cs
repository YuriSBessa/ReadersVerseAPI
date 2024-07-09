using Microsoft.AspNetCore.Http;
using ReadersVerseAPI.Domain.Interfaces;
using System.Security.Claims;
using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Exceptions;
using ReadersVerseAPI.Domain.Dtos;

namespace ReadersVerseAPI.Application.Servicos
{
    public class EmprestimoServico : IEmprestimoServico
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILivroServico _livroServico;
        private readonly ICarteiraServico _carteiraServico;

        public EmprestimoServico(IEmprestimoRepositorio emprestimoRepositorio,
                                 IHttpContextAccessor httpContextAccessor,
                                 ILivroServico livroServico,
                                 ICarteiraServico carteiraServico
            )
        {
            this._emprestimoRepositorio = emprestimoRepositorio;
            this._httpContextAccessor = httpContextAccessor;
            this._livroServico = livroServico;
            this._carteiraServico = carteiraServico;
        }

        public void CriarEmprestimo(int livroId)
        {
            var userId = RetornarUserId();
            VerificarUserId(userId);

            var livro = BuscarLivroPorId(livroId);
            VerificarLivro(livro);

            var carteira = BuscarCarteiraCompleta();
            VerificarCarteira(carteira);

            decimal valorSaldoAtual = carteira.Saldo_Atual - livro.Preco;

            DiminuiSaldoCarteira(valorSaldoAtual);
            DiminuirQuantidadeLivro(livro);

            _emprestimoRepositorio.Criar(new Emprestimo(livroId, userId));
        }

        public void DevolverLivro(int id)
        {
            Emprestimo emprestimo = _emprestimoRepositorio.BuscarPorId(id);
            VerificarEmprestimo(emprestimo);

            Livro livro = BuscarLivroPorId(emprestimo.LivroId);
            VerificarLivro(livro);

            emprestimo.DevolverLivro();
            livro.AumentarQuantidade();

            _emprestimoRepositorio.Editar(emprestimo);
        }

        public void VerificarDataEmprestimo()
        {
            IEnumerable<Emprestimo> emprestimos = _emprestimoRepositorio.Buscar();

            foreach (var emprestimo in emprestimos)
            {
                if (emprestimo.DataEmprestimo.Day > emprestimo.DataDevolucaoPrevista.Day)
                {
                    emprestimo.Atrasado();
                    _emprestimoRepositorio.Editar(emprestimo);
                }
            }
        }

        public IEnumerable<EmprestimoDTO> BuscarHistóricoDeEmprestimo()
        {
            var userId = RetornarUserId();

            return _emprestimoRepositorio.BuscarHistóricoDeEmprestimo(userId);
        }

        private string RetornarUserId()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
        }

        private Livro BuscarLivroPorId(int livroId)
        {
            return _livroServico.BuscarLivroPorId(livroId);
        }

        private Carteira BuscarCarteiraCompleta()
        {
            return _carteiraServico.BuscarCarteiraCompletor();
        }

        private void DiminuirQuantidadeLivro(Livro livro)
        {
            _livroServico.DiminuirQuantidadeLivros(livro);
        }

        private void DiminuiSaldoCarteira(decimal valorSaldo)
        {
            _carteiraServico.DiminuirSaldoCarteira(valorSaldo);
        }

        private void VerificarUserId(string userId)
        {
            if (String.IsNullOrEmpty(userId))
            {
                throw new BadRequestException("Id do usuario vazio ou não encontrado");
            }
        }

        private void VerificarLivro(Livro livro)
        {
            if (livro == null)
            {
                throw new BadRequestException("Livro não encontrado");
            }
        }

        private void VerificarCarteira(Carteira carteira)
        {
            if (carteira == null)
            {
                throw new BadRequestException("Carteira não encontrada");
            }
        }

        private void VerificarEmprestimo(Emprestimo emprestimo)
        {
            if (emprestimo is null)
            {
                throw new BadRequestException("Emprestimo não encontrado");
            }
        }
    }
}
