using Microsoft.AspNetCore.Identity;
using System;

namespace SistemaPrecos.Core.Entities
{
    /// <summary>
    /// Enum representando o tipo de utilizador no sistema.
    /// </summary>
    public enum UtilizadorTipo
    {
        User,
        UserManager,
        Admin
    }

    /// <summary>
    /// Classe unificada de utilizador. 
    /// Herda de IdentityUser (ID é string, Email, PasswordHash, etc.).
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string Nome { get; set; } = null!;

        public UtilizadorTipo Tipo { get; set; } = UtilizadorTipo.User;

        // Caso queira armazenar a data de criação
        public DateTime DataCriacao { get; set; } = DateTime.Now;

        // Se antes você usava "Senha", lembre-se que agora 
        // IdentityUser utiliza "PasswordHash" internamente para armazenar senhas de forma segura.
    }
}