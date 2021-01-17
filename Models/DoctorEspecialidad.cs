namespace Control_Medico_NS.Models
{
    public class DoctorEspecialidad
    {
        public int PubIntIdDoctor { get; set; }
        public int PubIntIdEspecialidad { get; set; }
        public Doctor Doctor { get; set; }
        public Especialidad Especialidad { get; set; }
    }
}