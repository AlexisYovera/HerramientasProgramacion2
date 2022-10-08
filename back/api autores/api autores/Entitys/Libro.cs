using System.ComponentModel.DataAnnotations;

namespace api_autores.Entitys
{
    public class Libro
    {
        [Key]
        public int codigolibro { get; set; }
        [Required]
        //DEFINIMOS TAMAÑO DEL CAMPO
        [StringLength(maximumLength: 100, ErrorMessage = "SE TIENE QUE INGRESAR UN NOMBRE")]

        public string titulo { get; set; }
        [Required]
        public bool estado { get; set; }
        [Required]
        public Autor autor { get; set; }
    }
}
