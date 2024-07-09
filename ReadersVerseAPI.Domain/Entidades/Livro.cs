using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Domain.Entidades
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Genero { get; set; }
        public DateOnly DataPublicacao { get; set; }
        public string Editora { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public string Imagem_Url { get; set; }
        public string Descricao { get; set; }
        public bool Disponibilidade { get; set; }

        public void DiminuirQuantidade()
        {
            this.Quantidade--;
        }

        public void AumentarQuantidade()
        {
            this.Quantidade++;
        }
    }
}
