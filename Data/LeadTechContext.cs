using Microsoft.EntityFrameworkCore;

namespace LeadTechAPI.Model
{
    public class LeadTechAPIContext : DbContext
    {
        public LeadTechAPIContext(DbContextOptions<LeadTechAPIContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }

        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>()
            .Property(c => c.TaxaChurn)
            .HasColumnType("decimal(4, 2)");

            modelBuilder.Entity<Cliente>()
               .Property(c => c.DataCriacao)
               .HasColumnType("VARCHAR2(30)");

            modelBuilder.Entity<Cliente>().HasData(
                new Cliente { IdCliente = 1, Nome = "Exemplo Cliente 1", Setor = "Setor A", TaxaChurn = 0.05m, DataCriacao = "24/05/24 10:00:00,000000000" },
                new Cliente { IdCliente = 2, Nome = "Exemplo Cliente 2", Setor = "Setor B", TaxaChurn = 0.1m, DataCriacao = "24/05/24 10:00:00,000000000" }
            );
        }
    }
}
