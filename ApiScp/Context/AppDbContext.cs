using ApiScp.Model;
using Microsoft.EntityFrameworkCore;

namespace ApiScp.Context
{
    public class AppDbContext : DbContext
    {
        //iniciando construtor
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //Dizendo para o EF que essa é uma instancia que tem que ser salva no banco de dados
        public DbSet<Scp> Scps { get; set; }
    }
}
