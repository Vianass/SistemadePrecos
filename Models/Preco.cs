using System;
using SistemaPrecos.Core.Entities;

namespace SistemaPrecos.Core.Models;

public partial class Preco
{
    public int IdPreco { get; set; }

    public decimal Valor { get; set; }

    public DateOnly DataHora { get; set; }

    public string Credibilidade { get; set; } = null!;

    public int IdProduto { get; set; }

    public string ApplicationUserId { get; set; } = null!;

    public int IdLoja { get; set; }

    public virtual ICollection<AvaliacaoPreco> AvaliacaoPrecos { get; set; } = new List<AvaliacaoPreco>();

    public virtual Loja IdLojaNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;

    public virtual ApplicationUser UserNavigation { get; set; } = null!;
}
