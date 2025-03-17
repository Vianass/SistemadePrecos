using System;
using SistemaPrecos.Core.Entities;

namespace SistemaPrecos.Core.Models{

public partial class Categoria
{
    public int IdCategoria { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
