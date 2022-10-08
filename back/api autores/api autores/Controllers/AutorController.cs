using api_autores.Entitys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        //CUANDO QUEREMOS OBTENER SOLO LOS HABILITADOS
        [HttpGet("custom")]
        public async Task<ActionResult<List<Autor>>> findAllCustom()
        {
            return  await context.Autor.Where(x=>x.estado==true).ToListAsync();
        }
        //CUANDO QUEREMOS GUARDAR INFORMACION
        [HttpPost] 
        public async Task<ActionResult> add(Autor a)
        {
            context.Add(a);
            await context.SaveChangesAsync();
            return Ok();
        }
        //CUANDO QUEREMOS BUSCAR INFORMACION
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Autor>> findById(int id)
        {
            var autor = await context.Autor.FirstOrDefaultAsync(x => x.codigoautor == id);
            return autor;
        }
        //CUANDO QUEREMOS ACTUALIZAR INFORMACION
        [HttpPut("{id:int}")]
        public async Task<ActionResult> update(Autor a,int id)
        {   
            if(a.codigoautor != id)
            {
                return BadRequest("NO SE ENCONTRO EL CODIGO CORRESPONDIENTE");
            }
            context.Update(a);
            await context.SaveChangesAsync();
            return Ok();
        }
        //CUANDO QUEREMOS ELIMINAR INFORMACION
        [HttpDelete("{id:int}")]
        /*public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Autor.AnyAsync(x => x.codigo == id);
            if (!existe)
            {
                return NotFound();
            }
            context.Remove(new Autor() {codigo=id});
            await context.SaveChangesAsync();
            return Ok();
        }*/
        
        public async Task<ActionResult> delete(int id)
        {
            var existe = await context.Autor.AnyAsync(x => x.codigoautor == id);
            if (!existe)
            {
                return NotFound();
            }
            var autor = await context.Autor.FirstOrDefaultAsync(x => x.codigoautor == id);
            autor.estado = false;         
            context.Update(autor);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
