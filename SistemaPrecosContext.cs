using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SistemaPrecos.Core.Entities;

namespace SistemaPrecos.Core.Data
{
    // Contexto que herda de IdentityDbContext<ApplicationUser> para suportar Identity
    public class SistemaPrecosContext : IdentityDbContext<ApplicationUser>
    {
        public SistemaPrecosContext(DbContextOptions<SistemaPrecosContext> options) 
            : base(options)
        {
        }

        // Demais entidades do seu domínio:
        // Exemplo: Aqui, 'Utilizador' é uma entidade diferente de 'ApplicationUser'
        
        // public DbSet<Produto> Produtos { get; set; }
        // public DbSet<Loja> Lojas { get; set; }
        // public DbSet<Preco> Precos { get; set; }
        // etc.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Importante chamar primeiro para configurar as tabelas do Identity
            base.OnModelCreating(modelBuilder);

            // Se quiser renomear as tabelas padrão do Identity:
            // modelBuilder.Entity<ApplicationUser>().ToTable("AspNetUsers");
            // modelBuilder.Entity<IdentityRole>().ToTable("AspNetRoles");
            // etc.

            // Configurar a sua entidade 'Utilizador' no domínio
            /*modelBuilder.Entity<Utilizador>(entity =>
            {
                // Caso queira criar uma tabela separada chamada 'Utilizadores'
                entity.ToTable("Utilizadores");

                // Definição da PK
                entity.HasKey(u => u.IdUtilizador);

                // Restrições e colunas
                entity.Property(u => u.Nome)
                      .HasMaxLength(50)
                      .IsRequired();

                entity.Property(u => u.Email)
                      .HasMaxLength(100)
                      .IsRequired();

                entity.HasIndex(u => u.Email)
                      .IsUnique();

                // etc.
            });
            */

            // Aqui, configure também Produto, Loja, etc., conforme sua modelagem.
        }
    }
}


