using biblioteca.dtos.categoria;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.categoria;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class categoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public categoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: /api/categoria
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaService.GetAll();
            return Ok(categorias);
        }

        // GET: /api/categoria/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.GetById(id);
            return categoria is null ? NotFound() : Ok(categoria);
        }

        // POST: /api/categoria
        [Authorize(Roles = "Admin")] 
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CategoriaCreateDto dataDto)
        {
            var categoriaCreada = await _categoriaService.Create(dataDto);
            // Assuming CategoriaDto has an Id property.
            return CreatedAtAction(nameof(GetById), new { id = categoriaCreada.Id }, categoriaCreada);
        }

        // PUT: /api/categoria
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] CategoriaUpdateDto dataDto)
        {
            var categoriaActualizada = await _categoriaService.Update(dataDto.Id, dataDto);
            return categoriaActualizada is null ? NotFound() : Ok(categoriaActualizada);
        }

        // DELETE: /api/categoria/54
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _categoriaService.Delete(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
