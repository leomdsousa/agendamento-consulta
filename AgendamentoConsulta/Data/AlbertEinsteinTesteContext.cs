using AlbertEinsteinTeste.Models;
using Microsoft.EntityFrameworkCore;

namespace AlbertEinsteinTeste.Data
{
    public class AlbertEinsteinTesteContext : DbContext
    {
        public AlbertEinsteinTesteContext(DbContextOptions<AlbertEinsteinTesteContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>()
                .Property(x => x.Diagnostico)
                .IsRequired(false);
        }

        public DbSet<Consulta> Consulta { get; set; }
        public DbSet<Medico> Medico { get; set; }
        public DbSet<Paciente> Paciente { get; set; }
        public DbSet<ConsultaSituacao> ConsultaSituacao { get; set; }
    }
}
