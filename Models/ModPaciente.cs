using System.ComponentModel.DataAnnotations;

namespace Control_Medico_NS.Models
{
    public class Paciente
    {
        [Key]
        public int PubIntIdPaciente {get; set;}
        public string PubStrNombre {get; set;}
        public string PubStrSeguro {get; set;}
        public string PubStrCodigoPostal {get; set;}
        public string PubStrTelefono {get; set;}
        public string PubStrDireccion {get; set;}
        public string PubStrEmail {get; set;}
    }
}