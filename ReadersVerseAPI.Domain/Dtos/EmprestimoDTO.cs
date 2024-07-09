using ReadersVerseAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Dtos
{
    public class EmprestimoDTO
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucaoPrevista { get; set; }
        public string DataDevolucaoEfetiva { get; set; }
        public EStatus Status { get; set; }
    }
}
