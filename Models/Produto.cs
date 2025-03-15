using System;
using System.Collections.Generic;

namespace SistemaPrecos.Core.Models;

public partial class Produto
{
    public int IdProduto { get; set; }

    public string Nome { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public int IdCategoria { get; set; }

    public int IdUtilizador { get; set; }

    public virtual Categorium IdCategoria1 { get; set; } = null!;

    public virtual Utilizador IdUtilizadorNavigation { get; set; } = null!;

    public virtual ICollection<Preco> Precos { get; set; } = new List<Preco>();

    public virtual ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();

    public virtual ICollection<Categorium> IdCategoriaNavigation { get; set; } = new List<Categorium>();

    public virtual ICollection<Relatorio> IdRelatorios { get; set; } = new List<Relatorio>();
}
