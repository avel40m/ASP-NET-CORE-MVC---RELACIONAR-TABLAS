using System.ComponentModel.DataAnnotations;

namespace presonasimagen.Models
{
    public class TitulosModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo requerido*")]
        public string Titulo { get; set; }
    }
}