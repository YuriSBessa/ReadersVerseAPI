using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReadersVerseAPI.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadersVerseAPI.Infra.Mapeamentos
{
    public class LivroMapeamento : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("Livro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("Titulo");

            builder.Property(x => x.Autor)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("Autor");

            builder.Property(x => x.Genero)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("Genero");

            builder.Property(x => x.DataPublicacao)
                .IsRequired()
                .HasColumnType("date")
                .HasColumnName("Data_Publicacao");

            builder.Property(x => x.Editora)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("Editora");

            builder.Property(x => x.Preco)
                .IsRequired()
                .HasColumnType("smallmoney")
                .HasColumnName("Preco");

            builder.Property(x => x.Quantidade)
                .IsRequired()
                .HasColumnType("int")
                .HasColumnName("Quantidade");

            builder.Property(x => x.Imagem_Url)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar")
                .HasColumnName("Imagem_Url");

            builder.Property(x => x.Descricao)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnType("varchar")
                .HasColumnName("Descricao");

            builder.Property(x => x.Disponibilidade)
                .HasColumnType("bit")
                .HasColumnName("Disponibilidade");
        }
    }
}
