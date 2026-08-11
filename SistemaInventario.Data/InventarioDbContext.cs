using Microsoft.EntityFrameworkCore;
using SistemaInventario.Data.Entities;

namespace SistemaInventario.Data
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options)
        {

        }
        public DbSet<AsignacionEquipos> AsignacionEquipos { get; set; }
        public DbSet<CategoriaTicket> CategoriaTicket { get; set; }
        public DbSet<ComentariosTickets> ComentariosTickets { get; set; }
        public DbSet<Componentes> Componentes { get; set; }
        public DbSet<Equipos> Equipos { get; set; }
        public DbSet<HistoricoAsignaciones> HistoricoAsignaciones { get; set; }
        public DbSet<LicenciasSoftware> LicenciasSoftware { get; set; }
        public DbSet<Perifericos> Perifericos { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<Renting> Renting { get; set; }
        public DbSet<Sedes> Sedes { get; set; }
        public DbSet<Tickets> Tickets { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Equipos>()
                .Property(e => e.Estado)
                .HasDefaultValueSql("'Disponible'");

            modelBuilder.Entity<Equipos>()
                .HasIndex(e => e.Serial)
                .IsUnique();

            modelBuilder.Entity<Tickets>()
                .Property(t => t.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<Tickets>()
                .Property(t => t.Estado)
                .HasDefaultValueSql("'Abierto'");

            modelBuilder.Entity<Proveedores>()
                .HasIndex(p => p.Nit)
                .IsUnique();

            modelBuilder.Entity<Perifericos>()
                .HasIndex(p => p.SerialPeriferico)
                .IsUnique();

            modelBuilder.Entity<Componentes>()
                .HasIndex(c => c.SerialComponente)
                .IsUnique();

            modelBuilder.Entity<LicenciasSoftware>()
                .HasIndex(l => l.ClaveActivacion)
                .IsUnique();

            modelBuilder.Entity<Usuario>()
                .HasIndex(u => u.Correo)
                .IsUnique();

            modelBuilder.Entity<Proveedores>()
                .HasIndex(p => p.CorreoSoporte)
                .IsUnique();

            modelBuilder.Entity<HistoricoAsignaciones>()
                .HasOne(h => h.Equipo)
                .WithMany()
                .HasForeignKey(h => h.EquipoId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<HistoricoAsignaciones>()
                .HasOne(h => h.Usuario)
                .WithMany()
                .HasForeignKey(h => h.UserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
