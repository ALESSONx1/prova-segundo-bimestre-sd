using Dominio.Entidades;
using Infra.Contexto.Maps;
using Microsoft.EntityFrameworkCore;

namespace Infra.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Veiculo> Veiculos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new VeiculoMap());
        }
    }
}
