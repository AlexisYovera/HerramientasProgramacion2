using api_autores.Entitys;
using Microsoft.EntityFrameworkCore;

namespace api_autores
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
   
        }

        //COONFIGURAMOS LAS TABLAS DE LA BASE DE DATOS
        public DbSet<Autor> Autor { get; set; }
    }
}
