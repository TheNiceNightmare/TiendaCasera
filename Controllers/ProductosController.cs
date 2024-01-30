using Microsoft.AspNetCore.Mvc;
using TiendaCasera.Data;
using TiendaCasera.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaCasera.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly ApiDbContext dbContext;

        public ProductosController(ApiDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public IEnumerable<Productos> Get()
        {
            return dbContext.productos;
        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var producto = dbContext.productos.FirstOrDefault(s => s.Id == id);

            if (producto == null)
            {
                return NotFound();
            }

            return Ok(producto);
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Productos updatedProducto)
        {

         
            if (updatedProducto == null || id != updatedProducto.Id)
            {
                return BadRequest();
            }

            var existingProducto = dbContext.productos.FirstOrDefault(s => s.Id == id);

            if (existingProducto == null)
            {
                return NotFound();
            }

            existingProducto.NombreDeProducto = updatedProducto.NombreDeProducto;
            existingProducto.TipoDeProducto = updatedProducto.TipoDeProducto;

            dbContext.SaveChanges();

            return NoContent();
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var productoToDelete = dbContext.productos.FirstOrDefault(s => s.Id == id);

            if (productoToDelete == null)
            {
                return NotFound();
            }

            dbContext.productos.Remove(productoToDelete);
            dbContext.SaveChanges();

            return NoContent();
        }
    }
}
