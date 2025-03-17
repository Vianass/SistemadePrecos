using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaPrecos.Core.Entities;
using SistemaPrecos.Core.Models;

namespace SistemaPrecos.Core.Data
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        #region DbSets
        public virtual DbSet<AvaliacaoPreco> AvaliacaoPrecos { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Loja> Lojas { get; set; }
        public virtual DbSet<Mensagem> Mensagems { get; set; }
        public virtual DbSet<Preco> Precos { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Relatorio> Relatorios { get; set; }

        #endregion

        /// <summary>
        /// Idealmente, você deve remover a connection string daqui e usar a do Program.cs 
        /// ou appsettings.json (injeção de dependências).
        /// </summary>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // #warning mantido para lembrar de mover a connection string para local seguro
                // Caso queira manter por ora, tudo bem, mas é recomendável usar Configuration:
                // optionsBuilder.UseNpgsql("Name=ConnectionStrings:DefaultConnection");
                optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=varzim2004;Database=Plataformadecomparacaodeprecos");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region AvaliacaoPreco
modelBuilder.Entity<AvaliacaoPreco>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacao)
                      .HasName("avaliacao_preco_pkey");

                entity.ToTable("avaliacao_preco");

                entity.Property(e => e.IdAvaliacao)
                      .ValueGeneratedNever() // Se quiser auto-increment, mude para ValueGeneratedOnAdd()
                      .HasColumnName("id_avaliacao");

                entity.Property(a => a.ApplicationUserId)
                      .HasColumnName("application_user_id")
                      .HasColumnType("varchar(450)"); 
                      // Por padrão, Identity usa 450 para strings do Id no SQL Server;
                      // Em PostgreSQL, pode ser text ou varchar(450).

                entity.Property(e => e.Comentario)
                      .HasColumnName("comentario")
                      .HasColumnType("character varying");

                entity.Property(e => e.Confiabilidade)
                      .HasColumnName("confiabilidade")
                      .HasColumnType("character varying");

                // FK -> ApplicationUser
                entity.HasOne(e => e.UserNavigation)
                      .WithMany() // ou .WithMany(p => p.AvaliacaoPrecos) se criar a coleção
                      .HasForeignKey(e => e.ApplicationUserId)
                      .OnDelete(DeleteBehavior.ClientSetNull);

                // Se quiser mapear 'IdPrecoNavigation' também
                entity.Property(e => e.IdPreco).HasColumnName("id_preco");
                entity.HasOne(d => d.IdPrecoNavigation)
                      .WithMany(p => p.AvaliacaoPrecos)
                      .HasForeignKey(d => d.IdPreco)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("id_preco");
            });
            #endregion

            #region Categoria
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(e => e.IdCategoria).HasName("categoria_pkey");

                entity.ToTable("categoria");

                entity.Property(e => e.IdCategoria)
                    .ValueGeneratedNever()
                    .HasColumnName("id_categoria");

                entity.Property(e => e.Nome)
                    .HasColumnType("character varying")
                    .HasColumnName("nome");

                // Muitos-para-muitos entre 'Categoria' e 'Produto'
                entity.HasMany(c => c.Produtos)
                    .WithMany(p => p.Categorias)
                    .UsingEntity<Dictionary<string, object>>(
                        "CategoriaProduto",
              r => r.HasOne<Produto>().WithMany().HasForeignKey("IdProduto"),
              l => l.HasOne<Categoria>().WithMany().HasForeignKey("IdCategoria"),
              j =>
              {
                  j.HasKey("IdCategoria", "IdProduto");
                  j.ToTable("categoria_produto");
              }
          );
            });
            #endregion

            #region Loja
            modelBuilder.Entity<Loja>(entity =>
            {
                entity.HasKey(e => e.IdLoja).HasName("loja_pkey");

                entity.ToTable("loja");

                entity.Property(e => e.IdLoja)
                    .ValueGeneratedNever()
                    .HasColumnName("id_loja");

                entity.Property(e => e.Contacto).HasColumnName("contacto");
                entity.Property(e => e.DataCriacao).HasColumnName("data_criacao");

                entity.Property(e => e.Localizacao)
                    .HasColumnType("character varying")
                    .HasColumnName("localizacao");

                entity.Property(e => e.Nome)
                    .HasColumnType("character varying")
                    .HasColumnName("nome");
            });
            #endregion

            #region Mensagem
            modelBuilder.Entity<Mensagem>(entity =>
            {
                entity.HasKey(e => e.IdMensagem).HasName("mensagem_pkey");

                entity.ToTable("mensagem");

                entity.Property(e => e.IdMensagem)
                    .ValueGeneratedNever()
                    .HasColumnName("id_mensagem");

                entity.Property(e => e.Conteudo)
                    .HasColumnType("character varying")
                    .HasColumnName("conteudo");

                entity.Property(e => e.DataEnvio).HasColumnName("data_envio");
                entity.Property(e => e.ApplicationUserId)
                    .HasColumnName("application_user_id")
                    .HasColumnType("varchar(450)"); 

                entity.HasOne(d => d.UserNavigation)
                    .WithMany() // ou .WithMany(p => p.Mensagens) caso queira uma ICollection<Mensagem> lá
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_mensagem_user");
            });
            #endregion

            #region Preco
            modelBuilder.Entity<Preco>(entity =>
            {
                entity.HasKey(e => e.IdPreco).HasName("preco_pkey");

                entity.ToTable("preco");

                entity.Property(e => e.IdPreco)
                    .ValueGeneratedNever()
                    .HasColumnName("id_preco");

                entity.Property(e => e.Credibilidade)
                    .HasColumnType("character varying")
                    .HasColumnName("credibilidade");

                entity.Property(e => e.DataHora).HasColumnName("data_hora");
                entity.Property(e => e.IdLoja).HasColumnName("id_loja");
                entity.Property(e => e.IdProduto).HasColumnName("id_produto");
                entity.Property(e => e.ApplicationUserId)
                    .HasColumnName("application_user_id")
                    .HasColumnType("varchar(450)");
                entity.Property(e => e.Valor).HasColumnName("valor");

                entity.HasOne(d => d.IdLojaNavigation)
                    .WithMany(p => p.Precos)
                    .HasForeignKey(d => d.IdLoja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_loja");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Precos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_produto");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany() // ou .WithMany(p => p.Precos) se preferir
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("application_user_id");
            });
            #endregion

            #region Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.IdProduto).HasName("produto_pkey");

                entity.ToTable("produto");

                entity.Property(e => e.IdProduto)
                    .ValueGeneratedNever()
                    .HasColumnName("id_produto");

                // Correção do nome da coluna (remover espaço extra)
                /*entity.Property(e => e.IdCategoria)
                    .HasColumnType("character varying")
                    .HasColumnName("categoria");*/

                entity.Property(e => e.Descricao)
                    .HasColumnType("character varying")
                    .HasColumnName("descricao");

                /*entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("id_categoria");*/

                entity.Property(e => e.Nome)
                    .HasColumnType("character varying")
                    .HasColumnName("nome");

                /*entity.HasMany(d => d.Produtos)
                    .WithMany(p => p.Categorias)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_categoria");*/

                entity.Property(e => e.ApplicationUserId)
                    .HasColumnName("application_user_id")
                    .HasColumnType("varchar(450)");

                entity.HasOne(d => d.UserNavigation)
                    .WithMany() // ou .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.ApplicationUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_produto_user");
                /*entity.HasMany(d => d.IdRelatorios)
                    .WithMany(p => p.IdProdutos)
                    .UsingEntity<Dictionary<string, object>>(
                        "RelatorioProduto",
                        r => r.HasOne<Relatorio>().WithMany()
                            .HasForeignKey("IdRelatorio")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("id_relatorio"),
                        l => l.HasOne<Produto>().WithMany()
                            .HasForeignKey("IdProduto")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("id_produto"),
                        j =>
                        {
                            j.HasKey("IdProduto", "IdRelatorio").HasName("relatorio_produto_pkey");
                            j.ToTable("relatorio_produto");
                            j.IndexerProperty<int>("IdProduto").HasColumnName("id_produto");
                            j.IndexerProperty<int>("IdRelatorio").HasColumnName("id_relatorio");
                        });*/
            });
            #endregion

            #region Relatorio
            modelBuilder.Entity<Relatorio>(entity =>
            {
                entity.HasKey(e => e.IdRelatorio).HasName("relatorio_pkey");

                entity.ToTable("relatorio");

                entity.Property(e => e.IdRelatorio)
                    .ValueGeneratedNever()
                    .HasColumnName("id_relatorio");

                entity.Property(e => e.Dados)
                    .HasColumnType("character varying")
                    .HasColumnName("dados");

                entity.Property(e => e.DataGeracao).HasColumnName("data_geracao");
                entity.Property(e => e.IdLoja).HasColumnName("id_loja");
                entity.Property(e => e.IdProduto).HasColumnName("id_produto");

                entity.Property(e => e.Tipo)
                    .HasColumnType("character varying")
                    .HasColumnName("tipo");

                entity.HasOne(d => d.IdLojaNavigation)
                    .WithMany(p => p.Relatorios)
                    .HasForeignKey(d => d.IdLoja)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_loja");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.Relatorios)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("id_produto");

                entity.HasMany(d => d.IdLojas)
                    .WithMany(p => p.IdRelatoros)
                    .UsingEntity<Dictionary<string, object>>(
                        "RelatorioLoja",
                        r => r.HasOne<Loja>().WithMany()
                            .HasForeignKey("IdLoja")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("id_loja"),
                        l => l.HasOne<Relatorio>().WithMany()
                            .HasForeignKey("IdRelatoro")
                            .OnDelete(DeleteBehavior.ClientSetNull)
                            .HasConstraintName("id_relatorio"),
                        j =>
                        {
                            j.HasKey("IdRelatoro", "IdLoja").HasName("relatorio_loja_pkey");
                            j.ToTable("relatorio_loja");
                            j.IndexerProperty<int>("IdRelatoro").HasColumnName("id_relatoro");
                            j.IndexerProperty<int>("IdLoja").HasColumnName("id_loja");
                        });
            });
            #endregion

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
