using System;
using SistemaPrecos.Core.Entities;

namespace SistemaPrecos.Core.Models;

public partial class AvaliacaoPreco
{
    public int IdAvaliacao { get; set; }

    public string Comentario { get; set; } = null!;

    public string Confiabilidade { get; set; } = null!;

    public int IdPreco { get; set; }

    public string ApplicationUserId { get; set; } = null!;

    public virtual Preco IdPrecoNavigation { get; set; } = null!;

   public virtual ApplicationUser UserNavigation { get; set; } = null!;
}
