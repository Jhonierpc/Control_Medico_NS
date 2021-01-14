using System.ComponentModel.DataAnnotations;

namespace Control_Medico_NS.Models
{
    public class Especialidad
    {
        [Key] //Especificación de llave primaria
        public int PubIntIdEspecialidad {get; set;}
        public string PubStrDescripcion {get; set;}
        
    }
}