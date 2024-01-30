using Microsoft.EntityFrameworkCore;
using TiendaCasera.Models;

namespace TiendaCasera.Data
{
    public class ApiDbContext :  DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
            
        }


        public DbSet<Productos> productos { get; set; }

    }
}
