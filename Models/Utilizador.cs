using System;
using System.Collections.Generic;

namespace SistemaPrecos.Core.Models;

public partial class Utilizador
{
    public int IdUtilizador { get; set; }

    public string Email { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public int IdTipo { get; set; }

    public string Nome { get; set; } = null!;

    public virtual ICollection<AvaliacaoPreco> AvaliacaoPrecos { get; set; } = new List<AvaliacaoPreco>();

    public virtual ICollection<Mensagem> Mensagems { get; set; } = new List<Mensagem>();

    public virtual ICollection<Preco> Precos { get; set; } = new List<Preco>();

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
