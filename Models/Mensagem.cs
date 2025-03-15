using System;
using System.Collections.Generic;

namespace SistemaPrecos.Core.Models;

public partial class Mensagem
{
    public int IdMensagem { get; set; }

    public string Conteudo { get; set; } = null!;

    public DateOnly DataEnvio { get; set; }

    public int IdUtilizador { get; set; }

    public virtual Utilizador IdUtilizadorNavigation { get; set; } = null!;
}
