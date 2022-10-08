using System.ComponentModel.DataAnnotations;

namespace api_autores.Entitys
{
    public class Autor
    {
        //DEFINIMOS LA CLAVE PRIMARIA
        [Key]
        public int codigo { get; set; }
        //DEFINIMOS VALORES NO NULOS
        [Required]
        //DEFINIMOS TAMAÑO DEL CAMPO
        [StringLength(maximumLength: 100, ErrorMessage = "SE TIENE QUE INGRESAR UN NOMBRE")]

        public string nombre { get; set; }
        [Required]
        public bool estado { get; set; }
    }
}
