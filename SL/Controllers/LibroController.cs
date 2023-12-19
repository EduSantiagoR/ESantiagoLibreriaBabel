using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace SL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        [Route("")]
        [HttpGet]
        public IActionResult GetAll()
        {
            ML.Result result = BL.Libro.GetAll();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Route("{idLibro}")]
        [HttpGet]
        public IActionResult GetById(int idLibro)
        {
            ML.Result result = BL.Libro.GetById(idLibro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Route("")]
        [HttpPost]
        public IActionResult Add(ML.Libro libro)
        {
            ML.Result result = BL.Libro.Add(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Route("{idLibro}")]
        [HttpPut]
        public IActionResult Update(int idLibro, [FromBody] ML.Libro libro)
        {
            libro.IdLibro = idLibro;
            ML.Result result = BL.Libro.Update(libro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
        [Route("{idLibro}")]
        [HttpDelete]
        public IActionResult Delete(int idLibro)
        {
            ML.Result result = BL.Libro.Delete(idLibro);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result);
            }
        }
    }
}
