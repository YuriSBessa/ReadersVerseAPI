using ReadersVerseAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Entidades
{
    public class Carteira
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string? Tipo_Transacao { get; set; }
        public decimal Valor { get; set; }
        public DateTime? Data_Transacao { get; set; }
        public decimal Saldo_Atual { get; set; }
        public virtual AppUser User { get; set; }

        public Carteira(string userId)
        {
            this.UserId = userId;
            this.Tipo_Transacao = null;
            this.Valor = 0;
            this.Data_Transacao = null;
            this.Saldo_Atual = 50000;
        }

        public Carteira()
        {
            
        }
    }
}
