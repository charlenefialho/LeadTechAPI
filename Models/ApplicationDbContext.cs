using Microsoft.EntityFrameworkCore;

namespace LeadTech.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Campanha> Campanhas { get; set; }
        public DbSet<Lead> Leads { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("tb_cliente");
            modelBuilder.Entity<Cliente>().HasKey(c => c.IdCliente);

            modelBuilder.Entity<Campanha>().ToTable("tb_campanhas");
            modelBuilder.Entity<Campanha>().HasKey(c => c.IdCampanha);
            modelBuilder.Entity<Campanha>()
                .HasOne(c => c.Cliente)
                .WithMany(c => c.Campanhas)
                .HasForeignKey(c => c.TbClienteIdCliente);

            modelBuilder.Entity<Lead>().ToTable("tb_lead");
            modelBuilder.Entity<Lead>().HasKey(l => l.IdLead);
            modelBuilder.Entity<Lead>()
                .HasOne(l => l.Cliente)
                .WithMany(c => c.Leads)
                .HasForeignKey(l => l.TbClienteIdCliente);
            modelBuilder.Entity<Lead>()
                .HasOne(l => l.Campanha)
                .WithMany(c => c.Leads)
                .HasForeignKey(l => l.TbCampanhasIdCampanha);
        }
    }

}
