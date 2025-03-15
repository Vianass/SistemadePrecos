using System;
using System.Collections.Generic;

namespace SistemaPrecos.Core.Models;

public partial class Relatorio
{
    public int IdRelatorio { get; set; }

    public string Tipo { get; set; } = null!;

    public string Dados { get; set; } = null!;

    public DateOnly DataGeracao { get; set; }

    public int IdLoja { get; set; }

    public int IdProduto { get; set; }

    public virtual Loja IdLojaNavigation { get; set; } = null!;

    public virtual Produto IdProdutoNavigation { get; set; } = null!;

    public virtual ICollection<Loja> IdLojas { get; set; } = new List<Loja>();

    public virtual ICollection<Produto> IdProdutos { get; set; } = new List<Produto>();
}
