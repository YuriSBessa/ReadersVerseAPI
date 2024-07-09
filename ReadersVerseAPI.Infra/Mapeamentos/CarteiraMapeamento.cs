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
    public class CarteiraMapeamento : IEntityTypeConfiguration<Carteira>
    {
        public void Configure(EntityTypeBuilder<Carteira> builder)
        {
            builder.ToTable("Carteira");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Tipo_Transacao)
                .HasMaxLength(50)
                .HasColumnType("varchar")
                .HasColumnName("Tipo_Transacao");

            builder.Property(x => x.Valor)
                .HasColumnType("smallmoney")
                .HasColumnName("Valor");

            builder.Property(x => x.Data_Transacao)
                .HasColumnType("datetime")
                .HasColumnName("Data_Transacao");

            builder.Property(x => x.Saldo_Atual)
                .HasColumnType("smallmoney")
                .HasColumnName("Saldo_Atual");

            builder.HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
        }
    }
}
