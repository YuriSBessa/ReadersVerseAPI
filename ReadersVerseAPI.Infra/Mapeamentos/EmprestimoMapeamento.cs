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
    public class EmprestimoMapeamento : IEntityTypeConfiguration<Emprestimo>
    {
        public void Configure(EntityTypeBuilder<Emprestimo> builder)
        {
            builder.ToTable("Emprestimo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataEmprestimo)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DataEmprestimo");

            builder.Property(x => x.DataDevolucaoPrevista)
                .IsRequired()
                .HasColumnType("datetime")
                .HasColumnName("DataDevolucaoPrevista");

            builder.Property(x => x.DataDevolucaoEfetiva)
                .HasColumnType("datetime")
                .HasColumnName("DataDevolucaoEfetiva");

            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("tinyint")
                .HasColumnName("Status");

            builder.HasOne(x => x.Livro)
                .WithMany()
                .HasForeignKey(x => x.LivroId);

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
