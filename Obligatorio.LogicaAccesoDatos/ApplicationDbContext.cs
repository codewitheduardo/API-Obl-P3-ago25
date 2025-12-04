using Microsoft.EntityFrameworkCore;
using Obligatorio.LogicaNegocio.Entidades;

namespace Obligatorio.LogicaAccesoDatos
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Restricciones UNIQUE

            modelBuilder.Entity<Equipo>()
              .HasIndex(e => e.Nombre)
              .IsUnique(); // Crea un índice único para el campo Nombre

            modelBuilder.Entity<Usuario>(u =>
            {
                u.OwnsOne(x => x.Email, e =>
                {
                    e.Property(p => p.Direccion)
                     .HasColumnName("Email_Direccion") 
                     .IsRequired();

                    e.HasIndex(p => p.Direccion)
                     .IsUnique();
                });
            }); // Crea un índice único para el campo Email

            modelBuilder.Entity<Gasto>()
             .HasIndex(g => g.Nombre)
             .IsUnique(); // Crea un índice único para el campo Nombre

            modelBuilder.Entity<PagoUnico>()
             .HasIndex(p => p.NroRecibo)
             .IsUnique(); // Crea un índice único para el campo NroRecibo


            /*Configuro el tipo de dato decimal para EF core*/
            modelBuilder.Entity<Pago>()
                .Property(p => p.Monto)
                .HasPrecision(18, 4); // o HasColumnType("decimal(18,4)")
        }

        public DbSet<Equipo> Equipos { get; set; }
        public DbSet<Gasto> Gastos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<PagoRecurrente> PagoRecurrentes { get; set; }
        public DbSet<PagoUnico> PagoUnicos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Auditoria> Auditorias { get; set; }
    }
}
