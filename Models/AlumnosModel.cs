using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace presonasimagen.Models
{
    public class AlumnosModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Campo requerido*")]
        public string Nombre { get; set; }
        [Required(ErrorMessage ="Campo requerido*")]
        public string Apellido { get; set; }
        [Required(ErrorMessage ="Campo requerido*")]
        [RegularExpression("(^[0-9]+$)",ErrorMessage ="Solo ingresar números")]
        public int Edad { get; set; }
        [Display(Name ="Foto")]
        public string ImagenName { get; set; }
        [NotMapped]
        [Display(Name ="Foto")]
        public IFormFile ImageFile { get; set; }
        [Display(Name ="Seleccionar opción")]
        public int IdLocalidad { get; set; }
        [ForeignKey("IdLocalidad")]
        public virtual LocalidadModel Localidad { get; set; }
        [Display(Name ="Seleccionar opción")]
        public int IdEstudio { get; set; }
        [ForeignKey("IdEstudio")]
        public virtual EstudiosModel Estudios { get; set; }
        [Display(Name ="Seleccionar opción")]
        public int IdTitulo { get; set; }
        [ForeignKey("IdTitulo")]
        public virtual TitulosModel Titulos { get; set; }
    }
}