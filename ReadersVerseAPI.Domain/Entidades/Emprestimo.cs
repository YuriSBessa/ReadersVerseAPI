using ReadersVerseAPI.Domain.Enums;
using ReadersVerseAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Entidades
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public int LivroId { get; set; }
        public string UserId { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public DateTime? DataDevolucaoEfetiva { get; set; }
        public EStatus Status { get; set; }
        public virtual Livro Livro { get; set; }
        public virtual AppUser User { get; set; }

        public Emprestimo(int livroId, string userId)
        {
            this.LivroId = livroId;
            this.UserId = userId;
            this.DataEmprestimo = DateTime.Now;
            this.DataDevolucaoPrevista = DateTime.Now.AddMonths(1);
            this.DataDevolucaoEfetiva = null;
            this.Status = EStatus.Emprestado;
        }

        public void DevolverLivro()
        {
            this.DataDevolucaoEfetiva = DateTime.Now;
            this.Status = EStatus.Devolvido;
        }

        public void Atrasado()
        {
            this.Status = EStatus.Atrasado;
        }

        public Emprestimo()
        {
            
        }
    }
}
