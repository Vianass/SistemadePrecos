using System;
using Npgsql;

class Database
{
    static void Main()
    {
        string connString = "Host=localhost;Port=5432;Username=postgres;Password=varzim2004;Database=Plataformadecomparacaodeprecos";

        using (var conn = new NpgsqlConnection(connString))
        {
            try
            {
                conn.Open();
                Console.WriteLine("🟢 Conectado ao PostgreSQL com sucesso!");
                
                using (var cmd = new NpgsqlCommand("SELECT version();", conn))
                {
                    var result = cmd.ExecuteScalar();
                    Console.WriteLine($"Versão do PostgreSQL: {result}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"🔴 Erro na conexão: {ex.Message}");
            }
        }
    }
}
