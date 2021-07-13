using Localiza.Frotas.Domain;
using Microsoft.EntityFrameworkCore;

namespace Localiza.Frotas.Infra.Repository.EntityFrameworkRepository
{
    public class FrotaContext : DbContext
    {
        public FrotaContext(DbContextOptions<FrotaContext> options) : base(options)
        {
            
        }
        
        public DbSet<Veiculo> Veiculos { get; set; }
    }
}