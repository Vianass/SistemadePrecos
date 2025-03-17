using SistemaPrecos.Core.Entities;

namespace SistemaPrecos.Core.Models{

public partial class Produto
{
    public int IdProduto { get; set; }

    public string Nome { get; set; } = null!;

    public string TipoCategoria { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public string ApplicationUserId { get; set; } = null!;

    public virtual ICollection<Preco> Precos { get; set; } = new List<Preco>();

    public virtual ICollection<Relatorio> Relatorios { get; set; } = new List<Relatorio>();

    public virtual ApplicationUser UserNavigation { get; set; } = null!;
    public virtual ICollection<Categoria> Categorias { get; set; } = new List<Categoria>();
    }
}
