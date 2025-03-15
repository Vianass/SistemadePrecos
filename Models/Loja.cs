using System;
using System.Collections.Generic;

namespace SistemaPrecos.Core.Models;

public partial class Loja
{
    public int IdLoja { get; set; }

    public string Nome { get; set; } = null!;

    public string Localizacao { get; set; } = null!;

    public decimal Contacto { get; set; }

    public DateOnly DataCriacao { get; set; }

    public virtual ICollection<Preco> Precos { get; set; } = new List<Preco>();

    public virtual ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();

    public virtual ICollection<Relatorio> IdRelatoros { get; set; } = new List<Relatorio>();
}
