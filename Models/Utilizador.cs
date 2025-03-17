/*using System;
using System.Collections.Generic;
using SistemaPrecos.Core.Entities;

namespace SistemaPrecos.Core.Entities
{
    public enum UtilizadorTipo
    {
        User,
        UserManager,
        Admin
    }

    public partial class Utilizador
    {
        public int IdUtilizador { get; set; }

        public string Nome { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Senha { get; set; } = null!;

        // Agora usamos o enum diretamente
        public UtilizadorTipo Tipo { get; set; }

        // Exemplo de coleções relacionadas (comentadas por enquanto):
        // public virtual ICollection<AvaliacaoPreco> AvaliacaoPrecos { get; set; } = new List<AvaliacaoPreco>();
        // public virtual ICollection<Mensagem> Mensagens { get; set; } = new List<Mensagem>();
        // public virtual ICollection<Preco> Precos { get; set; } = new List<Preco>();
        // public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
    }
}
*/
