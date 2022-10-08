using api_autores.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api_autores.Controllers
{
    //INDICAMOS QUE ES UN CONTROLADOR
    [ApiController]
    //DEFINIR LA RUTA DE ACCESO AL CONTROLADOR
    [Route("api-autores/autor")]
    //: ControllerBase ES UNA HERENCIA PARA QUE SEA UN CONTROLADOR
    public class AutorController: ControllerBase
    {
        private readonly ApplicationDBContext context;

        //CREAMOS EL METODO CONSTRUCTOR
        public AutorController(ApplicationDBContext context)
        {
            this.context = context;
        }
        //CUANDO QUEREMOS OBTENER INFORMACION
        [HttpGet]
        public async Task<ActionResult<List<Autor>>> findAll()
        {
            return await context.Autor.ToListAsync();
        }
        //CUANDO QUEREMOS GUARDAR INFORMACION
        [HttpPost]
        public async Task<ActionResult> add(Autor a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
