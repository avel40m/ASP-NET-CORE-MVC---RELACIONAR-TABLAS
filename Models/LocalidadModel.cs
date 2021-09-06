using System.ComponentModel.DataAnnotations;

namespace presonasimagen.Models
{
    public class LocalidadModel
    {
        [Key]
        public int Id { get; set; } 
        [Required(ErrorMessage ="Campo requerido*")]
        public string Localidad { get; set; }
    }
}