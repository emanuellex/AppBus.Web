using AppBus.Web.Models;
using Microsoft.EntityFrameworkCore;

namespace AppBus.Web.Persistencia
{
    public class BusContext : DbContext
    {
        public DbSet<Onibus> Onibuss { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CartaoCredito> Cartoes { get; set; }
        public DbSet<Bilhete> Bilhetes { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }
        public DbSet<TipoOnibus> Tipo { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Avaliacao>()
                .HasKey(x => new { x.UsuarioId, x.OnibusId });
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Avaliacao>()
                .HasOne(x => x.Usuario)
                .WithMany(x => x.Avaliacao)
                .HasForeignKey(x => x.UsuarioId);
            modelBuilder.Entity<Avaliacao>()
                .HasOne(x => x.Onibus)
                .WithMany(x => x.Avaliacao)
                .HasForeignKey(x => x.OnibusId);
        }
        public BusContext(DbContextOptions options) : base(options)
        {
        }
    
}
}
