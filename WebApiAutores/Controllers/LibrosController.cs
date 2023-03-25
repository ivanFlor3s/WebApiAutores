using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
            var libro = await _context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(libro => libro.Id == id);
            return Ok(libro);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Libro libro)
        {
            var existeAutor = await _context.Autores.AnyAsync(autor => autor.Id == libro.AutorId);
            if (!existeAutor)
            {
                return BadRequest($"No eciste el libro de id: {libro.AutorId}");
            };
            _context.Add(libro);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
