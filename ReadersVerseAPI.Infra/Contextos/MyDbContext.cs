using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReadersVerseAPI.Domain.Entidades;
using ReadersVerseAPI.Domain.Models;
using ReadersVerseAPI.Infra.Mapeamentos;

namespace ReadersVerseAPI.Infra.Contextos
{
    public class MyDbContext : IdentityDbContext<AppUser>
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
            
        }

        public virtual DbSet<Livro> Livro { get; set; }

        public virtual DbSet<Carteira> Carteira { get; set; }

        public virtual DbSet<Emprestimo> Emprestimo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new LivroMapeamento());
            modelBuilder.ApplyConfiguration(new CarteiraMapeamento());
            modelBuilder.ApplyConfiguration(new EmprestimoMapeamento());
        }
    }
}
