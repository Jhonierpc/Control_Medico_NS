using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Control_Medico_NS.Models
{
    public class Doctor
    {
        [Key]
        public int PubIntIdDoctor { get; set; }
        public string PubStrNombre {get; set;}
        public string PubStrCredencial {get; set;}
        public string PubStrHospital {get; set;}
        public string PubStrTelefono {get; set;}
        public string PubStrEmail {get; set;}
        public List<DoctorEspecialidad> DoctorEspecialidad { get; set; }
    }
}