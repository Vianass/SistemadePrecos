using System;
using SistemaPrecos.Core.Entities;

namespace SistemaPrecos.Core.Models;

public partial class Mensagem
{
    public int IdMensagem { get; set; }

    public string Conteudo { get; set; } = null!;

    public DateOnly DataEnvio { get; set; }

    public string ApplicationUserId { get; set; } = null!;

    public virtual ApplicationUser UserNavigation { get; set; } = null!;
}
