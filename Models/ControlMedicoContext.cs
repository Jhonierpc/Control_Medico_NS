using Microsoft.EntityFrameworkCore;

namespace Control_Medico_NS.Models
{
    public class ControlMedicoContext : DbContext
    {
        public ControlMedicoContext(DbContextOptions<ControlMedicoContext> opciones) : base(opciones)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }
        
        public DbSet<Paciente> Paciente { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Especialidad>(entidad =>
            {
                entidad.ToTable("Especialidad");
                entidad.HasKey(e => e.PubIntIdEspecialidad);
                entidad.Property(e => e.PubStrDescripcion)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            }
            );

            modelBuilder.Entity<Paciente>(entidad =>
            {
                entidad.ToTable("Paciente");
                entidad.HasKey(t => t.PubIntIdPaciente);
                entidad.Property(t => t.PubStrNombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entidad.Property(t => t.PubStrSeguro)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entidad.Property(t => t.PubStrCodigoPostal)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);
                entidad.Property(t => t.PubStrTelefono)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
                entidad.Property(t => t.PubStrDireccion)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entidad.Property(t => t.PubStrEmail)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            }
            );
        }
    }
}