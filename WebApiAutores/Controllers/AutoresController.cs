using Microsoft.AspNetCore.Mvc;
using WebApiAutores.Entities;

namespace WebApiAutores.Controllers
{
    [ApiController]
    [Route("api/autores")]
    public class AutoresController: ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Autor>> Get() 
        {
            return new List<Autor>()
            {
                new Autor(){Id = 1, Name = "buLLIERSE"},
                new Autor(){Id = 2, Name = "CILERIA CILERIA"},
            };
        }
    }
}
