using biblioteca.dtos.producto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;
using Services.Services.producto;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class productoController : ControllerBase

    {
        private readonly IProductoService _productoService;

        public productoController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        // GET: /api/producto
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var productos = await _productoService.GetAll();
            return Ok(productos);
        }
        // GET: /api/producto/activos
        [HttpGet("activos")]
        public async Task<IActionResult> GetAllActivos()
        {
            var productos = await _productoService.GetAllActivos();
            return Ok(productos);
        }
        // GET: /api/producto/categoria/5
        [HttpGet("categoria/{categoriaId}")]
        public async Task<IActionResult> GetByCategoria(int categoriaId)
        {
            var productos = await _productoService.GetByCategoria(categoriaId);
            return Ok(productos);
        }

        // GET: /api/producto/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var producto = await _productoService.GetById(id);
            return producto is null ? NotFound() : Ok(producto);
        }

        // POST: api/producto/Create
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductoCreateDto dataDto)
        {
            var productoCreado = await _productoService.Create(dataDto);
            return CreatedAtAction(nameof(GetById), new {id = productoCreado.Id}, productoCreado);
        }
        // PUT: producto/Update/5
        [Authorize(Roles = "Admin")]
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductoUpdateDto dataDto)
        {
            var productoActualizado = await _productoService.Update(dataDto.Id, dataDto);
            return productoActualizado is null ? NotFound() : Ok(productoActualizado);
        }
        // GET: productoController/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eliminado = await _productoService.Delete(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
