using System;
using System.Collections.Generic;

namespace SistemaPrecos.Core.Models;

public partial class AvaliacaoPreco
{
    public int IdAvaliacao { get; set; }

    public string Comentario { get; set; } = null!;

    public string Confiabilidade { get; set; } = null!;

    public int IdPreco { get; set; }

    public int IdUtilizador { get; set; }

    public virtual Preco IdPrecoNavigation { get; set; } = null!;

    public virtual Utilizador IdUtilizadorNavigation { get; set; } = null!;
}
