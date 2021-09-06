using System.ComponentModel.DataAnnotations;

namespace presonasimagen.Models
{
    public class EstudiosModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo requerido*")]
        public string Estudios { get; set; }
    }
}