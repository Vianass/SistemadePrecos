using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SistemaPrecos.Core.Models;

namespace SistemaPrecos.Core.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AvaliacaoPreco> AvaliacaoPrecos { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Loja> Lojas { get; set; }

    public virtual DbSet<Mensagem> Mensagems { get; set; }

    public virtual DbSet<Preco> Precos { get; set; }

    public virtual DbSet<Produto> Produtos { get; set; }

    public virtual DbSet<Relatorio> Relatorios { get; set; }

    public virtual DbSet<Utilizador> Utilizadors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=varzim2004;Database=Plataformadecomparacaodeprecos");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AvaliacaoPreco>(entity =>
        {
            entity.HasKey(e => e.IdAvaliacao).HasName("avaliacao_preco_pkey");

            entity.ToTable("avaliacao_preco");

            entity.Property(e => e.IdAvaliacao)
                .ValueGeneratedNever()
                .HasColumnName("id_avaliacao");
            entity.Property(e => e.Comentario)
                .HasColumnType("character varying")
                .HasColumnName("comentario");
            entity.Property(e => e.Confiabilidade)
                .HasColumnType("character varying")
                .HasColumnName("confiabilidade");
            entity.Property(e => e.IdPreco).HasColumnName("id_preco");
            entity.Property(e => e.IdUtilizador).HasColumnName("id_utilizador");

            entity.HasOne(d => d.IdPrecoNavigation).WithMany(p => p.AvaliacaoPrecos)
                .HasForeignKey(d => d.IdPreco)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_preco");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithMany(p => p.AvaliacaoPrecos)
                .HasForeignKey(d => d.IdUtilizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_utilizador");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.IdCategoria).HasName("categoria_pkey");

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria)
                .ValueGeneratedNever()
                .HasColumnName("id_categoria");
            entity.Property(e => e.Nome)
                .HasColumnType("character varying")
                .HasColumnName("nome");

            entity.HasMany(d => d.IdProdutos).WithMany(p => p.IdCategoriaNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "CategoriaProduto",
                    r => r.HasOne<Produto>().WithMany()
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("id_produto"),
                    l => l.HasOne<Categorium>().WithMany()
                        .HasForeignKey("IdCategoria")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("id_categoria"),
                    j =>
                    {
                        j.HasKey("IdCategoria", "IdProduto").HasName("categoria_produto_pkey");
                        j.ToTable("categoria_produto");
                        j.IndexerProperty<int>("IdCategoria").HasColumnName("id_categoria");
                        j.IndexerProperty<int>("IdProduto").HasColumnName("id_produto");
                    });
        });

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
            entity.Property(e => e.IdUtilizador).HasColumnName("id_utilizador");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithMany(p => p.Mensagems)
                .HasForeignKey(d => d.IdUtilizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_utilizador");
        });

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
            entity.Property(e => e.IdUtilizador).HasColumnName("id_utilizador");
            entity.Property(e => e.Valor).HasColumnName("valor");

            entity.HasOne(d => d.IdLojaNavigation).WithMany(p => p.Precos)
                .HasForeignKey(d => d.IdLoja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_loja");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Precos)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_produto");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithMany(p => p.Precos)
                .HasForeignKey(d => d.IdUtilizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_utilizador");
        });

        modelBuilder.Entity<Produto>(entity =>
        {
            entity.HasKey(e => e.IdProduto).HasName("produto_pkey");

            entity.ToTable("produto");

            entity.Property(e => e.IdProduto)
                .ValueGeneratedNever()
                .HasColumnName("id_produto");
            entity.Property(e => e.Categoria)
                .HasColumnType("character varying")
                .HasColumnName("categoria ");
            entity.Property(e => e.Descricao)
                .HasColumnType("character varying")
                .HasColumnName("descricao");
            entity.Property(e => e.IdCategoria).HasColumnName("id_categoria");
            entity.Property(e => e.IdUtilizador).HasColumnName("id_utilizador");
            entity.Property(e => e.Nome)
                .HasColumnType("character varying")
                .HasColumnName("nome");

            entity.HasOne(d => d.IdCategoria1).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_categoria");

            entity.HasOne(d => d.IdUtilizadorNavigation).WithMany(p => p.Produtos)
                .HasForeignKey(d => d.IdUtilizador)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_utilizador");

            entity.HasMany(d => d.IdRelatorios).WithMany(p => p.IdProdutos)
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
                    });
        });

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

            entity.HasOne(d => d.IdLojaNavigation).WithMany(p => p.Relatorios)
                .HasForeignKey(d => d.IdLoja)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_loja");

            entity.HasOne(d => d.IdProdutoNavigation).WithMany(p => p.Relatorios)
                .HasForeignKey(d => d.IdProduto)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("id_produto");

            entity.HasMany(d => d.IdLojas).WithMany(p => p.IdRelatoros)
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

        modelBuilder.Entity<Utilizador>(entity =>
        {
            entity.HasKey(e => e.IdUtilizador).HasName("utilizador_pkey");

            entity.ToTable("utilizador");

            entity.Property(e => e.IdUtilizador)
                .ValueGeneratedNever()
                .HasColumnName("id_utilizador");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.IdTipo).HasColumnName("id_tipo");
            entity.Property(e => e.Nome)
                .HasColumnType("character varying")
                .HasColumnName("nome");
            entity.Property(e => e.Senha)
                .HasColumnType("character varying")
                .HasColumnName("senha");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
