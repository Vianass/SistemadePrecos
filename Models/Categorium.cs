using System;
using System.Collections.Generic;

namespace SistemaPrecos.Core.Models;

public partial class Categorium
{
    public int IdCategoria { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();

    public virtual ICollection<Produto> IdProdutos { get; set; } = new List<Produto>();
}
