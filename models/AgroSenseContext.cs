using Microsoft.EntityFrameworkCore;

using AgroSenseAPI.models;

namespace AgroSenseAPI.Data
{
    public class AgroSenseContext : DbContext
    {
        public AgroSenseContext(DbContextOptions<AgroSenseContext> options) : base(options) { }

        public DbSet<Vegetal> Vegetais { get; set; }
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Aqui você precisa passar o nome da tabela como string
            modelBuilder.Entity<Vegetal>().ToTable("Vegetais");
            modelBuilder.Entity<Cliente>().ToTable("Clientes");

            // Configurações adicionais se necessário
        }
    }
}
