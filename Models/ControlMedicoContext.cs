using Microsoft.EntityFrameworkCore;

namespace Control_Medico_NS.Models
{
    public class ControlMedicoContext : DbContext
    {
        public ControlMedicoContext(DbContextOptions<ControlMedicoContext> opciones) : base(opciones)
        {

        }

        public DbSet<Especialidad> Especialidad { get; set; }
    }
}