using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.DTOs;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/libros")]
    public class LibrosController: ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper mapper;

        public LibrosController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<LibroDTO>> Get(int id)
        {
            var libro = await _context.Libros.Include(x => x.Autor).FirstOrDefaultAsync(libro => libro.Id == id);

            return Ok(mapper.Map<LibroDTO>(libro));
        }

        [HttpPost]
        public async Task<ActionResult> Post(LibroCreacionDTO libroDTO)
        {
            var libro = mapper.Map<Libro>(libroDTO);
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
